using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

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
            ViewBag.UsuarioLogueado = HttpContext.Session.GetInt32("LogueadoNombre");
            ViewBag.Mensaje = mensaje;
            return View();

            /*
            if (ViewBag.UsuarioLogueado == "admin1")
            {
                return View();
            }
            else { 
                return RedirectToAction("Index", "Home");
            }
            */

        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario, int slcTipoUsuario)
        {
            try
            {
                TipoUsuario tipoUsuario = (TipoUsuario)slcTipoUsuario;
                usuario.TipoUsuario = tipoUsuario.ToString();

                this.ucAddUsuario.AddUsuario(usuario);
                return RedirectToAction("Home", "Index");
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Create), new { mensaje = e.Message });
            }
        }



        public IActionResult Login(string mensaje)
        {

            ViewBag.Mensaje = mensaje;
            return View();
        }



        [HttpPost]
        public IActionResult Login(string Nombre, string Contrasenia)
        {

            try
            {
                Usuario user = ObtenerUsuario.ObtenerUsuarioPorCredenciales(Nombre, Contrasenia);
                if (user != null)
                {
                    HttpContext.Session.SetString("LogueadoNombre", Nombre);
                    HttpContext.Session.SetString("LogueadoRol", user.TipoUsuario);
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




        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
