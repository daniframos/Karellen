using Karellen.Negocio.Interface;
using Microsoft.Practices.Unity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Karellen.Web.Filtro
{
    public class Log: ActionFilterAttribute
    {
        [Dependency]
        public IOcorrenciaServico Servico { get; set; }
        private const string IdOperacao = "IdOperacao";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userAgent = filterContext.RequestContext.HttpContext.Request.UserAgent;
            var usuario = filterContext.RequestContext.HttpContext.User.Identity.Name ?? "Usuário Anônimo";
            var browser = filterContext.RequestContext.HttpContext.Request.Browser.Browser;
            var ip = filterContext.RequestContext.HttpContext.Request.UserHostAddress;

            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            var local = filterContext.RequestContext.HttpContext.Request.UrlReferrer.ToString();
            var sessaoId = new Guid(filterContext.RequestContext.HttpContext.Request.Form.GetValues("SessaoId").FirstOrDefault());
            // TODO: Salvar
            filterContext.HttpContext.Session[IdOperacao] = Servico.SalvarOperacao(userAgent, usuario, browser, ip, local, sessaoId, null, null);
        }      
    }
}