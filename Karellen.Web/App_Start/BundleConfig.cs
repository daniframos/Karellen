using System.Web.Optimization;

namespace Karellen.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css")
                .Include("~/Content/font-awesome/css/font-awesome.css")
                .Include("~/Content/nprogress/nprogress.css")
                .Include("~/Content/bootstrap/dist/css/bootstrap.css")
                .Include("~/Content/chosen/chosen.css")
                .Include("~/Content/datetimepicker/build/css/bootstrap-datetimepicker.css")
                .Include("~/Content/leaflet/dist/leaflet.css")
                .Include("~/Content/pagedlist/css/pagedlist.css")
                .Include("~/Content/leaflet-draw/dist/leaflet.draw.css")
                .Include("~/Content/karellen/css/site.css"));

            bundles.Add(new ScriptBundle("~/js")
                .Include("~/Content/jquery/dist/jquery.js")
                .Include("~/Content/bootstrap/dist/js/bootstrap.js")
                .Include("~/Content/moment/moment.js")
                .Include("~/Content/moment/locale/pt-br.js")
                .Include("~/Content/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js")
                .Include("~/Content/datetimepicker/build/js/bootstrap-datetimepicker.min.js")
                .Include("~/Content/jquery-ajax-unobtrusive/jquery.unobtrusive-ajax.js")
                .Include("~/Content/chosen/chosen.jquery.js")
                .Include("~/Content/nprogress/nprogress.js")
                .Include("~/Content/leaflet/dist/leaflet.js")
                .Include("~/Content/leaflet-draw/dist/leaflet.draw.js")
                .Include("~/Content/jquery-pjax/jquery.pjax.js")
                .Include("~/Content/karellen/js/Global/global.js"));
        }
    }
}