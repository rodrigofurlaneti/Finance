using Finance.Data.Interface;
using System.Data;
using System.Data.SqlClient;

namespace Finance.Data.Repository
{
    public class SqlConnectionWrapper : IDbConnectionWrapper
    {
        private readonly SqlConnection _connection;

        public SqlConnectionWrapper(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public IDbCommandWrapper CreateCommand()
        {
            return new SqlCommandWrapper(_connection.CreateCommand());
        }

        public void Open()
        {
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
