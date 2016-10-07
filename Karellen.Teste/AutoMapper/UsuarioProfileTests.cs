using AutoMapper;
using Karellen.Data.Entidade;
using Karellen.Web.AutoMapper;
using Karellen.Web.Identity.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Karellen.Teste.AutoMapper
{
    [TestClass()]
    public class UsuarioProfileTests
    {
        [TestCategory("Automapper")]
        [TestMethod()]
        public void UsuarioIdentity_Para_Usuario()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<UsuarioProfile>();
                x.CreateMap<UsuarioIdentity, Usuario>();
            });

            Mapper.AssertConfigurationIsValid();
        }
        [TestCategory("Automapper")]
        [TestMethod()]
        public void UsuarioIdentity_Para_Usuario_Com_Senha()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<UsuarioProfile>();
                x.CreateMap<UsuarioIdentity, Usuario>();
            });

            var usuario = new UsuarioIdentity()
            {
                PasswordHash = "SenhaHash"
            };
            var r = Mapper.Map<UsuarioIdentity, Usuario>(usuario);

            Mapper.AssertConfigurationIsValid();
            Assert.IsNotNull(r);
            Assert.AreEqual(usuario.PasswordHash, r.SenhaHash);
        }
    }
}