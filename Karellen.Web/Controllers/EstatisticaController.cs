using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Karellen.Negocio.Interface;
using Karellen.Negocio.Servico;
using Karellen.Negocio.Util.DTO;
using Karellen.Web.Models.Estatistica;
using Microsoft.AspNet.Identity;

namespace Karellen.Web.Controllers
{
    public class EstatisticaController : BaseController
    {
        private readonly IOcorrenciaServico _servico;

        public EstatisticaController(IOcorrenciaServico servico)
        {
            _servico = servico;
        }

        public ActionResult Index()
        {
            var r = _servico.BuscarEstatisticas();
            var model = Mapper.Map<EstatisticaDTO, EstatisticaVM>(r);
            return View("index",model);
        }
    }
}