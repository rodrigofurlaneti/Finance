using Finance.Domain;

namespace Finance.Data.Interface
{
    public interface IAllStockExchangeData
    {
        IEnumerable<Active> GetAllActive();
        Task<IEnumerable<Active>> GetAllActiveAsync();
    }
}
