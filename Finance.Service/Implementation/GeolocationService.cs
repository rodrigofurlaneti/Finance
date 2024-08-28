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
    public class GeolocationService : IGeolocationService
    {
        private readonly IGeolocationData _geolocationData;

        public GeolocationService(IGeolocationData geolocationData)
        {
            _geolocationData = geolocationData;
        }

        public async Task PostAsync(Place place)
        {
            await _geolocationData.PostAsync(place);
        }
    }
}
