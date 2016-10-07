using System.ComponentModel;

namespace Karellen.Data.Entidade
{
    public enum TipoOcorrencia
    {
        [Description("Furto em veículo")]
        FurtoVeiculo,
        [Description("Roubo de veículo")]
        RouboVeiculo,
        [Description("Roubo a transeunte")]
        RouboTRanseunte,
        [Description("Roubo em coletivo")]
        RouboColetivo,
        [Description("Roubo em comércio")]
        RouboComercio,
        [Description("CCP agregado")]
        CcpAgregado,
        [Description("Homicidio")]
        Homicidio,
        [Description("Latrocínio")]
        Latrocinio,
        [Description("Lesão seguida de morte")]
        LesaoSeguidaPorMorte,
        [Description("CVLI agregado")]
        Cvli
    }
}
