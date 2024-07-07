using Finance.Domain;
using Finance.Service.Interface;
using Finance.Tests.Helpers.PopularClassWithFakeData;
using Finance.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Tests.Web.Controllers
{
    public class BrazilianDepositaryReceiptsControllerTests
    {
        [Fact]
        public async Task Index_Retorna_O_Resultado_Da_Visualização_Com_A_Lista_De_Bdr_Ativos()
        {
            // Arrange
            var objectReturn = ActiveFaker.GetListActive();

            var mockService = new Mock<IBrazilianDepositaryReceiptsService>();
            mockService.Setup(service => service.GetAllActiveBdrAsync())
                       .ReturnsAsync(objectReturn);

            var controller = new BrazilianDepositaryReceiptsController(mockService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Active>>(viewResult.Model);
            Assert.Equal(objectReturn.Count(), model.Count());
        }
    }
}
