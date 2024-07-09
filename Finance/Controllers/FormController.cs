using Finance.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Finance.Web.Controllers
{
    public class FormController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string RecaptchaSecret = "6LfAlQsqAAAAANShv1R03J5Be0Mtjx7jIeqvK2OS";

        public FormController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpPost]
        [Route("submit-form")]
        public async Task<IActionResult> SubmitForm([FromForm] FormModel model)
        {
            var recaptchaResponse = model.RecaptchaResponse;

            if (string.IsNullOrEmpty(recaptchaResponse))
            {
                return BadRequest("reCAPTCHA response is missing.");
            }

            var verificationResult = await VerifyRecaptcha(recaptchaResponse);

            if (!verificationResult)
            {
                return BadRequest("reCAPTCHA verification failed.");
            }

            // Process the form data
            return Ok("Form submitted successfully.");
        }

        private async Task<bool> VerifyRecaptcha(string recaptchaResponse)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync($"https://www.google.com/recaptcha/api/siteverify?secret={RecaptchaSecret}&response={recaptchaResponse}", null);
            var responseString = await response.Content.ReadAsStringAsync();
            var responseJson = JsonSerializer.Deserialize<RecaptchaResponse>(responseString);

            return responseJson.Success;
        }
    }

}
