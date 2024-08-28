using Finance.Domain;
using Finance.Service.Implementation;
using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Finance.Web.Controllers
{
    public class AccessLogController : Controller
    {
        private readonly IAccessLogService _accessLogService;
        private readonly IGeolocationService _geolocationService;
        private readonly HttpClient _httpClient;

        public AccessLogController(IAccessLogService accessLogService,
            IGeolocationService geolocationService, HttpClient httpClient)
        {
            _accessLogService = accessLogService;
            _geolocationService = geolocationService;
            _httpClient = httpClient;
        }


        [HttpPost]
        public async Task<IActionResult> CaptureAccessData([FromBody] AccessLog accessLog)
        {
            if (accessLog == null)
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                // Log dos dados recebidos
                Console.WriteLine($"Latitude: {accessLog.Latitude}, Longitude: {accessLog.Longitude}, IP: {accessLog.InternetProtocol}");

                // Salvar o log de acesso
                await _accessLogService.PostAsync(accessLog);

                // Obter informações adicionais de geolocalização
                var apiKey = "66b12b35d8ae3445384266iqodc7c89";
                var apiUrl = $"https://geocode.maps.co/reverse?lat={accessLog.Latitude}&lon={accessLog.Longitude}&api_key={apiKey}";

                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var place = JsonSerializer.Deserialize<Place>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (place != null)
                {
                    await _geolocationService.PostAsync(place);
                }

                return Ok("Dados de acesso capturados e processados com sucesso.");
            }
            catch (HttpRequestException e)
            {
                Console.Error.WriteLine($"Erro na requisição: {e.Message}");
                return StatusCode(500, "Erro ao buscar dados de geolocalização.");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Erro: {e.Message}");
                return StatusCode(500, "Erro ao processar dados.");
            }
        }
    }
}
