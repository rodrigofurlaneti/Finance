using Finance.Data.Repository;
using Finance.Domain;
using Moq;
using System.Data.SqlClient;
using Xunit;

namespace Finance.Tests.Data.Repository
{
    public class StockExchangeDataTests
    {
        private readonly Mock<SqlConnection> _mockConnection;
        private readonly Mock<SqlCommand> _mockCommand;
        private readonly Mock<SqlDataReader> _mockReader;

        public StockExchangeDataTests()
        {
            _mockConnection = new Mock<SqlConnection>();
            _mockCommand = new Mock<SqlCommand>();
            _mockReader = new Mock<SqlDataReader>();
        }
    }
}