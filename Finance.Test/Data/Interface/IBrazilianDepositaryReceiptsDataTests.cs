using Finance.Data.Interface;
using Finance.Domain;
using Moq;
using Xunit;
using FluentAssertions;

namespace Finance.Tests.Data.Interface
{
    public class IBrazilianDepositaryReceiptsDataTests
    {
        private readonly Mock<IBrazilianDepositaryReceiptsData> _mockBrazilianDepositaryReceiptsData;

        public IBrazilianDepositaryReceiptsDataTests()
        {
            _mockBrazilianDepositaryReceiptsData = new Mock<IBrazilianDepositaryReceiptsData>();
        }

        [Fact]
        public void Deve_Retornar_Todos_Ativos_Bdr_Sincronamente()
        {
            // Arrange
            var expectedAtivos = new List<Active> { new Active(), new Active() };
            _mockBrazilianDepositaryReceiptsData.Setup(x => x.GetAllActiveBdr()).Returns(expectedAtivos);

            // Act
            var result = _mockBrazilianDepositaryReceiptsData.Object.GetAllActiveBdr();

            // Assert
            result.Should().BeEquivalentTo(expectedAtivos);
        }

        [Fact]
        public async Task Deve_Retornar_Todos_Ativos_Bdr_Assincronamente()
        {
            // Arrange
            var expectedAtivos = new List<Active> { new Active(), new Active() };
            _mockBrazilianDepositaryReceiptsData.Setup(x => x.GetAllActiveBdrAsync()).ReturnsAsync(expectedAtivos);

            // Act
            var result = await _mockBrazilianDepositaryReceiptsData.Object.GetAllActiveBdrAsync();

            // Assert
            result.Should().BeEquivalentTo(expectedAtivos);
        }
    }
}