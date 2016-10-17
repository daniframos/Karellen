using Karellen.Data.Contexto;
using Karellen.Data.Infraestrutura.Repositorio;
using Karellen.Data.Interface.Repositorio;
using Karellen.Data.Interface.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Karellen.Data.Infraestrutura.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KarellenContexto _context;
        private IRepositorioLoginExterno _repositorioLoginExterno;
        private IRepositorioGrupo _repositorioGrupo;
        private IRepositorioUsuario _repositorioUsuario;
        private IRepositorioLog _repositorioLog;
        private IRepositorioOcorrencia _repositorioOcorrencia;
        private IRepositorioTipoOcorrencia _repositorioTipoOcorrencia;

        public IRepositorioLog RepositorioLog
        {
            get
            {
                return _repositorioLog ?? (_repositorioLog = new RepositorioLog(_context));
            }
        }
        public IRepositorioOcorrencia RepositorioOcorrencia
        {
            get { return _repositorioOcorrencia ?? (_repositorioOcorrencia = new RepositorioOcorrencia(_context)); }
        }

        public IRepositorioTipoOcorrencia RepositorioTipoOcorrencia
        {
            get { return _repositorioTipoOcorrencia ?? (_repositorioTipoOcorrencia = new RepositorioTipoOcorrencia(_context)); }
        }

        public IRepositorioGrupo RepositorioGrupo
        {
            get
            {
                return _repositorioGrupo ?? (_repositorioGrupo = new RepositorioGrupo(_context));
            }
        }
        public IRepositorioLoginExterno RepositorioLoginExterno
        {
            get
            {
                return _repositorioLoginExterno ?? (_repositorioLoginExterno = new RepositorioLoginExterno(_context));
            }
        }
        public IRepositorioUsuario RepositorioUsuario
        {
            get
            {
                return _repositorioUsuario ?? (_repositorioUsuario = new RepositorioUsuario(_context));
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public Task<int> SaveChangesAsync(CancellationToken token)
        {
            return _context.SaveChangesAsync(token);
        }

        public UnitOfWork(string nameOrConnectionString)
        {
            _context = new KarellenContexto(nameOrConnectionString);
        }
        public UnitOfWork(KarellenContexto context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _repositorioLoginExterno = null;
            _repositorioGrupo = null;
            _repositorioUsuario = null;
        }
    }
}
