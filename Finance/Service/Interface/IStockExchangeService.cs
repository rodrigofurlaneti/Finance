using Finance.Models;

namespace Finance.Web.Service.Interface
{
    public interface IStockExchangeService
    {
        List<Active> GetStockExchangeActive();
        Task<List<Active>> GetStockExchangeActiveAsync();
    }
}
