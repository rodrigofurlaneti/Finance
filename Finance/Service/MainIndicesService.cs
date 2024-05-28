
using Finance.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Finance.Service
{
    public class MainIndicesService
    {

        public MainIndicesService() { }

        public async Task<Trend> GetMainIndicesServiceAsync(Finance.Routes.Route route) 
        {
            Trend trend = new Trend();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(route.RouteValue);

            client.DefaultRequestHeaders.Accept.Add(

            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(route.RouteValue);

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = await response.Content.ReadAsStringAsync();

                trend = JsonSerializer.Deserialize<Trend>(dataObjects);
            }

            client.Dispose();

            return trend;
        }
    }
}
