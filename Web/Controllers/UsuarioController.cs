using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {

        private IAddUsuario ucAddUsuario;
        private IObtenerUsuarioPorCredenciales ObtenerUsuario;

        public UsuarioController(IAddUsuario ucAddUsuario, IObtenerUsuarioPorCredenciales obtenerUsuario)
        {
            this.ucAddUsuario = ucAddUsuario;
            ObtenerUsuario = obtenerUsuario;
        }


        // GET: UsuarioController/Create
        public ActionResult Create(string mensaje)
        {

            ViewBag.Mensaje = mensaje;
            if (HttpContext.Session.GetString("LogueadoRol") == "admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario, string Administrador)
        {
            try
            {

                if (Administrador != null)
                {
                    usuario.EsAdmin = true;
                }
                else
                {
                    usuario.EsAdmin = false;
                }

                this.ucAddUsuario.AddUsuario(usuario, HttpContext.Session.GetString("LogueadoNombre"));
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Create), new { mensaje = e.Message });
            }
        }



        public IActionResult Login(string mensaje)
        {

            string? nombreLogueado = HttpContext.Session.GetString("LogueadoNombre");

            if (nombreLogueado != null)
            {
                return View();
            }
            else
            {
                RedirectToAction("Index", "Home");
            }

            ViewBag.Mensaje = mensaje;
            return View();
        }


        /*
        [HttpPost]
        public IActionResult Login(string Nombre, string Contrasenia)
        {

            try
            {
                Usuario user = ObtenerUsuario.ObtenerUsuarioPorCredenciales(Nombre, Contrasenia);
                if (user != null)
                {
                    HttpContext.Session.SetString("LogueadoNombre", Nombre);

                    if (user.EsAdmin)
                    {
                        HttpContext.Session.SetString("LogueadoRol", "admin");
                    }
                    else
                    {
                        HttpContext.Session.SetString("LogueadoRol", "default");
                    }
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    return RedirectToAction(nameof(Login), new { mensaje = "Usuario no encontrado" });
                }
            }
            catch (Exception)
            {

                throw new Exception("Ha ocurrido un error inesperado. Intentelo nuevamente");
            }

        }
        */

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Usuario");
        }





    }
}
