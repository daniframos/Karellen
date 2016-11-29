using Karellen.Core.Dominio.Entidade;
using System;
using System.Collections.Generic;

namespace Karellen.Data.Entidade
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataAcontecimento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataResolucao { get; set; }
        public string Resolucao { get; set; }
        public bool Excluida { get; set; }
        public Sexo SexoVitima { get; set; }
        public string Detalhes { get; set; }
        public bool? HaBoletimDeOcorrencia { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public ICollection<TipoOcorrencia> TipoOcorrencias { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int? UsuarioId { get; set; }
    }
}
