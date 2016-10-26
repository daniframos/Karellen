using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Karellen.Negocio.Util.DTO;
using Karellen.Web.Models.Estatistica;

namespace Karellen.Web.AutoMapper
{
    public class OcorrenciaMensalProfile: Profile
    {
        public OcorrenciaMensalProfile()
        {
            CreateMap<OcorrenciaMensalVM, OcorrenciaMensalDTO>();
            CreateMap<OcorrenciaMensalDTO, OcorrenciaMensalVM>();
        }
    }
}