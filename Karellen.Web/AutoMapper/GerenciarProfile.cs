using AutoMapper;
using Karellen.Web.Identity.Modelo;
using Karellen.Web.Models.Conta;

namespace Karellen.Web.AutoMapper
{
    public class GerenciarProfile: Profile
    {
        public GerenciarProfile()
        {
            CreateMap<GerenciarVM, UsuarioIdentity>()
                .ForMember(dest => dest.PasswordHash, src => src.Ignore())
                .ForMember(dest => dest.UserName, src => src.Ignore())
                .ForMember(dest => dest.Id, src => src.Ignore());

            CreateMap<UsuarioIdentity, GerenciarVM>();
        }
    }
}