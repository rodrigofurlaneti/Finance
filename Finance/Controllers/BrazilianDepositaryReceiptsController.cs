﻿using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace Finance.Web.Controllers
{
    public class BrazilianDepositaryReceiptsController : Controller
    {
        private readonly IBrazilianDepositaryReceiptsService _brazilianDepositaryReceiptsService;

        public BrazilianDepositaryReceiptsController(IBrazilianDepositaryReceiptsService brazilianDepositaryReceiptsService)
        {
            _brazilianDepositaryReceiptsService = brazilianDepositaryReceiptsService;
        }
        public IActionResult Index(int? page)
        {
            var items = _brazilianDepositaryReceiptsService.GetAllActiveBdr();

            int pageSize = 100; // Tamanho da página

            int pageNumber = (page ?? 1); // Número da página atual

            return View(items.ToPagedList(pageNumber, pageSize));
        }
    }
}
