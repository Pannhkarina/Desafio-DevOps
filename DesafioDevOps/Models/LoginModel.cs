using System.ComponentModel.DataAnnotations;

namespace DesafioDevOps.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="É necessário informar o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "É necessário informar a senha")]
        public string Senha { get; set; }
    }
}
