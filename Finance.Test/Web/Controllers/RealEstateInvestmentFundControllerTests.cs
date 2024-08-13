using Finance.Domain;
using Finance.Service.Interface;
using Finance.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Finance.Tests.Web.Controllers
{
    public class RealEstateInvestmentFundControllerTests
    {
        private readonly Mock<IRealEstateInvestmentFundService> _mockService;
        private readonly RealEstateInvestmentFundController _controller;

        public RealEstateInvestmentFundControllerTests()
        {
            _mockService = new Mock<IRealEstateInvestmentFundService>();
            _controller = new RealEstateInvestmentFundController(_mockService.Object);
        }

        [Fact]
        public async Task Index_DeveRetornarViewResult_ComListaDeFiiAtivos()
        {
            // Arrange
            var mockItems = new List<Active> { new Active(), new Active() };
            _mockService.Setup(service => service.GetAllActiveFiiAsync()).ReturnsAsync(mockItems);

            // Act
            var resultado = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<IEnumerable<Active>>(viewResult.Model);
            Assert.Equal(2, modelo.Count());
        }

        [Fact]
        public void FirstArticle_DeveRetornarViewResult()
        {
            // Act
            var resultado = _controller.FirstArticle();

            // Assert
            Assert.IsType<ViewResult>(resultado);
        }

        [Fact]
        public async Task OrdenarPorPrecoDecrescente_DeveRetornarJsonResult_ComItensOrdenados()
        {
            // Arrange
            var mockItems = new List<Active>
            {
                new Active { Price = 10 },
                new Active { Price = 20 }
            };

            // Act
            var resultado = await _controller.OrderByDescendingPrice(mockItems);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(resultado);
            var itensOrdenados = Assert.IsAssignableFrom<IEnumerable<Active>>(jsonResult.Value);
            Assert.Equal(20, itensOrdenados.First().Price);
        }

        [Fact]
        public async Task Limpar_DeveRetornarJsonResult_ComListaDeFiiAtivos()
        {
            // Arrange
            var mockItems = new List<Active> { new Active(), new Active() };
            _mockService.Setup(service => service.GetAllActiveFiiAsync()).ReturnsAsync(mockItems);

            // Act
            var resultado = await _controller.Clean();

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(resultado);
            var modelo = Assert.IsAssignableFrom<IEnumerable<Active>>(jsonResult.Value);
            Assert.Equal(2, modelo.Count());
        }

        [Fact]
        public async Task RenderizarTabela_DeveRetornarPartialViewResult_ComModeloAtualizado()
        {
            // Arrange
            var mockItems = new List<Active> { new Active(), new Active() };

            // Act
            var resultado = await _controller.RenderTable(mockItems);

            // Assert
            var partialViewResult = Assert.IsType<PartialViewResult>(resultado);
            Assert.Equal("_TabelaFund", partialViewResult.ViewName);
            var modelo = Assert.IsAssignableFrom<IEnumerable<Active>>(partialViewResult.Model);
            Assert.Equal(2, modelo.Count());
        }
    }
}