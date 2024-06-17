using Finance.Models;

namespace Finance.Web.Data.Interface
{
    public interface IRealEstateInvestmentFundData
    {
        List<Active> GetAllActiveFii();
        Task<List<Active>> GetAllActiveFiiAsync();
    }
}
