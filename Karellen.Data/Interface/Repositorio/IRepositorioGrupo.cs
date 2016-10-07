using Karellen.Data.Entidade;
using System.Threading;
using System.Threading.Tasks;

namespace Karellen.Data.Interface.Repositorio
{
    public interface IRepositorioGrupo : IRepositorio<Grupo>
    {
        Grupo BuscarPorNome(string nome);
        Task<Grupo> BuscarPorNomeAsync(string nome);
        Task<Grupo> BuscarPorNomeAsync(CancellationToken cancellationToken, string nome);
    }
}
