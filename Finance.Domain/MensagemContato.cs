using System.ComponentModel.DataAnnotations;

namespace Finance.Domain
{
    public class MensagemContato
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "O nome só pode conter caracteres alfabéticos.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A mensagem é obrigatória.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "A mensagem só pode conter caracteres alfabéticos.")]
        public string Mensagem { get; set; }

        public string RecaptchaResponse { get; set; }
    }
}
