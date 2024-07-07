using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class BrazilianDepositaryReceiptsController : Controller
    {
        private readonly IBrazilianDepositaryReceiptsService _brazilianDepositaryReceiptsService;

        public BrazilianDepositaryReceiptsController(IBrazilianDepositaryReceiptsService brazilianDepositaryReceiptsService)
        {
            _brazilianDepositaryReceiptsService = brazilianDepositaryReceiptsService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _brazilianDepositaryReceiptsService.GetAllActiveBdrAsync();

            return View(model);
        }
    }
}
