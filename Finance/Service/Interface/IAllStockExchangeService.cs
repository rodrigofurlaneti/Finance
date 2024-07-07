using Finance.Models;

namespace Finance.Web.Service.Interface
{
    public interface IAllStockExchangeService
    {
        IEnumerable<Active> GetAllActive();
        Task<IEnumerable<Active>> GetAllActiveAsync();
    }
}
