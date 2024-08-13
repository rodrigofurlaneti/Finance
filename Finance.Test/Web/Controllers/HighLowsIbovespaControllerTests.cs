using Finance.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Tests.Web.Controllers
{
    public class HighLowsIbovespaControllerTests
    {
        private readonly HighLowsIbovespaController _controller;

        public HighLowsIbovespaControllerTests()
        {
            _controller = new HighLowsIbovespaController();
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