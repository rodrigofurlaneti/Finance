using Finance.Domain;

namespace Finance.Service.Interface
{
    public interface IBrazilianDepositaryReceiptsService
    {
        IEnumerable<Active> GetAllActiveBdr();
        Task<IEnumerable<Active>> GetAllActiveBdrAsync();
    }
}
