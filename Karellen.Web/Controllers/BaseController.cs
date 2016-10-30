using System.Globalization;
using System.Web.Mvc;
using System.Web.Routing;

namespace Karellen.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var culture = new CultureInfo("pt-BR");
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
        }

        protected ContentResult GeoJson(string data)
        {
            return Content(data, "application/json");
        }
    }
}