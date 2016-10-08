using AutoMapper;
using Karellen.Web.AutoMapper;
using Karellen.Web.Identity.Modelo;
using Karellen.Web.Models.Conta;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Karellen.Teste.AutoMapper
{
    [TestClass()]
    public class GerenciarProfileTests
    {
        [TestCategory("Automapper")]
        [TestMethod()]
        public void Grupo_Para_GrupoIdentityTest()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<GerenciarProfile>();
                x.CreateMap<GerenciarVM,UsuarioIdentity>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}