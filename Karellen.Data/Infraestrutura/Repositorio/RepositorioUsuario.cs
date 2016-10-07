using Karellen.Data.Contexto;
using Karellen.Data.Entidade;
using Karellen.Data.Interface.Repositorio;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Karellen.Data.Infraestrutura.Repositorio
{
    internal class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(KarellenContexto context) : base(context)
        {
        }

        public Usuario BuscarPorUserName(string nome)
        {
            return Set.FirstOrDefault(x => x.UserName == nome);
        }

        public Task<Usuario> BuscarPorUserNameAsync(string nome)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == nome);
        }

        public Task<Usuario> BuscarPorUserNameAsync(CancellationToken token, string nome)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == nome, token);
        }

        public Usuario BuscarPorEmail(string email)
        {
            return Set.FirstOrDefault(x => x.Email == email);
        }

        public Task<Usuario> BuscarPorEmailAsync(string email)
        {
            return Set.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<Usuario> BuscarPorEmailAsync(CancellationToken token, string email)
        {
            return Set.FirstOrDefaultAsync(x => x.Email == email, token);
        }
    }
}