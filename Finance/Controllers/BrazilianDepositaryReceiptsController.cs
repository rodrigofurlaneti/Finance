using Finance.Web.Service;
using Finance.Web.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class BrazilianDepositaryReceiptsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var brazilianDepositaryReceipts = new BrazilianDepositaryReceiptsService();

            var model = await brazilianDepositaryReceipts.GetAllActiveBdrAsync();

            return View(model);
        }
    }
}
