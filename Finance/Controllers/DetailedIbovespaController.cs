using Microsoft.AspNetCore.Mvc;

namespace Finance.Controllers
{
    public class DetailedIbovespaController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
