using Finance.Data.Interface;
using Finance.Data.Repository;
using Finance.Domain;
using Moq;
using System.Data.SqlClient;
using Xunit;

namespace Finance.Tests.Data.Repository
{
    public class RealEstateInvestmentFundDataTests
    {
        [Fact]
        public void GetAllActiveFii_ReturnsListOfActive()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnectionWrapper>();
            var mockCommand = new Mock<IDbCommandWrapper>();
            var mockReader = new Mock<IDataReaderWrapper>();

            // Setup mocks
            mockConnection.Setup(conn => conn.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(mockReader.Object);

            mockReader.SetupSequence(r => r.Read())
                .Returns(true)  // Simula a leitura de um registro
                .Returns(false); // Simula o fim dos registros

            mockReader.Setup(r => r.GetInt32(It.IsAny<int>())).Returns(1);
            mockReader.Setup(r => r.GetString(It.IsAny<int>())).Returns("Test");
            mockReader.Setup(r => r.GetDecimal(It.IsAny<int>())).Returns(100.00m);
            mockReader.Setup(r => r.GetInt64(It.IsAny<int>())).Returns(1000000);

            var realEstateInvestmentFundData = new RealEstateInvestmentFundData(mockConnection.Object);

            // Act
            var result = realEstateInvestmentFundData.GetAllActiveFii();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Active>>(result);
            Assert.Single(result);  // Verifica se apenas um item foi adicionado à lista
        }

        [Fact]
        public async Task GetAllActiveFiiAsync_ReturnsListOfActive()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnectionWrapper>();
            var mockCommand = new Mock<IDbCommandWrapper>();
            var mockReader = new Mock<IDataReaderWrapper>();

            // Setup mocks
            mockConnection.Setup(conn => conn.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(cmd => cmd.ExecuteReaderAsync()).ReturnsAsync(mockReader.Object);

            mockReader.SetupSequence(r => r.ReadAsync())
                .ReturnsAsync(true)  // Simula a leitura de um registro
                .ReturnsAsync(false); // Simula o fim dos registros

            mockReader.Setup(r => r.GetInt32(It.IsAny<int>())).Returns(1);
            mockReader.Setup(r => r.GetString(It.IsAny<int>())).Returns("Test");
            mockReader.Setup(r => r.GetDecimal(It.IsAny<int>())).Returns(100.00m);
            mockReader.Setup(r => r.GetInt64(It.IsAny<int>())).Returns(1000000);

            var realEstateInvestmentFundData = new RealEstateInvestmentFundData(mockConnection.Object);

            // Act
            var result = await realEstateInvestmentFundData.GetAllActiveFiiAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Active>>(result);
            Assert.Single(result);  // Verifica se apenas um item foi adicionado à lista
        }
    }
}