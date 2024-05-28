using Finance.Change.Data;
using Finance.Models;

namespace Finance.Change.Action
{
    public class ChangeIbovespaShares
    {
        public List<Active> GetActive()
        {
            List<Active> listActive = new List<Active>();

            ActiveData activeData = new ActiveData();

            listActive = activeData.GetActive();

            return listActive;
        }

        public List<Active> GetActiveApi()
        {
            List<Active> listActive = new List<Active>();

            ActiveData activeData = new ActiveData();

            listActive = activeData.GetActive();

            return listActive;
        }

    }
}
