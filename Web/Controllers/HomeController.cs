using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        /*
        [HttpPost]
        
        public IActionResult Login(string Nombre, string Contrasenia)
        {
            //TODO
        }
        */

    }
}

       
   