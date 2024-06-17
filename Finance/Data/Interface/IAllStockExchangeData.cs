using Finance.Models;

namespace Finance.Web.Data.Interface
{
    public interface IAllStockExchangeData
    {
        List<Active> GetAllActive();
        Task<List<Active>> GetAllActiveAsync();
    }
}
