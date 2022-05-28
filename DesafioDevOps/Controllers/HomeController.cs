using DesafioDevOps.Filters;
using DesafioDevOps.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesafioDevOps.Controllers
{
    [PaginaParaUsuarioLogado]

    public class HomeController : Controller
    {
     
        public IActionResult Index()
        {
            HomeModel home = new HomeModel();

            return View(home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}