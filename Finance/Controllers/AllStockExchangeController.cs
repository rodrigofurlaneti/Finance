using Finance.Web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class AllStockExchangeController : Controller
    {
        public IActionResult Index()
        {
            var allStockExchangeService = new AllStockExchangeService();

            var model = allStockExchangeService.GetAllActive();

            return View(model);
        }
    }
}
