using Finance.Domain;

namespace Finance.Data.Interface
{
    public interface IStockExchangeData
    {
        List<Active> GetStockExchangeActive();
        Task<List<Active>> GetStockExchangeActiveAsync();
    }
}
