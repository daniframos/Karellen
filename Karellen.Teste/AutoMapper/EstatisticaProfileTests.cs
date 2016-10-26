using AutoMapper;
using Karellen.Data.Entidade;
using Karellen.Negocio.Util.DTO;
using Karellen.Web.AutoMapper;
using Karellen.Web.Identity.Modelo;
using Karellen.Web.Models.Estatistica;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Karellen.Teste.AutoMapper
{
    [TestClass()]
    public class EstatisticaProfileTests
    {
        [TestCategory("Automapper")]
        [TestMethod()]
        public void EstatisticaVM_Para_EstatisticaDTO()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<OcorrenciaMensalProfile>();
                x.AddProfile<EstatisticaProfile>();
                x.CreateMap<EstatisticaVM, EstatisticaDTO>();
            });

            Mapper.AssertConfigurationIsValid();
        }

        [TestCategory("Automapper")]
        [TestMethod()]
        public void EstatisticaDTO_Para_EstatisticaVM()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<OcorrenciaMensalProfile>();
                x.AddProfile<EstatisticaProfile>();
                x.CreateMap<EstatisticaDTO, EstatisticaVM>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}