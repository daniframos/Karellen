using Karellen.Data.Contexto;
using Karellen.Data.Infraestrutura.UnitOfWork;
using Karellen.Web.Controllers;
using Karellen.Web.Identity.Manager;
using Karellen.Web.Identity.Servico;
using Karellen.Web.Identity.Store;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;

namespace Karellen.Teste.Controllers
{
    [TestClass()]
    public class ContaControllerTests
    {
        private Mock<KarellenContexto> _mockContext;

        [TestInitialize]
        public void AppControllerTestsInitialize()
        {
            _mockContext = new Mock<KarellenContexto>("ConnectionString");
        }

        [TestCategory("View")]
        [TestMethod()]
        public void Login_Retorna_Tela_Login()
        {
            var unitOfWork = new UnitOfWork(_mockContext.Object);
            var store = new UsuarioIdentityStore(unitOfWork);
            var controller = new ContaController(new UsuarioIdentityManager(store, new EmailIdentityServico()));

            var view = controller.Login(mensagem: null, returnUrl: null) as ViewResult;

            Assert.IsNotNull(view);
            Assert.AreEqual(view.ViewName, "login");
        }
    }
}