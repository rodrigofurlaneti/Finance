using Finance.Data.Interface;
using Finance.Data.Repository;
using Finance.Domain;
using Finance.Service.Interface;

namespace Finance.Service.Implementation
{
    public class ActiveGetHighLowB3Service : IActiveGetHighLowB3Service
    {
        private readonly IActiveGetHighLowB3Data _activeGetHighLowB3Data;

        public ActiveGetHighLowB3Service(IActiveGetHighLowB3Data activeGetHighLowB3Data)
        {
            _activeGetHighLowB3Data = activeGetHighLowB3Data;
        }

        public async Task<IEnumerable<Active>> GetAllActiveHighLowB3Async()
        {
            return await _activeGetHighLowB3Data.GetAllActiveHighLowB3Async();
        }
    }
}
