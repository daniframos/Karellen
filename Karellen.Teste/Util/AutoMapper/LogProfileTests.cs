using AutoMapper;
using Karellen.Core.Dominio.Entidade;
using Karellen.Negocio.Util.AutoMapper;
using Karellen.Negocio.Util.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Karellen.Teste.Util.AutoMapper
{
    [TestClass()]
    public class LogProfileTests
    {
        [TestMethod()]
        public void LogProfileTest()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<LogProfile>();
                x.CreateMap<Log, LogDTO>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}