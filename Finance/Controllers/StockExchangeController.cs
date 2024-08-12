using Finance.Domain;
using Finance.Service.Implementation;
using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using X.PagedList.Extensions;

namespace Finance.Web.Controllers
{
    public class StockExchangeController : Controller
    {
        private readonly IStockExchangeService _stockExchangeService;

        public StockExchangeController(IStockExchangeService stockExchangeService)
        {
            _stockExchangeService = stockExchangeService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var items = await _stockExchangeService.GetStockExchangeActiveAsync();

            return View(items);

        }

        [HttpPost]
        public IActionResult OrderByDescendingPrice([FromBody] IEnumerable<Active> returnService)
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
                Console.WriteLine("Error in StockExchangeController/OrderByDescendingPrice: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByAscendingPrice([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                var orderedModel = returnService.OrderBy(b => b.Price).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in StockExchangeController/OrderByAscendingYield: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByDescendingChangeLastDay([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = returnService.OrderByDescending(b => b.ChangePercent).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in StockExchangeController/OrderByDescendingChangeLastDay: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByAscendingChangeLastDay([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                var orderedModel = returnService.OrderBy(b => b.ChangePercent).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in StockExchangeController/OrderByAscendingChangeLastDay: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByDescendingLastDayVariation([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = returnService.OrderByDescending(b => b.ChangePrice).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in StockExchangeController/OrderByDescendingLastDayVariation: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByAscendingLastDayVariation([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                var orderedModel = returnService.OrderBy(b => b.ChangePrice).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in StockExchangeController/OrderByAscendingLastDayVariation: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByDescendingYieldLastTwelveMonthsPercentage([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = returnService.OrderByDescending(b => b.Financials.Dividends.Yield_12m).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in StockExchangeController/OrderByDescendingYieldLastTwelveMonthsPercentage: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByAscendingYieldLastTwelveMonthsPercentage([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                var orderedModel = returnService.OrderBy(b => b.Financials.Dividends.Yield_12m).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in StockExchangeController/OrderByAscendingYieldLastTwelveMonthsPercentage: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByDescendingYieldLastTwelveRealMonths([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = returnService.OrderByDescending(b => b.Financials.Dividends.Yield_12m_sum).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in StockExchangeController/OrderByDescendingYieldLastTwelveMonthsPercentage: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByAscendingYieldLastTwelveRealMonths([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                var orderedModel = returnService.OrderBy(b => b.Financials.Dividends.Yield_12m_sum).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in StockExchangeController/OrderByAscendingYieldLastTwelveMonthsPercentage: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByDescendingMarketValue([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                // Ordenar a lista pela coluna Yield em ordem decrescente
                var orderedModel = returnService.OrderByDescending(b => b.MarketCap).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in StockExchangeController/OrderByDescendingMarketValue: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult OrderByAscendingMarketValue([FromBody] IEnumerable<Active> returnService)
        {
            try
            {
                var orderedModel = returnService.OrderBy(b => b.MarketCap).ToList();

                return Json(orderedModel);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error in StockExchangeController/OrderByAscendingMarketValue: " + ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Clean()
        {
            try
            {
                var model = await _stockExchangeService.GetStockExchangeActiveAsync();

                return Json(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in StockExchangeController/Clean: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult RenderTable([FromBody] IEnumerable<Active> updatedModel)
        {
            try
            {
                return PartialView("_TabelaStock", updatedModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in StockExchangeController/RenderTable: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
