using AutoMapper;
using Karellen.Data.Entidade;
using Karellen.Web.AutoMapper;
using Karellen.Web.Identity.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Karellen.Teste.AutoMapper
{
    [TestClass()]
    public class GrupoProfileTests
    {
        [TestCategory("Automapper")]
        [TestMethod()]
        public void Grupo_Para_GrupoIdentityTest()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<GrupoProfile>();
                x.CreateMap<Grupo, GrupoIdentity>();
            });

            Mapper.AssertConfigurationIsValid();
        }

        [TestCategory("Automapper")]
        [TestMethod()]
        public void GrupoIdentity_Para_GrupoTest()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<GrupoIdentity, Grupo>();
                x.AddProfile<GrupoProfile>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}