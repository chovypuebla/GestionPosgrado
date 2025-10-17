using Microsoft.AspNetCore.Mvc;

namespace gestorFcc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Inicio - Gesttor de Posgrado de la FCC";
            return View();
        }
    }
}
