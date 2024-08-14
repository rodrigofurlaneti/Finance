using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Data.Interface
{
    public interface IDataReaderWrapper : IDisposable
    {
        bool Read();
        Task<bool> ReadAsync();
        int GetInt32(int ordinal);
        string GetString(int ordinal);
        decimal GetDecimal(int ordinal);
        long GetInt64(int ordinal);
        int GetOrdinal(string name);
    }
}
