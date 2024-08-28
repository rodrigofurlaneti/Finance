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
    public class AccessLogService : IAccessLogService
    {
        private readonly IAccessLogData _accessLogData;

        public AccessLogService(IAccessLogData accessLogB3Data)
        {
            _accessLogData = accessLogB3Data;
        }

        public async Task<IEnumerable<AccessLog>> GetAsync()
        {
            return await _accessLogData.GetAsync();
        }

        public async Task PostAsync(AccessLog accessLog)
        {
            await _accessLogData.PostAsync(accessLog);
        }

    }
}
