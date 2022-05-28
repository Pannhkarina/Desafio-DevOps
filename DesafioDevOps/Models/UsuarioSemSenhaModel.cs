using DesafioDevOps.Enums;
using System.ComponentModel.DataAnnotations;

namespace DesafioDevOps.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do usuario é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O nome do login é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }   
    }
}
