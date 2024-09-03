using Finance.Domain;
using Finance.Service.Implementation;
using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class AnalyzeIndicatorsController : Controller
    {
        private readonly IAnalyzeIndicatorsService _analyzeIndicatorsService;

        public AnalyzeIndicatorsController(IAnalyzeIndicatorsService analyzeIndicatorsService)
        {
            _analyzeIndicatorsService = analyzeIndicatorsService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _analyzeIndicatorsService.GetAllAnalyzeIndicatorsAsync();

            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingPrice([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.Price).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByDescendingPrice: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingPrice([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.Price).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingEvEbitda([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.EvEbitda).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByDescendingEvEbitda: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingEvEbitda([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.EvEbitda).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByAscendingEvEbitda: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingDlEbitda([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.DlEbitda).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByDescendingDlEbitda: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingDlEbitda([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.DlEbitda).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByAscendingDlEbitda: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingCompoundAnnualGrowthRate([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.CompoundAnnualGrowthRate).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByDescendingCompoundAnnualGrowthRate: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingCompoundAnnualGrowthRate([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.CompoundAnnualGrowthRate).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByAscendingCompoundAnnualGrowthRate: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> OrderByDescendingDividendYield([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.DividendYield).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByDescendingDividendYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingDividendYield([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.DividendYield).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByAscendingDividendYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingPriceProfit([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.PriceProfit).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByDescendingPriceProfit: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingPriceProfit([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.PriceProfit).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByAscendingPriceProfit: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingPriceOverAssetValue([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.PriceOverAssetValue).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByDescendingPriceOverAssetValue: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingPriceOverAssetValue([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.PriceOverAssetValue).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByAscendingPriceOverAssetValue: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByDescendingReturnOnEquity([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = await Task.Run(() => returnService.OrderByDescending(b => b.ReturnOnEquity).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByDescendingReturnOnEquity: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderByAscendingReturnOnEquity([FromBody] IEnumerable<Indicators> returnService)
        {
            try
            {
                var orderedModel = await Task.Run(() => returnService.OrderBy(b => b.ReturnOnEquity).ToList());

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in AnalyzeIndicators/OrderByAscendingReturnOnEquity: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Clean()
        {
            try
            {
                var model = await _analyzeIndicatorsService.GetAllAnalyzeIndicatorsAsync();

                return Json(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in StockExchange/Clean: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RenderTable([FromBody] IEnumerable<Indicators> updatedModel)
        {
            try
            {
                var partialViewResult = await Task.Run(() => PartialView("_TabelaAllAnalyzeIndicators", updatedModel));

                return partialViewResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AnalyzeIndicators/RenderTable: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }
    }
}
