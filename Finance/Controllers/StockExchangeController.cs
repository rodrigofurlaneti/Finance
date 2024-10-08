﻿using Finance.Domain;
using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class StockExchangeController : Controller
    {
        private readonly IStockExchangeService _stockExchangeService;

        public StockExchangeController(IStockExchangeService stockExchangeService)
        {
            _stockExchangeService = stockExchangeService;
        }

        public async Task<IActionResult> Index()
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
                Console.WriteLine("Error in StockExchange/OrderByDescendingPrice: " + ex.Message);

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
                Console.WriteLine("Error in StockExchange/OrderByAscendingYield: " + ex.Message);

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
                Console.WriteLine("Error in StockExchange/OrderByDescendingChangeLastDay: " + ex.Message);

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
                Console.WriteLine("Error in StockExchange/OrderByAscendingChangeLastDay: " + ex.Message);

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
                Console.WriteLine("Error in StockExchange/OrderByDescendingLastDayVariation: " + ex.Message);

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
                Console.WriteLine("Error in StockExchange/OrderByAscendingLastDayVariation: " + ex.Message);

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
                Console.WriteLine("Error in StockExchange/OrderByDescendingYieldLastTwelveMonthsPercentage: " + ex.Message);

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
                Console.WriteLine("Error in StockExchange/OrderByAscendingYieldLastTwelveMonthsPercentage: " + ex.Message);

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
                Console.WriteLine("Error in StockExchange/OrderByDescendingYieldLastTwelveMonthsPercentage: " + ex.Message);

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
                Console.WriteLine("Error in StockExchange/OrderByAscendingYieldLastTwelveMonthsPercentage: " + ex.Message);

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
                Console.WriteLine("Error in StockExchange/OrderByDescendingMarketValue: " + ex.Message);

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
                Console.WriteLine("Error in StockExchange/OrderByAscendingMarketValue: " + ex.Message);

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
                Console.WriteLine("Error in StockExchange/Clean: " + ex.Message);
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
                Console.WriteLine("Error in StockExchange/RenderTable: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
