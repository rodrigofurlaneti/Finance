﻿using Finance.Data.Repository;
using Finance.Domain;
using Moq;
using System.Data.SqlClient;
using Xunit;

namespace Finance.Tests.Data.Repository
{
    public class RealEstateInvestmentFundDataTests
    {
        private readonly Mock<SqlConnection> _mockConnection;
        private readonly Mock<SqlCommand> _mockCommand;
        private readonly Mock<SqlDataReader> _mockReader;

        public RealEstateInvestmentFundDataTests()
        {
            _mockConnection = new Mock<SqlConnection>();
            _mockCommand = new Mock<SqlCommand>();
            _mockReader = new Mock<SqlDataReader>();
        }

        [Fact]
        public void Deve_Retornar_Todos_Os_Ativos_Fii()
        {
            // Arrange
            var expectedActive = new List<Active>
            {
                new Active { IdActive = 1, Name = "Ativo Fii 1" },
                new Active { IdActive = 2, Name = "Ativo Fii 2" }
            };

            _mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(_mockReader.Object);
            _mockReader.SetupSequence(r => r.Read())
                       .Returns(true)
                       .Returns(true)
                       .Returns(false);

            _mockReader.Setup(r => r.GetInt32(It.IsAny<int>())).Returns(1);
            _mockReader.Setup(r => r.GetString(It.IsAny<int>())).Returns("Nome");

            var repository = new RealEstateInvestmentFundData();

            // Act
            var result = repository.GetAllActiveFii();

            // Assert
            Assert.NotNull(result);
            _mockCommand.Verify(cmd => cmd.ExecuteReader(), Times.Once);
        }

        [Fact]
        public async Task Deve_Retornar_Todos_Os_Ativos_Fii_Assincronamente()
        {
            // Arrange
            var expectedActive = new List<Active>
            {
                new Active { IdActive = 1, Name = "Ativo Fii 1" },
                new Active { IdActive = 2, Name = "Ativo Fii 2" }
            };

            _mockCommand.Setup(cmd => cmd.ExecuteReaderAsync(It.IsAny<System.Threading.CancellationToken>()))
                        .ReturnsAsync(_mockReader.Object);
            _mockReader.SetupSequence(r => r.ReadAsync(It.IsAny<System.Threading.CancellationToken>()))
                       .ReturnsAsync(true)
                       .ReturnsAsync(true)
                       .ReturnsAsync(false);

            _mockReader.Setup(r => r.GetInt32(It.IsAny<int>())).Returns(1);
            _mockReader.Setup(r => r.GetString(It.IsAny<int>())).Returns("Nome");

            var repository = new RealEstateInvestmentFundData();

            // Act
            var result = await repository.GetAllActiveFiiAsync();

            // Assert
            Assert.NotNull(result);
            _mockCommand.Verify(cmd => cmd.ExecuteReaderAsync(It.IsAny<System.Threading.CancellationToken>()), Times.Once);
        }
    }
}