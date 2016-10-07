using Karellen.Data.Contexto;
using Karellen.Data.Infraestrutura.UnitOfWork;
using Karellen.Negocio.Servico;
using Karellen.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;

namespace Karellen.Teste.Controllers
{
    [TestClass()]
    public class AppControllerTests
    {
        private Mock<KarellenContexto> _mockContext;

        [TestInitialize]
        public void AppControllerTestsInitialize()
        {
            _mockContext = new Mock<KarellenContexto>("ConnectionString");
        }

        [TestCategory("View")]
        [TestMethod()]
        public void Index_Retorna_View()
        {
            var controller = new AppController(new AppServico(new UnitOfWork(_mockContext.Object)));
            var view = controller.Index(null) as ViewResult;

            Assert.IsNotNull(view);
            Assert.AreEqual("Index", view.ViewName);
        }
    }
}