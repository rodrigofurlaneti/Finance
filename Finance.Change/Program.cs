using Finance.Change.Action;
using System;

namespace Finance.Change
{
    class Program
    {
        static void Main(string[] args)
        {
            var changeIbovespaShares = new ChangeIbovespaShares();

            var ret = changeIbovespaShares.GetActive();
        }
    }
}
