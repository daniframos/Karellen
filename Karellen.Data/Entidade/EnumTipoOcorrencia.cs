using System.ComponentModel;

namespace Karellen.Data.Entidade
{
    public class TipoOcorrencia
    {
        public EnumTipoOcorrencia Tipo { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
        public int OcorrenciaId { get; set; }
    }
    public enum EnumTipoOcorrencia
    {
        [Description("Desacato")]
        Desacato,
        [Description("Furto")]
        Furto,
        [Description("Roubo")]
        Roubo,
        [Description("Homicidio")]
        Homicidio,
        [Description("Lesão Corporal")]
        LesaoCorporal,
        [Description("Tentativa de Homicidio")]
        TentativaHomicidio,
        [Description("Violência Doméstica")]
        ViolênciaDoméstica,
        [Description("Atentado Violento ao Pudor")]
        AtentadoViolento,
        [Description("Corrupção de Menor")]
        CorrupçãoMenor,
        [Description("Estupro")]
        Estupro,
        [Description("Embriaguez")]
        Embriaguez,
        [Description("Porte Ilegal de arma")]
        PorteIlegal,
        [Description("Acidente de Trânsito")]
        AcidenteTransito
    }
}
