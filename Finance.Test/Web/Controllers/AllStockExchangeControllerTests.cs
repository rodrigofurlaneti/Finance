using Finance.Web.Controllers;
using Finance.Web.Service;
using Finance.Web.Service.Interface;


namespace Finance.Tests.Web.Controllers
{
    public class AllStockExchangeControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResult_WithAListOfActiveStockExchanges()
        {
            // Arrange
            var mockService = new Mock<IAllStockExchangeService>();
            mockService.Setup(service => service.GetAllActiveAsync())
                       .ReturnsAsync(GetTestStockExchanges());

            var controller = new AllStockExchangeController(mockService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StockExchange>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        private List<StockExchange> GetTestStockExchanges()
        {
            return new List<StockExchange>
            {
                new StockExchange { Id = 1, Name = "NYSE", IsActive = true },
                new StockExchange { Id = 2, Name = "NASDAQ", IsActive = true },
            };
        }
    }
}
