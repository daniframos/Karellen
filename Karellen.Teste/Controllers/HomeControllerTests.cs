using Karellen.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace Karellen.Teste.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestCategory("View")]
        [TestMethod]
        public void Index_Retorna_View()
        {
            var controller = new HomeController();
            var view = controller.Index() as ViewResult;
            
            Assert.IsNotNull(view);
            Assert.AreEqual("Index", view.ViewName);
        }
    }
}