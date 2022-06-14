using DesafioDevOps.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioDevOps.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<SnippetModel> Snippet { get; set; }
        public DbSet<CategoriaModel> Categoria { get; set;} 
    }
}
