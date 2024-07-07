using Finance.Data.Interface;
using Finance.Domain;
using Finance.Service.Interface;

namespace Finance.Service.Implementation
{
    public class RealEstateInvestmentFundService : IRealEstateInvestmentFundService
    {
        private readonly IRealEstateInvestmentFundData _realEstateInvestmentFundData;

        public RealEstateInvestmentFundService(IRealEstateInvestmentFundData realEstateInvestmentFundData)
        {
            _realEstateInvestmentFundData = realEstateInvestmentFundData;
        }
        public IEnumerable<Active> GetAllActiveFii()
        {
            return _realEstateInvestmentFundData.GetAllActiveFii();
        }

        public async Task<IEnumerable<Active>> GetAllActiveFiiAsync()
        {
            return await _realEstateInvestmentFundData.GetAllActiveFiiAsync();
        }
    }
}
