using Finance.Web.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class AllStockExchangeController : Controller
    {
        private readonly IAllStockExchangeService _allStockExchangeService;

        public AllStockExchangeController(IAllStockExchangeService allStockExchangeService)
        {
            _allStockExchangeService = allStockExchangeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _allStockExchangeService.GetAllActiveAsync();
            return View(model);
        }

    }
}
