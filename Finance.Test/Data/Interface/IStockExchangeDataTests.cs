using Finance.Data.Interface;
using Finance.Domain;
using FluentAssertions;
using Moq;
using Xunit;

namespace Finance.Tests.Data.Interface
{
    public class IStockExchangeDataTests
    {
        private readonly Mock<IStockExchangeData> _mockStockExchangeData;

        public IStockExchangeDataTests()
        {
            _mockStockExchangeData = new Mock<IStockExchangeData>();
        }

        [Fact]
        public void Deve_Retornar_Lista_De_Ativos()
        {
            // Arrange
            var expectedAtivos = new List<Active>
            {
                new Active { IdActive = 1, Name = "Ativo 1" },
                new Active { IdActive = 2, Name = "Ativo 2" }
            };
            _mockStockExchangeData.Setup(x => x.GetStockExchangeActive()).Returns(expectedAtivos);

            // Act
            var result = _mockStockExchangeData.Object.GetStockExchangeActive();

            // Assert
            result.Should().BeEquivalentTo(expectedAtivos);
            _mockStockExchangeData.Verify(x => x.GetStockExchangeActive(), Times.Once);
        }

        [Fact]
        public async Task Deve_Retornar_Lista_De_Ativos_Assincronamente()
        {
            // Arrange
            var expectedAtivos = new List<Active>
            {
                new Active { IdActive = 1, Name = "Ativo 1" },
                new Active { IdActive = 2, Name = "Ativo 2" }
            };
            _mockStockExchangeData.Setup(x => x.GetStockExchangeActiveAsync()).ReturnsAsync(expectedAtivos);

            // Act
            var result = await _mockStockExchangeData.Object.GetStockExchangeActiveAsync();

            // Assert
            result.Should().BeEquivalentTo(expectedAtivos);
            _mockStockExchangeData.Verify(x => x.GetStockExchangeActiveAsync(), Times.Once);
        }
    }
}