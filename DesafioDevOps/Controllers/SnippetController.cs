using DesafioDevOps.Models;
using DesafioDevOps.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDevOps.Controllers
{
    public class SnippetController : Controller
    {
        private readonly ISnippetRepositorio _snippetRepositorio;

        
       
        public SnippetController(ISnippetRepositorio snippetRepositorio)
        {
            _snippetRepositorio = snippetRepositorio;
        }
        public IActionResult Index()
        {
            List<SnippetModel> snippet = _snippetRepositorio.BuscarTodos();

            return View(snippet);
        }

        public IActionResult Criar()
        {

            
            return View();
        }
        public IActionResult Editar(int id)
        {
            SnippetModel snippet = _snippetRepositorio.ListarPorId(id);
            return View(snippet);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            SnippetModel snippet = _snippetRepositorio.ListarPorId(id);
            return View(snippet);
        }

        public IActionResult Apagar(int id)
        {

            try
            {
                bool apagado = _snippetRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "O snippet foi excluído com sucesso!";
                }
                else
                {
                    TempData["MensagemSucesso"] = "Ops, não conseguimos excluir o snippt!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemSucesso"] = $"Ops, não conseguimos excluir o snippet, tente novamente. Detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }


        }

        [HttpPost]
        public IActionResult Editar(SnippetModel snippet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _snippetRepositorio.Atualizar(snippet);
                    TempData["MensagemSucesso"] = "Snippet atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", snippet);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar o snippet, tente novamente. Detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Criar(SnippetModel snippet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _snippetRepositorio.Adicionar(snippet);
                    TempData["MensagemSucesso"] = "Snippet cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }


                return View(snippet);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o snippet, tente novamente. Detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }


    }
}
