﻿using Finance.Web.Service;
using Finance.Web.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class AllStockExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var allStockExchangeService = new AllStockExchangeService();

            var model = await allStockExchangeService.GetAllActiveAsync();

            return View(model);
        }
    }
}
