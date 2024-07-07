﻿using Finance.Models;

namespace Finance.Web.Data.Interface
{
    public interface IAllStockExchangeData
    {
        IEnumerable<Active> GetAllActive();
        Task<IEnumerable<Active>> GetAllActiveAsync();
    }
}
