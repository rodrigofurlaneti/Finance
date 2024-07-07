using Finance.Data.Interface;
using Finance.Domain;
using Finance.Service.Interface;

namespace Finance.Service.Implementation
{
    public class BrazilianDepositaryReceiptsService : IBrazilianDepositaryReceiptsService
    {
        private readonly IBrazilianDepositaryReceiptsData _brazilianDepositaryReceiptsData;

        public BrazilianDepositaryReceiptsService(IBrazilianDepositaryReceiptsData brazilianDepositaryReceiptsData)
        {
            _brazilianDepositaryReceiptsData = brazilianDepositaryReceiptsData;
        }
        public IEnumerable<Active> GetAllActiveBdr()
        {
            return _brazilianDepositaryReceiptsData.GetAllActiveBdr();
        }

        public async Task<IEnumerable<Active>> GetAllActiveBdrAsync()
        {
            return await _brazilianDepositaryReceiptsData.GetAllActiveBdrAsync();
        }
    }
}
