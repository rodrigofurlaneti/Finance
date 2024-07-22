using Finance.Domain;
using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class LynchFormulaController : Controller
    {
        private readonly IAllStockExchangeService _allStockExchangeService;
        private readonly ILynchMethodologyService _lynchMethodologyService;

        public LynchFormulaController(IAllStockExchangeService allStockExchangeService, 
            ILynchMethodologyService lynchMethodologyService)
        {
            _allStockExchangeService = allStockExchangeService;
            _lynchMethodologyService = lynchMethodologyService;

        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _allStockExchangeService.GetAllActiveAsync();

                var resultService = await _lynchMethodologyService.GetLynchMethodologyAsync(model);

                return View(resultService);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in  LynchFormulaController/Index: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByDescendingYield([FromBody] IEnumerable<Lynch> returnService)
        {
            try
            {
                var orderedModel = returnService.OrderByDescending(b => b.PERatio).ToList();
                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in LynchFormulaController/OrderByDescendingYield: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByAscendingYield([FromBody] IEnumerable<Lynch> returnService)
        {
            try
            {
                var orderedModel = returnService.OrderBy(b => b.PERatio).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in LynchFormulaController/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByDescendingPrice([FromBody] IEnumerable<Lynch> returnService)
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
                Console.WriteLine("Error in LynchFormulaController/OrderByDescendingPrice: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByAscendingPrice([FromBody] IEnumerable<Lynch> returnService)
        {
            try
            {
                var orderedModel = returnService.OrderBy(b => b.Price).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in LynchFormulaController/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByDescendingResult([FromBody] IEnumerable<Lynch> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = returnService.OrderByDescending(b => b.PEGRatio).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in LynchFormulaController/OrderByDescendingPrice: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByAscendingResult([FromBody] IEnumerable<Lynch> returnService)
        {
            try
            {
                var orderedModel = returnService.OrderBy(b => b.PEGRatio).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in LynchFormulaController/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByKindFii([FromBody] IEnumerable<Lynch> model)
        {
            try
            {
                model = model.Where(b => b.Kind.Equals("fii")).ToList();

                if (model.Count().Equals(0))
                {
                    var modelResult = _allStockExchangeService.GetAllActive();

                    var returnService = _lynchMethodologyService.GetLynchMethodology(modelResult);

                    model = returnService.Where(b => b.Kind.Equals("fii")).ToList();
                }

                return Json(model);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in LynchFormulaController/OrderByKindFii: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByKindStock([FromBody] IEnumerable<Lynch> model)
        {
            try
            {
                model = model.Where(b => b.Kind.Equals("stock")).ToList();

                if (model.Count().Equals(0))
                {
                    var modelResult = _allStockExchangeService.GetAllActive();

                    var returnService = _lynchMethodologyService.GetLynchMethodology(modelResult);

                    model = returnService.Where(b => b.Kind.Equals("stock")).ToList();
                }

                return Json(model);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in LynchFormulaController/OrderByKindStock: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByKindBdr([FromBody] IEnumerable<Lynch> model)
        {
            try
            {
                model = model.Where(b => b.Kind.Equals("bdr")).ToList();

                if (model.Count().Equals(0))
                {
                    var modelResult = _allStockExchangeService.GetAllActive();

                    var returnService = _lynchMethodologyService.GetLynchMethodology(modelResult);

                    model = returnService.Where(b => b.Kind.Equals("bdr")).ToList();
                }

                return Json(model);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in LynchFormulaController/OrderByKindStock: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Clean()
        {
            try
            {
                var model = await _allStockExchangeService.GetAllActiveAsync();

                var returnService = _lynchMethodologyService.GetLynchMethodology(model);

                return Json(returnService);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in LynchFormulaController/Clean: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult RenderTable([FromBody] IEnumerable<Lynch> updatedModel)
        {
            try
            {
                return PartialView("_TabelaLynch", updatedModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in LynchFormulaController/RenderTable: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
