using Finance.Data.Interface;
using Finance.Domain;
using Finance.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Finance.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IActiveGetHighLowB3Service _activeGetHighLowB3Service;

        public HomeController(IConfiguration configuration, IHttpClientFactory httpClientFactory,
            IActiveGetHighLowB3Service activeGetHighLowB3Service)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _activeGetHighLowB3Service = activeGetHighLowB3Service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["HighLowB3"] = await _activeGetHighLowB3Service.GetAllActiveHighLowB3Async();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(MensagemContato mensagemContato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (mensagemContato.RecaptchaResponse == null)
                    {
                        return Json(new { success = false, errors = new List<string> { "Falha na verificação do reCAPTCHA. O Recaptcha Response está nulo. Por favor, tente novamente." } });
                    }
                    else
                    {
                        if (mensagemContato.RecaptchaResponse.Equals(string.Empty))
                        {
                            return Json(new { success = false, errors = new List<string> { "Falha na verificação do reCAPTCHA. O Recaptcha Response está vazio. Por favor, tente novamente." } });
                        }
                        else
                        {
                            var captchaResult = await ValidateCaptchaV3(mensagemContato);

                            if (captchaResult.Success && captchaResult.Score > 0.3)
                            {
                                // Processar o formulário aqui (ex: salvar no banco de dados, enviar email, etc.)
                                return Json(new { success = true, message = "Formulário enviado com sucesso!" });
                            }
                            else
                            {
                                return Json(new { success = false, errors = new List<string> { "Falha na verificação do reCAPTCHA. Por favor, tente novamente." } });
                            }
                        }
                    }
                }
                else
                {
                    return Json(new { success = false, errors = new List<string> { "Falha na verificação do reCAPTCHA. Modelo no back-end inválido. Por favor, tente novamente." } });
                }

            }
            catch (Exception ex)
            {
                // Registrar o erro
                Console.WriteLine($"Erro ao verificar o reCAPTCHA: {ex.Message}");

                return Json(new { success = false, errors = new List<string> { "Erro no servidor. Tente novamente mais tarde." } });
            }
        }

        private async Task<RecaptchaResponse> ValidateCaptchaV3(MensagemContato mensagemContato)
        {
            var secretKey = _configuration["GoogleReCaptcha:SecretKey"];

            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={mensagemContato.RecaptchaResponse}", null);

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<RecaptchaResponse>(responseString);
        }
    }
}