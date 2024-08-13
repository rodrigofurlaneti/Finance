using Finance.Domain;
using Finance.Service.Interface;
using Finance.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Tests.Web.Controllers
{
    public class CalculationOfTheBarsiControllerTests
    {
        private readonly Mock<ICalculationOfTheBarsiService> _mockBarsiService;
        private readonly Mock<IAllStockExchangeService> _mockStockExchangeService;
        private readonly CalculationOfTheBarsiController _controller;

        public CalculationOfTheBarsiControllerTests()
        {
            _mockBarsiService = new Mock<ICalculationOfTheBarsiService>();
            _mockStockExchangeService = new Mock<IAllStockExchangeService>();
            _controller = new CalculationOfTheBarsiController(_mockBarsiService.Object, _mockStockExchangeService.Object);
        }

        [Fact]
        public async Task Index_DeveRetornarViewResult_ComListaCalculada()
        {
            // Arrange
            var mockAtivos = new List<Active> { new Active(), new Active() };
            var mockBarsi = new List<Barsi> { new Barsi(), new Barsi() };
            _mockStockExchangeService.Setup(service => service.GetAllActive()).Returns(mockAtivos);
            _mockBarsiService.Setup(service => service.GetCalculationOfTheBarsiAsync(mockAtivos)).ReturnsAsync(mockBarsi);

            // Act
            var resultado = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<IEnumerable<Barsi>>(viewResult.Model);
            Assert.Equal(2, modelo.Count());
        }

        [Fact]
        public async Task OrdenarPorRendimentoDecrescente_DeveRetornarJsonResult_ComItensOrdenados()
        {
            // Arrange
            var mockBarsi = new List<Barsi>
            {
                new Barsi { Yield_12m = 1.5m },
                new Barsi { Yield_12m = 2.0m }
            };

            // Act
            var resultado = await _controller.OrderByDescendingYield(mockBarsi);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(resultado);
            var itensOrdenados = Assert.IsAssignableFrom<IEnumerable<Barsi>>(jsonResult.Value);
            Assert.Equal(2.0m, itensOrdenados.First().Yield_12m);
        }

        [Fact]
        public async Task OrdenarPorPrecoCrescente_DeveRetornarJsonResult_ComItensOrdenados()
        {
            // Arrange
            var mockBarsi = new List<Barsi>
            {
                new Barsi { Price = 10 },
                new Barsi { Price = 20 }
            };

            // Act
            var resultado = await _controller.OrderByAscendingPrice(mockBarsi);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(resultado);
            var itensOrdenados = Assert.IsAssignableFrom<IEnumerable<Barsi>>(jsonResult.Value);
            Assert.Equal(10, itensOrdenados.First().Price);
        }

        [Fact]
        public async Task OrdenarPorResultadoAnualDecrescente_DeveRetornarJsonResult_ComItensOrdenados()
        {
            // Arrange
            var mockBarsi = new List<Barsi>
            {
                new Barsi { Result_Year = 150 },
                new Barsi { Result_Year = 200 }
            };

            // Act
            var resultado = await _controller.OrderByDescendingResult(mockBarsi);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(resultado);
            var itensOrdenados = Assert.IsAssignableFrom<IEnumerable<Barsi>>(jsonResult.Value);
            Assert.Equal(200, itensOrdenados.First().Result_Year);
        }

        [Fact]
        public async Task Limpar_DeveRetornarJsonResult_ComListaCalculada()
        {
            // Arrange
            var mockAtivos = new List<Active> { new Active(), new Active() };
            var mockBarsi = new List<Barsi> { new Barsi(), new Barsi() };
            _mockStockExchangeService.Setup(service => service.GetAllActiveAsync()).ReturnsAsync(mockAtivos);
            _mockBarsiService.Setup(service => service.GetCalculationOfTheBarsiAsync(mockAtivos)).ReturnsAsync(mockBarsi);

            // Act
            var resultado = await _controller.Clean();

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(resultado);
            var modelo = Assert.IsAssignableFrom<IEnumerable<Barsi>>(jsonResult.Value);
            Assert.Equal(2, modelo.Count());
        }

        [Fact]
        public async Task RenderizarTabela_DeveRetornarPartialViewResult_ComModeloAtualizado()
        {
            // Arrange
            var mockBarsi = new List<Barsi> { new Barsi(), new Barsi() };

            // Act
            var resultado = await _controller.RenderTable(mockBarsi);

            // Assert
            var partialViewResult = Assert.IsType<PartialViewResult>(resultado);
            Assert.Equal("_TabelaBarsi", partialViewResult.ViewName);
            var modelo = Assert.IsAssignableFrom<IEnumerable<Barsi>>(partialViewResult.Model);
            Assert.Equal(2, modelo.Count());
        }
    }
}