using Finance.Models;

namespace Finance.Web.Data.Interface
{
    public interface IStockExchangeData
    {
        List<Active> GetStockExchangeActive();
        Task<List<Active>> GetStockExchangeActiveAsync();
    }
}
