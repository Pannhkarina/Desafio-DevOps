using DesafioDevOps.Enums;
using DesafioDevOps.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioDevOps.Models
{
    public class SnippetModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário informar o conteúdo")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "É necessário informar a tag")]
        public string Tag { get; set; }
        public PermissaoEnum? Permissao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        [Required]
        [ForeignKey("Categorias")]
        public int CategoriaId { get; set; }
        public virtual CategoriaModel Categorias { get; set; }  

        


    }
}
