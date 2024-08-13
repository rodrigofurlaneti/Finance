using Finance.Domain;
using Finance.Service.Interface;
using Finance.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Finance.Tests.Web.Controllers
{
    public class BrazilianDepositaryReceiptsControllerTests
    {
        private readonly Mock<IBrazilianDepositaryReceiptsService> _mockService;
        private readonly BrazilianDepositaryReceiptsController _controller;

        public BrazilianDepositaryReceiptsControllerTests()
        {
            _mockService = new Mock<IBrazilianDepositaryReceiptsService>();
            _controller = new BrazilianDepositaryReceiptsController(_mockService.Object);
        }

        [Fact]
        public async Task Index_DeveRetornarViewResult_ComListaDeBdrsAtivos()
        {
            // Arrange
            var mockItems = new List<Active> { new Active(), new Active() };
            _mockService.Setup(service => service.GetAllActiveBdrAsync()).ReturnsAsync(mockItems);

            // Act
            var resultado = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<IEnumerable<Active>>(viewResult.Model);
            Assert.Equal(2, modelo.Count());
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
        public async Task OrdenarPorPrecoCrescente_DeveRetornarJsonResult_ComItensOrdenados()
        {
            // Arrange
            var mockItems = new List<Active>
            {
                new Active { Price = 10 },
                new Active { Price = 20 }
            };

            // Act
            var resultado = await _controller.OrderByAscendingPrice(mockItems);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(resultado);
            var itensOrdenados = Assert.IsAssignableFrom<IEnumerable<Active>>(jsonResult.Value);
            Assert.Equal(10, itensOrdenados.First().Price);
        }

        [Fact]
        public async Task OrdenarPorVariacaoPercentualUltimoDiaDecrescente_DeveRetornarJsonResult_ComItensOrdenados()
        {
            // Arrange
            var mockItems = new List<Active>
            {
                new Active { ChangePercent = 1.5m },
                new Active { ChangePercent = 2.0m }
            };

            // Act
            var resultado = await _controller.OrderByDescendingChangeLastDay(mockItems);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(resultado);
            var itensOrdenados = Assert.IsAssignableFrom<IEnumerable<Active>>(jsonResult.Value);
            Assert.Equal(2.0m, itensOrdenados.First().ChangePercent);
        }

        [Fact]
        public async Task Limpar_DeveRetornarJsonResult_ComTodosOsBdrsAtivos()
        {
            // Arrange
            var mockItems = new List<Active> { new Active(), new Active() };
            _mockService.Setup(service => service.GetAllActiveBdrAsync()).ReturnsAsync(mockItems);

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
            Assert.Equal("_TabelaBrazilian", partialViewResult.ViewName);
            var modelo = Assert.IsAssignableFrom<IEnumerable<Active>>(partialViewResult.Model);
            Assert.Equal(2, modelo.Count());
        }
    }
}
