using DesafioDevOps.Models;
using DesafioDevOps.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDevOps.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }
        public IActionResult Index()
        {
            List<CategoriaModel> categoria = _categoriaRepositorio.BuscarTodos();

            return View(categoria);
        }

        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            CategoriaModel categoria = _categoriaRepositorio.ListarPorId(id);
            return View(categoria);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            CategoriaModel categoria = _categoriaRepositorio.ListarPorId(id);
            return View(categoria);
        }

        public IActionResult Apagar(int id)
        {

            try
            {
                bool apagado = _categoriaRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "A categoria foi excluída com sucesso!";
                }
                else
                {
                    TempData["MensagemSucesso"] = "Ops, não conseguimos excluir a categoria!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemSucesso"] = $"Ops, não conseguimos excluir a categoria, tente novamente. Detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }


        }

        [HttpPost]
        public IActionResult Editar(CategoriaModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoriaRepositorio.Atualizar(categoria);
                    TempData["MensagemSucesso"] = "Categoria atualizada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", categoria);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar a categoria, tente novamente. Detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Criar(CategoriaModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoriaRepositorio.Adicionar(categoria);
                    TempData["MensagemSucesso"] = "Categoria cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }


                return View(categoria);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar a categoria, tente novamente. Detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }


    }
}
