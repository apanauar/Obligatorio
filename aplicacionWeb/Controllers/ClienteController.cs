using Microsoft.AspNetCore.Mvc;

namespace aplicacionWeb.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
