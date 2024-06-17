using Finance.Web.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class RealEstateInvestmentFundController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var realEstateInvestmentFund = new RealEstateInvestmentFundService();

            var model = await realEstateInvestmentFund.GetAllActiveFiiAsync();

            return View(model);
        }

        public IActionResult FirstArticle() => View();
        
    }
}
