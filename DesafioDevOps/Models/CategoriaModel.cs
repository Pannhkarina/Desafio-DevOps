using DesafioDevOps.Enums;
using DesafioDevOps.Helper;
using System.ComponentModel.DataAnnotations;

namespace DesafioDevOps.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário informar o titulo")]
        public string? Categoria { get; set; }

        [Required(ErrorMessage = "É necessário inserir uma descrição")]
        public string? Descricao { get; set;}
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

       


    }
}
