using AutoMapper;
using Karellen.Negocio.Util.DTO;
using Karellen.Web.Models.Ocorrencia;

namespace Karellen.Web.AutoMapper
{
    public class OcorrenciaProfile: Profile
    {
        public OcorrenciaProfile()
        {
            CreateMap<NovaOcorrenciaVM, OcorrenciaDTO>()
                .ForMember(dest => dest.Situacao, src => src.Ignore())
                .ForMember(dest => dest.HaBoletimDeOcorrencia, src => src.MapFrom(s => s.TemBoletimOCorrencia))
                .ForMember(dest => dest.DataResolucao, src => src.Ignore())
                .ForMember(dest => dest.Excluida, src => src.Ignore())
                .ForMember(dest => dest.UsuarioId, src => src.Ignore());
            CreateMap<OcorrenciaDTO, NovaOcorrenciaVM>()
                .ForMember(dest => dest.SessaoId , src => src.Ignore())
                .ForMember(dest => dest.OcorrenciaAnonima, src => src.Ignore())
                .ForMember(dest => dest.Latitude, src => src.MapFrom(s => s.Latitude))
                .ForMember(dest => dest.Longitude, src => src.MapFrom(s => s.Longitude))
                .ForMember(dest => dest.TemBoletimOCorrencia, src => src.MapFrom(s => s.HaBoletimDeOcorrencia));
        }
    }
}