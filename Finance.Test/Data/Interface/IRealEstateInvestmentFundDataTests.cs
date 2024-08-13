using Finance.Data.Interface;
using Finance.Domain;
using Moq;
using FluentAssertions;
using Xunit;

namespace Finance.Tests.Data.Interface
{
    public class IRealEstateInvestmentFundDataTests
    {
        private readonly Mock<IRealEstateInvestmentFundData> _mockRealEstateInvestmentFundData;

        public IRealEstateInvestmentFundDataTests()
        {
            _mockRealEstateInvestmentFundData = new Mock<IRealEstateInvestmentFundData>();
        }

        [Fact]
        public void Deve_Retornar_Todos_Ativos_Fii_Sincronamente()
        {
            // Arrange
            var expectedAtivos = new List<Active> { new Active(), new Active() };
            _mockRealEstateInvestmentFundData.Setup(x => x.GetAllActiveFii()).Returns(expectedAtivos);

            // Act
            var result = _mockRealEstateInvestmentFundData.Object.GetAllActiveFii();

            // Assert
            result.Should().BeEquivalentTo(expectedAtivos);
        }

        [Fact]
        public async Task Deve_Retornar_Todos_Ativos_Fii_Assincronamente()
        {
            // Arrange
            var expectedAtivos = new List<Active> { new Active(), new Active() };
            _mockRealEstateInvestmentFundData.Setup(x => x.GetAllActiveFiiAsync()).ReturnsAsync(expectedAtivos);

            // Act
            var result = await _mockRealEstateInvestmentFundData.Object.GetAllActiveFiiAsync();

            // Assert
            result.Should().BeEquivalentTo(expectedAtivos);
        }
    }
}