using Finance.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Tests.Web.Controllers
{
    public class GettingFiiDividendsControllerTests
    {
        private readonly GettingFiiDividendsController _controller;

        public GettingFiiDividendsControllerTests()
        {
            _controller = new GettingFiiDividendsController();
        }

        [Fact]
        public void Index_DeveRetornarViewResult()
        {
            // Act
            var resultado = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(resultado);
        }
    }
}