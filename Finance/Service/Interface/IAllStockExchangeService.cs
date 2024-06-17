using Finance.Models;

namespace Finance.Web.Service.Interface
{
    public interface IAllStockExchangeService
    {
        List<Active> GetAllActive();
        Task<List<Active>> GetAllActiveAsync();
    }
}
