using Finance.Models;
using Finance.Web.Data;

namespace Finance.Web.Service
{
    public class AllStockExchangeService
    {
        public List<Active> GetAllActive()
        {
            return AllStockExchangeData.GetAllActive();
        }
    }
}
