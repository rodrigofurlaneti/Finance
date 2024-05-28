using Microsoft.AspNetCore.Mvc;

namespace Finance.Controllers
{
    public class IbovespaSharesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
