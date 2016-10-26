using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Karellen.Web.Models.Estatistica
{
    public class EstatisticaVM
    {
        public int QuantidadeOcorrencias { get; set; }
        public int QuantidadeOcorrenciasAnonimas { get; set; }
        public int QuantidadeOcorrenciasNaoAnonimas { get; set; }
        public int QuantidadeOcorrenciasUsuario { get; set; }
        public int QuantidadeOcorrenciasSexoMasculino { get; set; }
        public int QuantidadeOcorrenciasSexoFeminino { get; set; }
        public ICollection<OcorrenciaMensalVM> OcorrenciasUltimos6Meses { get; set; }

        public string PorcentagemAnonima
        {
            get
            {
                return ((double)QuantidadeOcorrenciasAnonimas/QuantidadeOcorrencias*100.00).ToString("0.00");
            }
        }

        public string PorcentagemNaoAnonima
        {
            get
            {
                return ((double)QuantidadeOcorrenciasNaoAnonimas/ QuantidadeOcorrencias * 100.00).ToString("0.00");
            }
        }

        public string PorcentagemFeminina
        {
            get
            {
                return ((double)QuantidadeOcorrenciasSexoFeminino / QuantidadeOcorrencias * 100.00).ToString("0.00");
            }
        }

        public string PorcentagemMasculina
        {
            get
            {
                return ((double)QuantidadeOcorrenciasSexoMasculino / QuantidadeOcorrencias * 100.00).ToString("0.00");
            }
        }
    }
}