using Finance.Models;
using Finance.Web.Data.Repository;
using Finance.Web.Service.Interface;

namespace Finance.Web.Service.Service
{
    public class StockExchangeService : IStockExchangeService
    {
        public List<Active> GetStockExchangeActive()
        {
            StockExchangeData _stockExchangeData = new StockExchangeData();
            return _stockExchangeData.GetStockExchangeActive();
        }

        public async Task<List<Active>> GetStockExchangeActiveAsync()
        {
            StockExchangeData _stockExchangeData = new StockExchangeData();
            return await _stockExchangeData.GetStockExchangeActiveAsync();
        }

    }
}
