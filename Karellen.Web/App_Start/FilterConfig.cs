using Karellen.Web.Filtro;
using Karellen.Web.Identity.Manager;
using Microsoft.Practices.Unity;
using System.Web.Mvc;

namespace Karellen.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new UsuarioFiltro());
        }
    }
}