using AutoMapper;
using Karellen.Negocio.Util.DTO;
using Karellen.Web.Models.Log;

namespace Karellen.Web.AutoMapper
{
    public class LogProfile: Profile
    {
        public LogProfile()
        {
            CreateMap<LogVM, LogDTO>();
            CreateMap<LogDTO, LogVM>();
        }
    }
}