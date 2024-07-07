using Finance.Data.Interface;
using Finance.Domain;
using Finance.Service.Interface;

namespace Finance.Service.Implementation
{
    public class AllStockExchangeService : IAllStockExchangeService
    {
        private readonly IAllStockExchangeData _allStockExchangeData;

        public AllStockExchangeService(IAllStockExchangeData allStockExchangeData)
        {
            _allStockExchangeData = allStockExchangeData;
        }

        public IEnumerable<Active> GetAllActive() 
        {
            return _allStockExchangeData.GetAllActive();
        }
        public async Task<IEnumerable<Active>> GetAllActiveAsync()
        {
            return await _allStockExchangeData.GetAllActiveAsync();
        }
    }
}
