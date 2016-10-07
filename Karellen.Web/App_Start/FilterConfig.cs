using Karellen.Web.Filtro;
using System.Web.Mvc;

namespace Karellen.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(DependencyResolver.Current.GetService<UsuarioFiltro>());
        }
    }
}