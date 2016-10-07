using Karellen.Core.Dominio.Entidade;
using Karellen.Data.Entidade;
using Karellen.Negocio.Mensagem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Karellen.Web.Models.Ocorrencia
{
    public class NovaOcorrenciaVM
    {
        public int Id { get; set; }
        [Required]
        [DisplayName(@"Título")]
        [MaxLength(30, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MN019")]
        public string Titulo { get; set; }
        [Required]
        [DisplayName(@"Data e Hora")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd h:mm:ss tt}")]
        public DateTime DataAcontecimento { get; set; }
        [DisplayName(@"Tipo de Ocorrência")]
        public ICollection<TipoOcorrencia> TipoOcorrencias { get; set; }
        [DisplayName(@"Sexo da Vítima")]
        public Sexo SexoVitima { get; set; }
        public string Detalhes { get; set; }
        [DisplayName(@"Fez Boletim de Ocorrência")]
        public bool? TemBoletimOCorrencia { get; set; }
        [DisplayName(@"Autor")]
        public bool OcorrenciaAnonima { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]
        public string Longitude { get; set; }

        private Guid _sessaoId;
        public Guid SessaoId
        {
            get { return _sessaoId == default(Guid) ? Guid.NewGuid() : _sessaoId; }
            set { _sessaoId = value; }
        }
    }
}