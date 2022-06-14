using DesafioDevOps.Models;

namespace DesafioDevOps.Repositorio
{
    public interface ISnippetRepositorio
    {
       // SnippetModel BuscarPorLogin(string login);
        SnippetModel ListarPorId(int id);
        List<SnippetModel> BuscarTodos();
        SnippetModel Adicionar(SnippetModel snippet);
        SnippetModel Atualizar(SnippetModel snippet);
      
        bool Apagar(int id);
    }
}
