using Karellen.Web.Identity.Manager;
using Microsoft.AspNet.Identity;
using System.Web.Mvc.Filters;
using Karellen.Data.Interface.UnitOfWork;
using Microsoft.Practices.Unity;

namespace Karellen.Web.Filtro
{
    public class UsuarioFiltro : IAuthenticationFilter
    {
        
        private const string NomeUsuario = "NomeUsuario";

        public UsuarioFiltro()
        {
          
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var userName = filterContext.Principal.Identity.Name;
            var container = UnityConfig.GetConfiguredContainer() as UnityContainer;
            var unitOfWork = container.Resolve<IUnitOfWork>();

            var u = unitOfWork.RepositorioUsuario.BuscarPorUserName(userName);
            if (u != null)
                filterContext.HttpContext.Session[NomeUsuario] = u.Nome;
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}