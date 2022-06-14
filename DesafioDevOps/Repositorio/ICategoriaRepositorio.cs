using DesafioDevOps.Models;

namespace DesafioDevOps.Repositorio
{
    public interface ICategoriaRepositorio
    {
       // SnippetModel BuscarPorLogin(string login);
        CategoriaModel ListarPorId(int id);
        List<CategoriaModel> BuscarTodos();
        CategoriaModel Adicionar(CategoriaModel categoria);
        CategoriaModel Atualizar(CategoriaModel categoria);
        bool Apagar(int id);
    }
}
