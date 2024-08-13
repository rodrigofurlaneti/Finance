using Finance.Controllers;
using Finance.Domain;
using Moq.Protected;
using Moq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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

        [Fact]
        public async Task SubmitForm_DeveRetornarJsonResult_ComSucesso_QuandoModeloValidoERecaptchaValido()
        {
            // Arrange
            var mensagemContato = new MensagemContato { RecaptchaResponse = "valid-response" };
            _mockConfiguration.Setup(c => c["GoogleReCaptcha:SecretKey"]).Returns("fake-secret-key");

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"success\": true, \"score\": 0.9}")
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            _mockHttpClientFactory.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);

            // Act
            var resultado = await _controller.SubmitForm(mensagemContato);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(resultado);
            var resultadoData = jsonResult.Value as dynamic;
            Assert.True(resultadoData.success);
            Assert.Equal("Formulário enviado com sucesso!", resultadoData.message.ToString());
        }

        [Fact]
        public async Task SubmitForm_DeveRetornarJsonResult_ComErro_QuandoRecaptchaInvalido()
        {
            // Arrange
            var mensagemContato = new MensagemContato { RecaptchaResponse = "invalid-response" };
            _mockConfiguration.Setup(c => c["GoogleReCaptcha:SecretKey"]).Returns("fake-secret-key");

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"success\": false, \"score\": 0.1}")
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            _mockHttpClientFactory.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);

            // Act
            var resultado = await _controller.SubmitForm(mensagemContato);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(resultado);
            var resultadoData = jsonResult.Value as dynamic;
            Assert.False(resultadoData.success);
            Assert.Contains("Falha na verificação do reCAPTCHA.", resultadoData.errors[0].ToString());
        }

        [Fact]
        public async Task SubmitForm_DeveRetornarJsonResult_ComErro_QuandoRecaptchaResponseNulo()
        {
            // Arrange
            var mensagemContato = new MensagemContato { RecaptchaResponse = null };

            // Act
            var resultado = await _controller.SubmitForm(mensagemContato);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(resultado);
            var resultadoData = jsonResult.Value as dynamic;
            Assert.False(resultadoData.success);
            Assert.Contains("Recaptcha Response está nulo", resultadoData.errors[0].ToString());
        }

        [Fact]
        public async Task SubmitForm_DeveRetornarJsonResult_ComErro_QuandoRecaptchaResponseVazio()
        {
            // Arrange
            var mensagemContato = new MensagemContato { RecaptchaResponse = string.Empty };

            // Act
            var resultado = await _controller.SubmitForm(mensagemContato);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(resultado);
            var resultadoData = jsonResult.Value as dynamic;
            Assert.False(resultadoData.success);
            Assert.Contains("Recaptcha Response está vazio", resultadoData.errors[0].ToString());
        }

        [Fact]
        public async Task SubmitForm_DeveRetornarJsonResult_ComErro_QuandoModeloInvalido()
        {
            // Arrange
            var mensagemContato = new MensagemContato { RecaptchaResponse = "valid-response" };
            _controller.ModelState.AddModelError("Erro", "Modelo inválido");

            // Act
            var resultado = await _controller.SubmitForm(mensagemContato);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(resultado);
            var resultadoData = jsonResult.Value as dynamic;
            Assert.False(resultadoData.success);
            Assert.Contains("Modelo no back-end inválido", resultadoData.errors[0].ToString());
        }
    }
}