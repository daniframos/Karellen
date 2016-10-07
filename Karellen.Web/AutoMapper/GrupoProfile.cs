using AutoMapper;
using Karellen.Data.Entidade;
using Karellen.Web.Identity.Modelo;

namespace Karellen.Web.AutoMapper
{
    public class GrupoProfile : Profile
    {
        public GrupoProfile()
        {
            CreateMap<Grupo, GrupoIdentity>()
                .ForMember(src => src.Name, dest => dest.MapFrom(d => d.Nome));

            CreateMap<GrupoIdentity, Grupo>()
                .ForMember(src => src.Nome, dest => dest.MapFrom(d => d.Name))
                .ForMember(src => src.Usuarios, dest => dest.Ignore());
        }
    }
}