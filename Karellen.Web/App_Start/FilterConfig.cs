using Karellen.Data.Infraestrutura.UnitOfWork;
using Karellen.Web.Filtro;
using Karellen.Web.Identity.Manager;
using Karellen.Web.Identity.Servico;
using Karellen.Web.Identity.Store;
using System.Web.Mvc;

namespace Karellen.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new UsuarioFiltro(new UsuarioIdentityManager(new UsuarioIdentityStore(new UnitOfWork("KarellenConnectionString")), new EmailIdentityServico())));
        }
    }
}