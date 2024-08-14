using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Data.Interface
{
    public interface IDbConnectionWrapper : IDisposable
    {
        IDbCommandWrapper CreateCommand();
        void Open();
    }
}
