using Finance.Domain;
using Finance.Service.Interface;
using Finance.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Finance.Tests.Web.Controllers
{
    public class AllStockExchangeControllerTests
    {
        private readonly Mock<IAllStockExchangeService> _mockService;
        private readonly AllStockExchangeController _controller;

        public AllStockExchangeControllerTests()
        {
            _mockService = new Mock<IAllStockExchangeService>();
            _controller = new AllStockExchangeController(_mockService.Object);
        }

        [Fact]
        public async Task Index_DeveRetornarViewResult_ComListaDeAtivos()
        {
            // Arrange
            var mockItems = new List<Active> { new Active(), new Active() };
            _mockService.Setup(service => service.GetAllActiveAsync()).ReturnsAsync(mockItems);

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

        // Mais testes para os outros métodos de ordenação...

        [Fact]
        public async Task Limpar_DeveRetornarJsonResult_ComTodosOsAtivos()
        {
            // Arrange
            var mockItems = new List<Active> { new Active(), new Active() };
            _mockService.Setup(service => service.GetAllActiveAsync()).ReturnsAsync(mockItems);

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
            Assert.Equal("_TabelaAllStock", partialViewResult.ViewName);
            var modelo = Assert.IsAssignableFrom<IEnumerable<Active>>(partialViewResult.Model);
            Assert.Equal(2, modelo.Count());
        }
    }
}
