using Karellen.Negocio.Util.Atributo;

namespace Karellen.Negocio.Mensagem.Enum
{
    public enum EnumMensagem
    {
        [DescricaoAtributo("MN013", typeof(Mensagem))]
        ContaCriada,
        [DescricaoAtributo("MN017", typeof(Mensagem))]
        Erro,
        [DescricaoAtributo("MN020", typeof(Mensagem))]
        OcorrenciaCriada,
        [DescricaoAtributo("MN021", typeof(Mensagem))]
        Alterado,
        [DescricaoAtributo("MN022", typeof(Mensagem))]
        ErroPermissao
    }
}
