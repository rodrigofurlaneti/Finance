using Finance.Data.Interface;
using Finance.Domain;
using Finance.Service.Implementation;
using Moq;
using Xunit;

namespace Finance.Tests.Data.Interface
{
    public class IAllStockExchangeServiceTests
    {
        [Fact]
        public void GetActives_ShouldReturnAllActives()
        {
            // Arrange
            var mockData = new Mock<IAllStockExchangeData>();
            var expectedActives = new List<Active>
            {
                new Active { IdActive = 1, Name = "Active1" },
                new Active { IdActive = 2, Name = "Active2" }
            };

            mockData.Setup(x => x.GetAllActive()).Returns(expectedActives);

            var service = new AllStockExchangeService(mockData.Object);

            // Act
            var result = service.GetAllActive();

            // Assert
            Assert.Equal(expectedActives, result);
        }

        [Fact]
        public async Task GetActivesAsync_ShouldReturnAllActivesAsync()
        {
            // Arrange
            var mockData = new Mock<IAllStockExchangeData>();
            var expectedActives = new List<Active>
            {
                new Active { IdActive = 1, Name = "Active1" },
                new Active { IdActive = 2, Name = "Active2" }
            };

            mockData.Setup(x => x.GetAllActiveAsync()).ReturnsAsync(expectedActives);

            var service = new AllStockExchangeService(mockData.Object);

            // Act
            var result = await service.GetAllActiveAsync();

            // Assert
            Assert.Equal(expectedActives, result);
        }
    }
}
