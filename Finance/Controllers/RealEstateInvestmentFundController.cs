using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class RealEstateInvestmentFundController : Controller
    {
        private readonly IRealEstateInvestmentFundService _realEstateInvestmentFundService;

        public RealEstateInvestmentFundController(IRealEstateInvestmentFundService realEstateInvestmentFundService)
        {
            _realEstateInvestmentFundService = realEstateInvestmentFundService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _realEstateInvestmentFundService.GetAllActiveFiiAsync();

            return View(model);
        }

        public IActionResult FirstArticle() => View();
        
    }
}
