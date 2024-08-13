using Finance.Controllers;
using Finance.Domain;
using Moq.Protected;
using Moq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Finance.Tests.Web.Controllers
{
    public class HomeControllerTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<IHttpClientFactory> _mockHttpClientFactory;
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();
            _controller = new HomeController(_mockConfiguration.Object, _mockHttpClientFactory.Object);
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