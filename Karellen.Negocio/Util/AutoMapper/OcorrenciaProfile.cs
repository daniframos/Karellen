using System.Linq;
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
                .ForMember(dest => dest.TipoOcorrencias, src => src.MapFrom(s => s.TipoOcorrencias.Select(t => t.Tipo)))
                .ForMember(dest => dest.Situacao, src => src.Ignore());

            CreateMap<OcorrenciaDTO, Ocorrencia>()
                .ForMember(dest => dest.TipoOcorrencias,src => src.MapFrom(s => s.TipoOcorrencias.Select(tp => new TipoOcorrencia()
                {
                    Tipo = tp
                })))
                .ForMember(dest => dest.Usuario, src => src.Ignore())
                .ForMember(dest => dest.DataCriacao, src => src.Ignore());
        }
    }
}
