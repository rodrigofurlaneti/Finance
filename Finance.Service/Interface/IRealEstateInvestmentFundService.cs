using Finance.Domain;

namespace Finance.Service.Interface
{
    public interface IRealEstateInvestmentFundService
    {
        IEnumerable<Active> GetAllActiveFii();
        Task<IEnumerable<Active>> GetAllActiveFiiAsync();

    }
}
