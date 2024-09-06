using Finance.Domain;

namespace Finance.Data.Interface
{
    public interface IBestStocksToInvestInData
    {
        Task<IEnumerable<BestStocksToInvestIn>> GetAllBestStocksToInvestInAsync();
    }
}
