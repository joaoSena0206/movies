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

        [HttpGet("obra/{id}")]
        public IActionResult Index(int id)
        { 
           
            Filme filme = _filmeDAL.ObterDadosFilme(id);

            return View(filme);
        }
    }
}
