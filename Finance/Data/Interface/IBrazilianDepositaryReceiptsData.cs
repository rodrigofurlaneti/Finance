using Finance.Models;

namespace Finance.Web.Data.Interface
{
    public interface IBrazilianDepositaryReceiptsData
    {
        List<Active> GetAllActiveBdr();
        Task<List<Active>> GetAllActiveBdrAsync();
    }
}
