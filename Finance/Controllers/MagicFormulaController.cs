using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class MagicFormulaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
