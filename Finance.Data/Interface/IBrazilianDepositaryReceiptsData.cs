using Finance.Domain;

namespace Finance.Data.Interface
{
    public interface IBrazilianDepositaryReceiptsData
    {
        List<Active> GetAllActiveBdr();
        Task<List<Active>> GetAllActiveBdrAsync();
    }
}
