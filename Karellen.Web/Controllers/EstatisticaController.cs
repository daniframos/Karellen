using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karellen.Negocio.Interface;
using Karellen.Negocio.Servico;
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
        // GET: Estatistica
        public ActionResult SuasEstatisticas()
        {
            var ocorrencias = _servico.BuscarTodasOcorrencias(User.Identity.GetUserId<int>());
            return Content(ocorrencias.Count.ToString());
        }
    }
}