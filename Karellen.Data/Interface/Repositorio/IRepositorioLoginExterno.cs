using Karellen.Data.Entidade;
using System.Threading;
using System.Threading.Tasks;

namespace Karellen.Data.Interface.Repositorio
{
    public interface IRepositorioLoginExterno: IRepositorio<LoginExterno>
    {
        LoginExterno BuscarProviderKey(string providerLogin, string providerkey);
        Task<LoginExterno> BuscarProviderKeyAsync(string providerLogin, string providerKey);
        Task<LoginExterno> BuscarProviderKeyAsync(CancellationToken token, string providerLogin, string providerKey);
    }
}
