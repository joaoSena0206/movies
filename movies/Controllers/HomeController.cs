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
            HomeViewModel homeViewModel = new HomeViewModel();

            try
            {
                homeViewModel.FilmesPopulares = _filmeDAL.ObterFilmes("populares");
                homeViewModel.FilmesRecentes = _filmeDAL.ObterFilmes("recentes");
                homeViewModel.FilmesAleatorios = _filmeDAL.ObterFilmes("aleatorios");
            }
            catch (Exception ex)
            {
                homeViewModel.MensagemErro = "Erro ao carregar os filmes!";

                throw new Exception(ex.Message);
            }

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
