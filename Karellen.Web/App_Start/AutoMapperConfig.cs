using AutoMapper;
using Karellen.Web.AutoMapper;

namespace Karellen.Web
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<GrupoProfile>();
                x.AddProfile<UsuarioProfile>();
                x.AddProfile<OcorrenciaProfile>();
                x.AddProfile<LogProfile>();

                x.AddProfile<Karellen.Negocio.Util.AutoMapper.OcorrenciaProfile>();
                x.AddProfile<Karellen.Negocio.Util.AutoMapper.LogProfile>();
            });
        }
    }
}