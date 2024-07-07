using Finance.Data.Interface;
using Finance.Domain;
using Finance.Service.Interface;

namespace Finance.Service.Implementation
{
    public class StockExchangeService : IStockExchangeService
    {
        private readonly IStockExchangeData _stockExchangeData;

        public StockExchangeService(IStockExchangeData stockExchangeData)
        {
            _stockExchangeData = stockExchangeData;
        }

        public IEnumerable<Active> GetStockExchangeActive()
        {
            return _stockExchangeData.GetStockExchangeActive();
        }

        public async Task<IEnumerable<Active>> GetStockExchangeActiveAsync()
        {
            return await _stockExchangeData.GetStockExchangeActiveAsync();
        }

    }
}
