using Finance.Data.Interface;
using Finance.Data.Repository;
using Finance.Domain;
using Finance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Service.Implementation
{
    public class AnalyzeIndicatorsService : IAnalyzeIndicatorsService
    {
        private readonly IAnalyzeIndicatorsData _analyzeIndicatorsData;

        public AnalyzeIndicatorsService(IAnalyzeIndicatorsData analyzeIndicatorsData)
        {
            _analyzeIndicatorsData = analyzeIndicatorsData;
        }
        public async Task<IEnumerable<Indicators>> GetAllAnalyzeIndicatorsAsync()
        {
            return await _analyzeIndicatorsData.GetAllAnalyzeIndicatorsAsync();
        }
    }
}
