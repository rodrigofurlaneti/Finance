using Finance.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Text.Json;

namespace Finance.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GoogleReCaptchaSettings _googleReCaptchaSettings;

        public HomeController(ILogger<HomeController> logger, 
            IOptions<GoogleReCaptchaSettings> googleReCaptchaSettings)
        {
            _logger = logger;
            _googleReCaptchaSettings = googleReCaptchaSettings.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(MensagemContato model)
        {
            if (!await IsCaptchaValid(Request.Form["g-recaptcha-response"]))
            {
                TempData["MessageErro"] = "Verifique se você não é um robô, o captcha está invalido!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["MessageSuccess"] = "Formulário enviado com sucesso, nossa equipe já vai entrar em contato com você!";
                return RedirectToAction("Index");
            }
        }

        private async Task<bool> IsCaptchaValid(string captchaResponse)
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?secret={_googleReCaptchaSettings.SecretKey}&response={captchaResponse}");
            var result = JsonSerializer.Deserialize<RecaptchaResponse>(response);
            if(result.Success)
                return result.Success;
            else
                return false;
        }
    }
}