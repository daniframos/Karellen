using Karellen.Data.Entidade;
using System.Threading;
using System.Threading.Tasks;

namespace Karellen.Data.Interface.Repositorio
{
    public interface IRepositorioUsuario: IRepositorio<Usuario>
    {
        Usuario BuscarPorUserName(string nome);
        Task<Usuario> BuscarPorUserNameAsync(string nome);
        Task<Usuario> BuscarPorUserNameAsync(CancellationToken token, string nome);
        Usuario BuscarPorEmail(string email);
        Task<Usuario> BuscarPorEmailAsync(string email);
        Task<Usuario> BuscarPorEmailAsync(CancellationToken token, string email);
    }
}
