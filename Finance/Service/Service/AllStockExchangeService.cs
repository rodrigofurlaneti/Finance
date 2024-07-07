﻿using Finance.Models;
using Finance.Web.Data.Interface;
using Finance.Web.Service.Interface;

namespace Finance.Web.Service.Service
{
    public class AllStockExchangeService : IAllStockExchangeService
    {
        private readonly IAllStockExchangeData _allStockExchangeData;

        public AllStockExchangeService(IAllStockExchangeData allStockExchangeData)
        {
            _allStockExchangeData = allStockExchangeData;
        }

        public IEnumerable<Active> GetAllActive() 
        {
            return _allStockExchangeData.GetAllActive();
        }
        public async Task<IEnumerable<Active>> GetAllActiveAsync()
        {
            return await _allStockExchangeData.GetAllActiveAsync();
        }
    }
}
