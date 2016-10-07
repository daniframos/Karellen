using Karellen.Web.Identity.Manager;
using Microsoft.AspNet.Identity;
using System.Web.Mvc.Filters;

namespace Karellen.Web.Filtro
{
    public class UsuarioFiltro : IAuthenticationFilter
    {
        private readonly string _nomeUsuario = "NomeUsuario";
        private readonly UsuarioIdentityManager _usuarioManger;

        public UsuarioFiltro(UsuarioIdentityManager usuarioManager)
        {
            _usuarioManger = usuarioManager;
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!filterContext.Principal.Identity.IsAuthenticated) return;

            if (filterContext.HttpContext.Session != null)
            {
                var nomeUsuario = filterContext.HttpContext.Session[_nomeUsuario] as string;

                if (!string.IsNullOrEmpty(nomeUsuario)) return;
            }

            var userName = filterContext.Principal.Identity.Name;
            var u = _usuarioManger.FindByName(userName);

            filterContext.HttpContext.Session[_nomeUsuario] = u.Nome;
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}