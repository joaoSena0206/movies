using Microsoft.AspNetCore.Mvc;
using movies.Data;

namespace movies.Controllers
{
    public class ObraController : Controller
    {
        private FilmeDAL _filmeDAL;

        public ObraController(IConfiguration configuration)
        {
            Banco banco = new Banco(configuration.GetConnectionString("DefaultConnection")!);
            _filmeDAL = new FilmeDAL(banco);
        }

        public IActionResult Index(int id)
        {  
            Filme filme = _filmeDAL.ObterDadosFilme(id);

            return View(filme);
        }

        public IActionResult Pesquisar(string valor)
        {
            List<Filme> filmes = _filmeDAL.PesquisarFilmes(valor);

            return Ok(filmes);
        }
    }
}
