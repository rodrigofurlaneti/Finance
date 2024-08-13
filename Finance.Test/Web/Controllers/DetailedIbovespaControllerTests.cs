using Finance.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Finance.Tests.Web.Controllers
{
    public class DetailedIbovespaControllerTests
    {
        private readonly DetailedIbovespaController _controller;

        public DetailedIbovespaControllerTests()
        {
            _controller = new DetailedIbovespaController();
        }

        [Fact]
        public async Task Index_DeveRetornarViewResult()
        {
            // Act
            var resultado = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(resultado);
        }
    }
}