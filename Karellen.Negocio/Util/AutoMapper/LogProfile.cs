using AutoMapper;
using Karellen.Core.Dominio.Entidade;
using Karellen.Negocio.Util.DTO;

namespace Karellen.Negocio.Util.AutoMapper
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<Log, LogDTO>();
            CreateMap<LogDTO, Log>();
        }
    }
}
