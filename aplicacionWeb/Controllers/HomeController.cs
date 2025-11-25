using aplicacionWeb.Models;
using BibliotecaDeClases;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

        
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email , string Contrasenia)
        {
            try{
             Usuario usarioEncontrado = Sistema.instancia.BuscarUsuarioPorEmailYContrasenia(Email, Contrasenia);
            }
            catch(Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
                return View();
            }
             
             return View();
        }
    }
}
