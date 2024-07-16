using Finance.Domain;
using Finance.Service.Interface;
using Finance.Tests.Helpers.PopularClassWithFakeData;
using Finance.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Finance.Tests.Web.Controllers
{
    public class AllStockExchangeControllerTests
    {
        [Fact]
        public async Task Index_Retorna_E_Visualizar_Resultado_Com_Uma_Lista_De_Bolsas_De_Valores_Ativas()
        {
            // Arrange
            var objectReturn = ActiveFaker.GetListActive();

            var mockService = new Mock<IAllStockExchangeService>();
            mockService.Setup(service => service.GetAllActiveAsync())
                       .ReturnsAsync(objectReturn);

            var controller = new AllStockExchangeController(mockService.Object);

            // Act
            var result = await controller.Index(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Active>>(viewResult.Model);
            Assert.Equal(objectReturn.Count(), model.Count());
        }


    }
}
