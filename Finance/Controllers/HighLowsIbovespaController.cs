using Microsoft.AspNetCore.Mvc;

namespace Finance.Controllers
{
    public class HighLowsIbovespaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
