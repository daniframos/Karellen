using AutoMapper;
using GeoJSON.Net.Geometry;
using Karellen.Negocio.Interface;
using Karellen.Negocio.Mensagem.Enum;
using Karellen.Negocio.Util.DTO;
using Karellen.Web.Filtro;
using Karellen.Web.Models.Ocorrencia;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Karellen.Web.Controllers
{
    [Authorize]
    public class OcorrenciaController : BaseController
    {
        private readonly IOcorrenciaServico _servico;

        public string IdOperacao { get; set; }

        public OcorrenciaController(IOcorrenciaServico servico)
        {
            _servico = servico;
            IdOperacao = "IdOperacao";
        }


        [AllowAnonymous]
        public ActionResult Nova()
        {
            return View("Nova", new NovaOcorrenciaVM());
        }

        [Log]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Nova(NovaOcorrenciaVM model)
        {   
            if (!ModelState.IsValid) return View("Nova");

            var ocorrencia = Mapper.Map<NovaOcorrenciaVM, OcorrenciaDTO>(model);

            if (User.Identity.IsAuthenticated)
            {
                ocorrencia.UsuarioId = Convert.ToInt32(User.Identity.GetUserId());
            }
            var idOperacaoLog = Session[IdOperacao];
            var resultado = _servico.SalvarNovaOcorrencia(ocorrencia, idOperacaoLog);

            return RedirectToAction("index", "app", new {mensagem = EnumMensagem.OcorrenciaCriada});
        }

        public ActionResult Coordenadas()
        {
            var ocorrencias = _servico.BuscarTodasOcorrencias();

            var coordenadas = ocorrencias.Select(o => new GeographicPosition(o.Latitude, o.Longitude)).ToList();
            var pontos = coordenadas.Select(e => new Point(e));
            var coordenadasSerializadas = JsonConvert.SerializeObject(pontos, Formatting.Indented);

            return GeoJson(coordenadasSerializadas);
        }
    }
}