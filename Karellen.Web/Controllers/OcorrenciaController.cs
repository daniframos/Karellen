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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using GeoJSON.Net.Feature;
using Microsoft.Practices.Unity;

namespace Karellen.Web.Controllers
{
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
        [OutputCache(NoStore = true, Duration = 0)]
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

            if (User.Identity.IsAuthenticated && !model.OcorrenciaAnonima)
            {
                ocorrencia.UsuarioId = User.Identity.GetUserId<int>();
            }
            var idOperacaoLog = Session[IdOperacao];
            var resultado = _servico.SalvarNovaOcorrencia(ocorrencia, idOperacaoLog);

            return RedirectToAction("index", "app", new {mensagem = EnumMensagem.OcorrenciaCriada});
        }

        [HttpGet]
        public ActionResult Coordenadas()
        {
            Response.AddHeader("Access-Control-Allow-Origin", "*");
            var ocorrencias = _servico.BuscarTodasOcorrencias();
            var f = new FeatureCollection();

            var c = ocorrencias.Select(o => new Feature(new Point(new GeographicPosition(o.Latitude, o.Longitude)), new {Nome = o.Titulo, Data = o.DataAcontecimento.ToString("D",DateTimeFormatInfo.CurrentInfo), Detalhes = o.Detalhes}));
            f.Features.AddRange(c);
            var coordenadasSerializadas = JsonConvert.SerializeObject(f, Formatting.Indented);

            return GeoJson(coordenadasSerializadas);
        }
    }
}