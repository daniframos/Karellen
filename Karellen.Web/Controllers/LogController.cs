using AutoMapper;
using Karellen.Negocio.Interface;
using Karellen.Negocio.Util.DTO;
using Karellen.Web.Models.Log;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Karellen.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
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

            ViewBag.Total = model.ToList().Count;

            ViewBag.UltimoDia = _servico.QuantidadeDeLog(DateTime.Now.AddDays(-1));
            ViewBag.UltimoMes = _servico.QuantidadeDeLog(DateTime.Now.AddMonths(-1));

            model = model.ToPagedList(pagina, 12);

            return View((IPagedList<LogVM>)model);
        }

        public ActionResult Detalhes(int id)
        {
            var logdto = _servico.BuscarLog(id);
            var model = Mapper.Map<LogDTO, LogVM>(logdto);
            
            return View("Detalhes", model);
        }
    }
}
