using Finance.Models;
using Finance.Service;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Controllers
{
    public class MainIndicesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            Finance.Routes.Route route = new Finance.Routes.Route();
            
            var routeGetMainIndices = route.GetMainIndices();

            MainIndicesService mainIndicesService = new MainIndicesService();

            var trend = await mainIndicesService.GetMainIndicesServiceAsync(routeGetMainIndices);

            return View(trend);
        }
    }
}
