using System.ComponentModel.DataAnnotations;

namespace DesafioDevOps.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "É necessário informar o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe seu e-mail")]
        public string Email { get; set; }
    }
}
