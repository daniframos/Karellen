using System.Collections.Generic;

namespace Karellen.Negocio.Util.DTO
{
    public class EstatisticaDTO
    {

        public int QuantidadeOcorrencias { get; set; }
        public int QuantidadeOcorrenciasAnonimas { get; set; }
        public int QuantidadeOcorrenciasNaoAnonimas { get; set; }
        public int QuantidadeOcorrenciasUsuario { get; set; }
        public int QuantidadeOcorrenciasSexoMasculino { get; set; }
        public int QuantidadeOcorrenciasSexoFeminino { get; set; }
        public ICollection<OcorrenciaMensalDTO> OcorrenciasUltimos6Meses { get; set; }
    }
}