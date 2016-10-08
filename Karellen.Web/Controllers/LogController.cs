using AutoMapper;
using Karellen.Negocio.Interface;
using Karellen.Negocio.Util.DTO;
using Karellen.Web.Models.Log;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Karellen.Web.Controllers
{
    public class LogController : BaseController
    {
        private readonly ILogServico _servico;

        public LogController(ILogServico servico)
        {
            _servico = servico;
        }
        // GET: Log
        public ActionResult Index(int pagina = 1)
        {
            var logdto = _servico.BuscarTodosLog();
            var model = Mapper.Map<IEnumerable<LogDTO>, IEnumerable<LogVM>>(logdto);

            model = model.ToPagedList(pagina, 12);

            return View((IPagedList<LogVM>)model);
        }
    }
}
