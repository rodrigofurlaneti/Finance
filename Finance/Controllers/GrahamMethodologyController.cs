using Finance.Domain;
using Finance.Service.Implementation;
using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class GrahamMethodologyController : Controller
    {
        private readonly IAllStockExchangeService _allStockExchangeService;
        private readonly IGrahamMethodologyService _grahamMethodologyService;

        public GrahamMethodologyController(IAllStockExchangeService allStockExchangeService, 
            IGrahamMethodologyService grahamMethodologyService)
        {
            _allStockExchangeService = allStockExchangeService;
            _grahamMethodologyService = grahamMethodologyService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _allStockExchangeService.GetAllActiveAsync();

                var resultService = await _grahamMethodologyService.GetGrahamMethodologyAsync(model);

                return View(resultService);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in GrahamMethodologyController/Index: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByDescendingYield([FromBody] IEnumerable<Graham> returnService)
        {
            try
            {
                var orderedModel = returnService.OrderByDescending(b => b.Yield_12m).ToList();
                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GrahamMethodologyController/OrderByDescendingYield: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByAscendingYield([FromBody] IEnumerable<Graham> returnService)
        {
            try
            {
                var orderedModel = returnService.OrderBy(b => b.Yield_12m).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in GrahamMethodologyController/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByDescendingPrice([FromBody] IEnumerable<Graham> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = returnService.OrderByDescending(b => b.Price).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in GrahamMethodologyController/OrderByDescendingPrice: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByAscendingPrice([FromBody] IEnumerable<Graham> returnService)
        {
            try
            {
                var orderedModel = returnService.OrderBy(b => b.Price).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in GrahamMethodologyController/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByDescendingResult([FromBody] IEnumerable<Graham> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = returnService.OrderByDescending(b => b.Result).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in GrahamMethodologyController/OrderByDescendingPrice: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByAscendingResult([FromBody] IEnumerable<Graham> returnService)
        {
            try
            {
                var orderedModel = returnService.OrderBy(b => b.Result).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in GrahamMethodologyController/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByKindFii([FromBody] IEnumerable<Graham> model)
        {
            try
            {
                model = model.Where(b => b.Kind.Equals("fii")).ToList();

                if (model.Count().Equals(0))
                {
                    var modelResult = _allStockExchangeService.GetAllActive();

                    var returnService = _grahamMethodologyService.GetGrahamMethodology(modelResult);

                    model = returnService.Where(b => b.Kind.Equals("fii")).ToList();
                }

                return Json(model);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in GrahamMethodologyController/OrderByKindFii: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByKindStock([FromBody] IEnumerable<Graham> model)
        {
            try
            {
                model = model.Where(b => b.Kind.Equals("stock")).ToList();

                if (model.Count().Equals(0))
                {
                    var modelResult = _allStockExchangeService.GetAllActive();

                    var returnService = _grahamMethodologyService.GetGrahamMethodology(modelResult);

                    model = returnService.Where(b => b.Kind.Equals("stock")).ToList();
                }

                return Json(model);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in GrahamMethodologyController/OrderByKindStock: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByKindBdr([FromBody] IEnumerable<Graham> model)
        {
            try
            {
                model = model.Where(b => b.Kind.Equals("bdr")).ToList();

                if (model.Count().Equals(0))
                {
                    var modelResult = _allStockExchangeService.GetAllActive();

                    var returnService = _grahamMethodologyService.GetGrahamMethodology(modelResult);

                    model = returnService.Where(b => b.Kind.Equals("bdr")).ToList();
                }

                return Json(model);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in GrahamMethodologyController/OrderByKindStock: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Clean()
        {
            try
            {
                var model = await _allStockExchangeService.GetAllActiveAsync();

                var returnService = await _grahamMethodologyService.GetGrahamMethodologyAsync(model);

                return Json(returnService);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GrahamMethodologyController/Clean: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult RenderTable([FromBody] IEnumerable<Graham> updatedModel)
        {
            try
            {
                return PartialView("_TabelaGraham", updatedModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GrahamMethodologyController/RenderTable: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
