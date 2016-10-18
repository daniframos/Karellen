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

            ViewBag.Acao = "Nova";

            return RedirectToAction("index", "app", new {mensagem = EnumMensagem.OcorrenciaCriada});
        }

        [HttpGet]
        public ActionResult Coordenadas()
        {
            var ocorrencias = _servico.BuscarTodasOcorrencias();
            var featureCollection = new FeatureCollection();

            var c = ocorrencias.Select(o =>
                new Feature
                (new Point
                    (new GeographicPosition(o.Latitude, o.Longitude)), new
                {
                    UsuarioId = User.Identity.GetUserId<int>() == o.UsuarioId ? o.UsuarioId : null,
                    o.Id,
                    Nome = o.Titulo,
                    Data = o.DataAcontecimento.ToString("D", DateTimeFormatInfo.CurrentInfo),
                    o.Detalhes
                }));

            featureCollection.Features.AddRange(c);
            var coordenadasSerializadas = JsonConvert.SerializeObject(featureCollection, Formatting.Indented);

            return GeoJson(coordenadasSerializadas);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Coordenada(int id)
        {
            var ocorrencia = _servico.BuscarOcorrencia(id);
            var featureCollection = new FeatureCollection();

            var c = new Feature
                (new Point (new GeographicPosition(ocorrencia.Latitude, ocorrencia.Longitude)), new
                    {
                        UsuarioId = User.Identity.GetUserId<int>() == ocorrencia.UsuarioId ? ocorrencia.UsuarioId : null,
                    ocorrencia.Id,
                        Nome = ocorrencia.Titulo,
                        Data = ocorrencia.DataAcontecimento.ToString("D", DateTimeFormatInfo.CurrentInfo),
                    ocorrencia.Detalhes
                    });

            featureCollection.Features.Add(c);
            var coordenadasSerializadas = JsonConvert.SerializeObject(featureCollection, Formatting.Indented);

            return GeoJson(coordenadasSerializadas);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Detalhes(int id)
        {
            var ocorrencia = _servico.BuscarOcorrencia(id);
            var model = Mapper.Map<OcorrenciaDTO, NovaOcorrenciaVM>(ocorrencia);
            var autor = _servico.BuscarAutorOcorrencia(id);

            ViewBag.Autor = autor == null ? "Ocorrência Anônima" : autor.NomeCompleto;
            ViewBag.AutorId = autor?.Id;

            return View("Detalhes", model);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var ocorrencia = _servico.BuscarOcorrencia(id);
            var model = Mapper.Map<OcorrenciaDTO, NovaOcorrenciaVM>(ocorrencia);
            model.OcorrenciaAnonima = ocorrencia.UsuarioId == null;
            ViewBag.Acao = "Editar";
            return View("Nova", model);
        }

        [HttpPost]
        public ActionResult Editar(NovaOcorrenciaVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Nova");
            }

            return RedirectToAction("index", "app", new {mensagem = EnumMensagem.Alterado});
        }

        [HttpPost]
        public ActionResult Solucionar(int id)
        {
            var o = _servico.BuscarOcorrencia(id);
            if (o.UsuarioId != User.Identity.GetUserId<int>())
            {
                return View();
            }

            _servico.SolucionarOcorrencia(id);

            return RedirectToAction("index", "app", new {mensagem = EnumMensagem.Alterado});
        }
    }
}