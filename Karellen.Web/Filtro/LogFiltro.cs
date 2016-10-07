using Karellen.Negocio.Interface;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Karellen.Web.Filtro
{
    public class Log: ActionFilterAttribute
    {
        private readonly IOcorrenciaServico _servico;
        public string IdOperacao { get; set; }

        public Log()
        {
            _servico = DependencyResolver.Current.GetService<IOcorrenciaServico>();
            IdOperacao = "IdOperacao";
        }

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
            filterContext.HttpContext.Session[IdOperacao] = _servico.SalvarOperacao(userAgent, usuario, browser, ip, local, sessaoId, null, null);
        }      
    }
}