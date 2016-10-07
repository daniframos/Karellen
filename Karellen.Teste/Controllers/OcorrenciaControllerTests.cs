using Karellen.Data.Contexto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Karellen.Teste.Controllers
{
    [TestClass()]
    public class OcorrenciaControllerTests
    {
        private Mock<KarellenContexto> _mockContext;

        [TestInitialize]
        public void AppControllerTestsInitialize()
        {
            _mockContext = new Mock<KarellenContexto>("ConnectionString");
        }
    }
}