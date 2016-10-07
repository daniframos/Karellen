using System.Web.Mvc;

namespace Karellen.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ContentResult GeoJson(string data)
        {
            return Content(data, "application/json");
        }
    }
}