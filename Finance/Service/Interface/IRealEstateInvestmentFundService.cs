using Finance.Models;

namespace Finance.Web.Service.Interface
{
    public interface IRealEstateInvestmentFundService
    {
        List<Active> GetAllActiveFii();
        Task<List<Active>> GetAllActiveFiiAsync();

    }
}
