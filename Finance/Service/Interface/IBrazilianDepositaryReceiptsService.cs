using Finance.Models;

namespace Finance.Web.Service.Interface
{
    public interface IBrazilianDepositaryReceiptsService
    {
        List<Active> GetAllActiveBdr();
        Task<List<Active>> GetAllActiveBdrAsync();
    }
}
