using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace Finance.Web.Controllers
{
    public class RealEstateInvestmentFundController : Controller
    {
        private readonly IRealEstateInvestmentFundService _realEstateInvestmentFundService;

        public RealEstateInvestmentFundController(IRealEstateInvestmentFundService realEstateInvestmentFundService)
        {
            _realEstateInvestmentFundService = realEstateInvestmentFundService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var items = await _realEstateInvestmentFundService.GetAllActiveFiiAsync();

            int pageSize = 50; // Tamanho da página

            int pageNumber = (page ?? 1); // Número da página atual

            return View(items.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult FirstArticle() => View();
        
    }
}
