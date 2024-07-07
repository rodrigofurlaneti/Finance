using Finance.Domain;

namespace Finance.Data.Interface
{
    public interface IRealEstateInvestmentFundData
    {
        List<Active> GetAllActiveFii();
        Task<List<Active>> GetAllActiveFiiAsync();
    }
}
