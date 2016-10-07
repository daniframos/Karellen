using Karellen.Negocio.Interface;
using Karellen.Negocio.Mensagem.Enum;
using Karellen.Negocio.Util.Extensao;
using System.Web.Mvc;

namespace Karellen.Web.Controllers
{
    [Authorize]
    public class AppController : BaseController
    {
        private IAppServico _servico;

        public AppController(IAppServico servico)
        {
            _servico = servico;
        }

        // GET: App
        public ActionResult Index(EnumMensagem? mensagem)
        {
            if (mensagem != null)
                ViewBag.Mensagem = mensagem.GetDescricao();

            return View("Index");
        }
    }
}