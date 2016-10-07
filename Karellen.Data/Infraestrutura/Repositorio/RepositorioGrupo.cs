using Karellen.Data.Contexto;
using Karellen.Data.Entidade;
using Karellen.Data.Interface.Repositorio;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Karellen.Data.Infraestrutura.Repositorio
{
    internal class RepositorioGrupo : Repositorio<Grupo>, IRepositorioGrupo
    {
        public RepositorioGrupo(KarellenContexto context) : base(context)
        {
        }

        public Grupo BuscarPorNome(string nome)
        {
            return Set.FirstOrDefault(x => x.Nome == nome);
        }

        public Task<Grupo> BuscarPorNomeAsync(string nome)
        {
            return Set.FirstOrDefaultAsync(x => x.Nome == nome);
        }

        public Task<Grupo> BuscarPorNomeAsync(CancellationToken cancellationToken, string nome)
        {
            return Set.FirstOrDefaultAsync(x => x.Nome == nome, cancellationToken);
        }
    }
}