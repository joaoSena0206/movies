using Microsoft.AspNetCore.Mvc;

namespace movies.Controllers
{
    public class ObraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
