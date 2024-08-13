using Finance.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Tests.Web.Controllers
{
    public class IbovespaSharesControllerTests
    {
        private readonly IbovespaSharesController _controller;

        public IbovespaSharesControllerTests()
        {
            _controller = new IbovespaSharesController();
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