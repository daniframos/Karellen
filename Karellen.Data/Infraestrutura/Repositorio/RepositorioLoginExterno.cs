using Karellen.Data.Contexto;
using Karellen.Data.Entidade;
using Karellen.Data.Interface.Repositorio;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Karellen.Data.Infraestrutura.Repositorio
{
    internal class RepositorioLoginExterno : Repositorio<LoginExterno>, IRepositorioLoginExterno
    {
        public RepositorioLoginExterno(KarellenContexto context) : base(context)
        {
            
        }

        public LoginExterno BuscarProviderKey(string providerLogin, string providerkey)
        {
            return Set.FirstOrDefault(x => x.LoginProvedor == providerLogin && x.KeyProvedor == providerkey);
        }

        public Task<LoginExterno> BuscarProviderKeyAsync(string providerLogin, string providerKey)
        {
            return Set.FirstOrDefaultAsync(x => x.LoginProvedor == providerLogin && x.KeyProvedor == providerKey);
        }

        public Task<LoginExterno> BuscarProviderKeyAsync(CancellationToken token, string providerLogin, string providerKey)
        {
            return Set.FirstOrDefaultAsync(x => x.LoginProvedor == providerLogin && x.KeyProvedor == providerKey, token);
        }
    }
}