using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {

        private IAddUsuario ucAddUsuario;

        public UsuarioController(IAddUsuario ucAddUsuario)
        {
            this.ucAddUsuario = ucAddUsuario;
        }


        // GET: UsuarioController/Create
        public ActionResult Create(string mensaje)
        {
            ViewBag.UsuarioLogueado= HttpContext.Session.GetInt32("LogueadoNombre");
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
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                this.ucAddUsuario.AddUsuario(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Create), new { mensaje = e.Message });
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
