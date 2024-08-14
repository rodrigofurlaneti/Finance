using System.Data;

namespace Finance.Data.Interface
{
    public interface IDbCommandWrapper : IDisposable
    {
        void SetCommandText(string commandText);
        void SetCommandType(CommandType commandType);
        IDataReaderWrapper ExecuteReader();
        Task<IDataReaderWrapper> ExecuteReaderAsync();
    }
}
