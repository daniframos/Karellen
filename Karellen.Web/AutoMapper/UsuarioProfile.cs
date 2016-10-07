using AutoMapper;
using Karellen.Data.Entidade;
using Karellen.Web.Identity.Modelo;

namespace Karellen.Web.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioIdentity>()
                .ForMember(dest => dest.PasswordHash, src => src.MapFrom(d => d.SenhaHash));

            CreateMap<UsuarioIdentity, Usuario>()
                .ForMember(dest => dest.SenhaHash, src => src.MapFrom(s => s.PasswordHash))
                .ForMember(dest => dest.Logins, src => src.Ignore())
                .ForMember(dest => dest.Ocorrencias, src => src.Ignore())
                .ForMember(dest => dest.Grupos, src => src.Ignore());
        }
    }
}