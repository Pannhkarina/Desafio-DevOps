using DesafioDevOps.Data;
using DesafioDevOps.Models;

namespace DesafioDevOps.Repositorio
{
    public class CategoriaRespositorio : ICategoriaRepositorio
    {
        private readonly BancoContext _context;
        public CategoriaRespositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }
 
        public CategoriaModel ListarPorId(int id)
        {
            return _context.Categoria.FirstOrDefault(x => x.Id == id);
        }
        public List<CategoriaModel> BuscarTodos()
        {
            return _context.Categoria.ToList();
        }

        public CategoriaModel Adicionar(CategoriaModel categoria)
        {
            categoria.DataCadastro = DateTime.Now;
            _context.Categoria.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public CategoriaModel Atualizar(CategoriaModel categoria)
        {
            CategoriaModel categoriaDB = ListarPorId(categoria.Id);

            if (categoriaDB == null) throw new System.Exception("Houve um problema na atualização da categoria!");

            categoriaDB.Categoria = categoria.Categoria;
            categoriaDB.Descricao = categoria.Descricao;
            categoriaDB.DataAtualizacao = DateTime.Now;

            _context.Categoria.Update(categoriaDB);
            _context.SaveChanges();

            return categoriaDB;
        }
        public bool Apagar(int id)
        {
            CategoriaModel categoriaDB = ListarPorId(id);

            if (categoriaDB == null) throw new System.Exception("Houve um problema na exclusão da categoria!");

            _context.Categoria.Remove(categoriaDB);
            _context.SaveChanges();

            return true;
        }

        

    }
}
