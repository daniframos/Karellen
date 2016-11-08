using Karellen.Web.Identity.Manager;
using Microsoft.AspNet.Identity;
using System.Web.Mvc.Filters;

namespace Karellen.Web.Filtro
{
    public class UsuarioFiltro : IAuthenticationFilter
    {
        private readonly UsuarioIdentityManager _manager;
        private const string NomeUsuario = "NomeUsuario";

        public UsuarioFiltro(UsuarioIdentityManager manager)
        {
            _manager = manager;
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!filterContext.Principal.Identity.IsAuthenticated) return;
            
            var userName = filterContext.Principal.Identity.Name;
            var u = _manager.FindByName(userName);

            filterContext.HttpContext.Session[NomeUsuario] = u.Nome;
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}