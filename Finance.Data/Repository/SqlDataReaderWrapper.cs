using Finance.Data.Interface;
using System.Data.SqlClient;

namespace Finance.Data.Repository
{
    public class SqlDataReaderWrapper : IDataReaderWrapper
    {
        private readonly SqlDataReader _reader;

        public SqlDataReaderWrapper(SqlDataReader reader)
        {
            _reader = reader;
        }

        public bool Read()
        {
            return _reader.Read();
        }

        public async Task<bool> ReadAsync()
        {
            return await _reader.ReadAsync();
        }

        public int GetInt32(int ordinal)
        {
            return _reader.GetInt32(ordinal);
        }

        public string GetString(int ordinal)
        {
            return _reader.GetString(ordinal);
        }

        public decimal GetDecimal(int ordinal)
        {
            return _reader.GetDecimal(ordinal);
        }

        public long GetInt64(int ordinal)
        {
            return _reader.GetInt64(ordinal);
        }

        public int GetOrdinal(string name)
        {
            return _reader.GetOrdinal(name);
        }

        public void Dispose()
        {
            _reader.Dispose();
        }
    }
}
