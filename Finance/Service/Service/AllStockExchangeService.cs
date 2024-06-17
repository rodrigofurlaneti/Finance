using Finance.Models;
using Finance.Web.Data.Repository;
using Finance.Web.Service.Interface;

namespace Finance.Web.Service.Service
{
    public class AllStockExchangeService : IAllStockExchangeService
    {
        public List<Active> GetAllActive() 
        {
            AllStockExchangeData _allStockExchangeData = new AllStockExchangeData();
            return _allStockExchangeData.GetAllActive();
        }
        public async Task<List<Active>> GetAllActiveAsync()
        {
            AllStockExchangeData _allStockExchangeData = new AllStockExchangeData();
            return await _allStockExchangeData.GetAllActiveAsync();
        }
    }
}
