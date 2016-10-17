using Karellen.Data.Interface.Repositorio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Karellen.Data.Interface.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IRepositorioLoginExterno RepositorioLoginExterno { get;}
        IRepositorioGrupo RepositorioGrupo { get; }
        IRepositorioUsuario RepositorioUsuario { get; }
        IRepositorioLog RepositorioLog { get; }
        IRepositorioOcorrencia RepositorioOcorrencia { get; }
        IRepositorioTipoOcorrencia RepositorioTipoOcorrencia { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
