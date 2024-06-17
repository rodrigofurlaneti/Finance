using Finance.Models;
using Finance.Web.Data.Repository;
using Finance.Web.Service.Interface;

namespace Finance.Web.Service.Service
{
    public class RealEstateInvestmentFundService : IRealEstateInvestmentFundService
    {
        public List<Active> GetAllActiveFii()
        {
            RealEstateInvestmentFundData _realEstateInvestmentFundData = new RealEstateInvestmentFundData();
            return _realEstateInvestmentFundData.GetAllActiveFii();
        }

        public async Task<List<Active>> GetAllActiveFiiAsync()
        {
            RealEstateInvestmentFundData _realEstateInvestmentFundData = new RealEstateInvestmentFundData();
            return await _realEstateInvestmentFundData.GetAllActiveFiiAsync();
        }
    }
}
