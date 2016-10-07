using AutoMapper;
using Karellen.Data.Entidade;
using Karellen.Negocio.Util.DTO;

namespace Karellen.Negocio.Util.AutoMapper
{
    public class OcorrenciaProfile: Profile
    {
        public OcorrenciaProfile()
        {
            CreateMap<Ocorrencia, OcorrenciaDTO>()
                .ForMember(dest => dest.Situacao, src => src.Ignore());

            CreateMap<OcorrenciaDTO, Ocorrencia>()
                .ForMember(dest => dest.Usuario, src => src.Ignore())
                .ForMember(dest => dest.DataCriacao, src => src.Ignore());
        }
    }
}
