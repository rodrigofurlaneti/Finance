using Finance.Models;
using Finance.Web.Data.Interface;
using Finance.Web.Data.Repository;
using Finance.Web.Service.Interface;

namespace Finance.Web.Service.Service
{
    public class BrazilianDepositaryReceiptsService : IBrazilianDepositaryReceiptsService
    {
        public List<Active> GetAllActiveBdr()
        {
            BrazilianDepositaryReceiptsData _brazilianDepositaryReceiptsData = new BrazilianDepositaryReceiptsData();
            return _brazilianDepositaryReceiptsData.GetAllActiveBdr();
        }

        public async Task<List<Active>> GetAllActiveBdrAsync()
        {
            BrazilianDepositaryReceiptsData _brazilianDepositaryReceiptsData = new BrazilianDepositaryReceiptsData();
            return await _brazilianDepositaryReceiptsData.GetAllActiveBdrAsync();
        }
    }
}
