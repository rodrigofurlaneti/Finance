using Finance.Data.Interface;
using Finance.Domain;
using Finance.Service.Interface;

namespace Finance.Service.Implementation
{
    public class BestStocksToInvestInService : IBestStocksToInvestInService
    {
        private readonly IBestStocksToInvestInData _bestStocksToInvestInData;

        public BestStocksToInvestInService(IBestStocksToInvestInData bestStocksToInvestInData)
        {
            _bestStocksToInvestInData = bestStocksToInvestInData;
        }

        public async Task<IEnumerable<BestStocksToInvestIn>> GetAllBestStocksToInvestInAsync()
        {
            return await _bestStocksToInvestInData.GetAllBestStocksToInvestInAsync();
        }
    }
}
