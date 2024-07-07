using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class StockExchangeController : Controller
    {
        private readonly IStockExchangeService _stockExchangeService;

        public StockExchangeController(IStockExchangeService stockExchangeService)
        {
            _stockExchangeService = stockExchangeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _stockExchangeService.GetStockExchangeActiveAsync();

            return View(model);
        }
    }
}
