using Karellen.Core.Dominio.Entidade;
using Karellen.Data.Entidade;
using System;
using System.Collections.Generic;

namespace Karellen.Negocio.Util.DTO
{
    // ReSharper disable once InconsistentNaming
    public class OcorrenciaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataAcontecimento { get; set; }
        public DateTime? DataResolucao { get; set; }
        public bool Excluida { get; set; }
        public Situacao Situacao { get; set; }
        public Sexo SexoVitima { get; set; }
        public string Detalhes { get; set; }
        public bool? HaBoletimDeOcorrencia { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public ICollection<TipoOcorrencia> TipoOcorrencias { get; set; }

        public int? UsuarioId { get; set; }
    }
}
