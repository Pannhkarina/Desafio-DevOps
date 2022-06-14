using DesafioDevOps.Data;
using DesafioDevOps.Models;

namespace DesafioDevOps.Repositorio
{
    public class SnippetRespositorio : ISnippetRepositorio
    {
        private readonly BancoContext _context;
        public SnippetRespositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }
 
        public SnippetModel ListarPorId(int id)
        {
            return _context.Snippet.FirstOrDefault(x => x.Id == id);
        }
        public List<SnippetModel> BuscarTodos()
        {
            return _context.Snippet.ToList();
        }

        public SnippetModel Adicionar(SnippetModel snippet)
        {
            snippet.DataCadastro = DateTime.Now;
            _context.Snippet.Add(snippet);
            _context.SaveChanges();
            return snippet;
        }

        public SnippetModel Atualizar(SnippetModel snippet)
        {
            SnippetModel snippetDB = ListarPorId(snippet.Id);

            if (snippetDB == null) throw new System.Exception("Houve um problema na atualização do snippet!");

            snippetDB.Categorias = snippet.Categorias;
            snippetDB.Conteudo = snippet.Conteudo;
            snippetDB.Tag = snippet.Tag;
            snippetDB.Permissao = snippet.Permissao;
            snippetDB.DataAtualizacao = DateTime.Now;

            _context.Snippet.Update(snippetDB);
            _context.SaveChanges();

            return snippetDB;
        }
        public bool Apagar(int id)
        {
            SnippetModel snippetDB = ListarPorId(id);

            if (snippetDB == null) throw new System.Exception("Houve um problema na exclusão do snippet!");

            _context.Snippet.Remove(snippetDB);
            _context.SaveChanges();

            return true;
        }

       
    }
}
