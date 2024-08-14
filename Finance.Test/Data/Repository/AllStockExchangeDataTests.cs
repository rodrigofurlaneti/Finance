using Finance.Data.Interface;
using Finance.Data.Repository;
using Finance.Domain;
using Moq;
using System.Data.SqlClient;
using Xunit;

namespace Finance.Tests.Data.Repository
{
    public class AllStockExchangeDataTests
    {
        [Fact]
        public async Task GetAllActiveAsync_ReturnsListOfActive()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnectionWrapper>();
            var mockCommand = new Mock<IDbCommandWrapper>();
            var mockReader = new Mock<IDataReaderWrapper>();

            mockConnection.Setup(m => m.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(m => m.ExecuteReaderAsync()).ReturnsAsync(mockReader.Object);

            mockReader.SetupSequence(m => m.ReadAsync())
                .ReturnsAsync(true)
                .ReturnsAsync(false);

            mockReader.Setup(m => m.GetInt32(It.IsAny<int>())).Returns(1);
            mockReader.Setup(m => m.GetString(It.IsAny<int>())).Returns("Texto");
            mockReader.Setup(m => m.GetDecimal(It.IsAny<int>())).Returns(100.00m);
            mockReader.Setup(m => m.GetInt64(It.IsAny<int>())).Returns(1000000);

            var repository = new AllStockExchangeData(mockConnection.Object);

            // Act
            var result = await repository.GetAllActiveAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Active>>(result);
            Assert.Single(result);
        }

        [Fact]
        public void GetAllActive_ReturnsListOfActive()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnectionWrapper>();
            var mockCommand = new Mock<IDbCommandWrapper>();
            var mockReader = new Mock<IDataReaderWrapper>();

            mockConnection.Setup(m => m.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(m => m.ExecuteReader()).Returns(mockReader.Object);

            // Configuração para ler apenas um registro
            mockReader.SetupSequence(m => m.Read())
                .Returns(true)  // Simula a leitura de um único registro.
                .Returns(false); // Simula o fim dos registros após o primeiro.

            // Configurações de retornos dos valores do mock
            mockReader.Setup(m => m.GetInt32(It.IsAny<int>())).Returns(1);
            mockReader.Setup(m => m.GetString(It.IsAny<int>())).Returns("Texto");
            mockReader.Setup(m => m.GetDecimal(It.IsAny<int>())).Returns(100.00m);
            mockReader.Setup(m => m.GetInt64(It.IsAny<int>())).Returns(1000000);

            var repository = new AllStockExchangeData(mockConnection.Object);

            // Act
            var result = repository.GetAllActive();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Active>>(result);
            //Assert.Single(result);  // Verifica se apenas um elemento está presente na coleção.
        }
    }
}