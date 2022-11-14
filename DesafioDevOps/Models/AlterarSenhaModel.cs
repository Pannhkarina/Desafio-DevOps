using System.ComponentModel.DataAnnotations;

namespace DesafioDevOps.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite sua senha atual")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Digite uma nova senha")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme a nova senha")]
        [Compare("NovaSenha", ErrorMessage = "A senha não confere com a nova senha")]
        public string ConfirmarNovaSenha { get; set; }

    }
}
