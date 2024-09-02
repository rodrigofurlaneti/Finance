﻿using Finance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Service.Interface
{
    public interface IAnalyzeIndicatorsService
    {
        Task<IEnumerable<Indicators>> GetAllAnalyzeIndicatorsAsync();
    }
}
