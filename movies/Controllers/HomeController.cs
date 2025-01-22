using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using movies.Data;

namespace movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly FilmeDAL _filmeDAL;

        public HomeController(IConfiguration config)
        {
            Banco banco = new Banco(config.GetConnectionString("DefaultConnection")!);
            _filmeDAL = new FilmeDAL(banco);
        }

        public IActionResult Index()
        {
            try
            {
                HomeViewModel homeViewModel = new HomeViewModel();
                homeViewModel.FilmesPopulares = _filmeDAL.ObterFilmes("populares");
                homeViewModel.FilmesRecentes = _filmeDAL.ObterFilmes("recentes");
                homeViewModel.FilmesAleatorios = _filmeDAL.ObterFilmes("aleatorios");

                return View(homeViewModel);
            }
            catch
            {
                return View("Erro ao carregar os filmes!");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
