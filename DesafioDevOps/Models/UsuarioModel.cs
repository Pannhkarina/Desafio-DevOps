using DesafioDevOps.Enums;
using DesafioDevOps.Helper;
using System.ComponentModel.DataAnnotations;

namespace DesafioDevOps.Models
{
    public class UsuarioModel
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
        [Required(ErrorMessage = "A senha do usuário é obrigatório")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; } 
        public DateTime? DataAtualizacao { get; set; } 
        
        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();

            return novaSenha;
        }


    }
}
