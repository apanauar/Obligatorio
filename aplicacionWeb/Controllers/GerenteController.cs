using Microsoft.AspNetCore.Mvc;

namespace aplicacionWeb.Controllers
{
    public class GerenteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
