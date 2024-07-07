using Finance.Domain;

namespace Finance.Service.Interface
{
    public interface IStockExchangeService
    {
        IEnumerable<Active> GetStockExchangeActive();
        Task<IEnumerable<Active>> GetStockExchangeActiveAsync();
    }
}
