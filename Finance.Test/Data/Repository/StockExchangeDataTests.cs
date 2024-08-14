using Finance.Data.Interface;
using Finance.Data.Repository;
using Finance.Domain;
using Moq;
using System.Data.SqlClient;
using Xunit;

namespace Finance.Tests.Data.Repository
{
    public class StockExchangeDataTests
    {
        [Fact]
        public void GetStockExchangeActive_ReturnsListOfActive()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnectionWrapper>();
            var mockCommand = new Mock<IDbCommandWrapper>();
            var mockReader = new Mock<IDataReaderWrapper>();

            mockConnection.Setup(m => m.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(m => m.ExecuteReader()).Returns(mockReader.Object);

            mockReader.SetupSequence(m => m.Read())
                .Returns(true)  // Simula a leitura de um registro
                .Returns(false); // Simula o fim dos registros

            // Configura os valores que serão retornados pelo reader
            mockReader.Setup(m => m.GetInt32(It.IsAny<int>())).Returns(1);
            mockReader.Setup(m => m.GetString(It.IsAny<int>())).Returns("Test");
            mockReader.Setup(m => m.GetDecimal(It.IsAny<int>())).Returns(100.00m);
            mockReader.Setup(m => m.GetInt64(It.IsAny<int>())).Returns(1000000);

            var repository = new StockExchangeData(mockConnection.Object);

            // Act
            var result = repository.GetStockExchangeActive();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Active>>(result);
            Assert.Single(result);  // Verifica se apenas um item foi adicionado à lista
        }

        [Fact]
        public async Task GetStockExchangeActiveAsync_ReturnsListOfActive()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnectionWrapper>();
            var mockCommand = new Mock<IDbCommandWrapper>();
            var mockReader = new Mock<IDataReaderWrapper>();

            mockConnection.Setup(m => m.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(m => m.ExecuteReaderAsync()).ReturnsAsync(mockReader.Object);

            mockReader.SetupSequence(m => m.ReadAsync())
                .ReturnsAsync(true)  // Simula a leitura de um registro
                .ReturnsAsync(false); // Simula o fim dos registros

            // Configura os valores que serão retornados pelo reader
            mockReader.Setup(m => m.GetInt32(It.IsAny<int>())).Returns(1);
            mockReader.Setup(m => m.GetString(It.IsAny<int>())).Returns("Test");
            mockReader.Setup(m => m.GetDecimal(It.IsAny<int>())).Returns(100.00m);
            mockReader.Setup(m => m.GetInt64(It.IsAny<int>())).Returns(1000000);

            var repository = new StockExchangeData(mockConnection.Object);

            // Act
            var result = await repository.GetStockExchangeActiveAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Active>>(result);
            Assert.Single(result);  // Verifica se apenas um item foi adicionado à lista
        }
    }
}