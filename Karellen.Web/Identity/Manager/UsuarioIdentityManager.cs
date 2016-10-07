using Karellen.Web.Identity.Modelo;
using Microsoft.AspNet.Identity;

namespace Karellen.Web.Identity.Manager
{
    public class UsuarioIdentityManager : UserManager<UsuarioIdentity, int>
    {
        public UsuarioIdentityManager(IUserStore<UsuarioIdentity, int> store,
            IIdentityMessageService sericoEmail) : base(store)
        {
            base.EmailService = sericoEmail;
        }
    }
}