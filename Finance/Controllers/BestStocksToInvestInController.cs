using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class BestStocksToInvestInController : Controller
    {
        private readonly IBestStocksToInvestInService _bestStocksToInvestInService;

        public BestStocksToInvestInController(IBestStocksToInvestInService bestStocksToInvestInService)
        {
            _bestStocksToInvestInService = bestStocksToInvestInService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _bestStocksToInvestInService.GetAllBestStocksToInvestInAsync();

            return View(items);
        }
    }
}
