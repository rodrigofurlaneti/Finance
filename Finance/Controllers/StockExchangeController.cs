using Finance.Web.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class StockExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var stockExchange = new StockExchangeService();

            var model = await stockExchange.GetStockExchangeActiveAsync();

            return View(model);
        }
    }
}
