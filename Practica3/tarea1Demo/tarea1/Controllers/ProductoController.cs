using Microsoft.AspNetCore.Mvc;

namespace tarea1.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
