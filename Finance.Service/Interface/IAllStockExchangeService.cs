using Finance.Domain;

namespace Finance.Service.Interface
{
    public interface IAllStockExchangeService
    {
        IEnumerable<Active> GetAllActive();
        Task<IEnumerable<Active>> GetAllActiveAsync();
    }
}
