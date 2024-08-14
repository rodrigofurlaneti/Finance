using Finance.Data.Interface;
using System.Data.SqlClient;
using System.Data;

namespace Finance.Data.Repository
{
    public class SqlCommandWrapper : IDbCommandWrapper
    {
        private readonly SqlCommand _command;

        public SqlCommandWrapper(SqlCommand command)
        {
            _command = command;
        }

        public void SetCommandText(string commandText)
        {
            _command.CommandText = commandText;
        }

        public void SetCommandType(CommandType commandType)
        {
            _command.CommandType = commandType;
        }

        public IDataReaderWrapper ExecuteReader()
        {
            var reader = _command.ExecuteReader();
            return new SqlDataReaderWrapper(reader);
        }

        public async Task<IDataReaderWrapper> ExecuteReaderAsync()
        {
            var reader = await _command.ExecuteReaderAsync();
            return new SqlDataReaderWrapper(reader);
        }

        public void Dispose()
        {
            _command.Dispose();
        }
    }
}
