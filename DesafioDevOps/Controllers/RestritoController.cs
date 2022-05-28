using DesafioDevOps.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDevOps.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
