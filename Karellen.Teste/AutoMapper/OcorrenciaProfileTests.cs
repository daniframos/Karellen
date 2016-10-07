using AutoMapper;
using Karellen.Negocio.Util.DTO;
using Karellen.Web.AutoMapper;
using Karellen.Web.Models.Ocorrencia;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Karellen.Teste.AutoMapper
{
    [TestClass()]
    public class OcorrenciaProfileTests
    {
        [TestMethod()]
        public void OcorrenciaProfileTest()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<OcorrenciaProfile>();
                x.CreateMap<NovaOcorrenciaVM, OcorrenciaDTO>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}