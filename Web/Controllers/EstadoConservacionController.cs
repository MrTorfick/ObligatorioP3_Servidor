using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EstadoConservacionController : Controller
    {

        private IAddEstadoConservacion addEstadoConservacionUC;

        public EstadoConservacionController(IAddEstadoConservacion addEstadoConservacionUC)
        {
            this.addEstadoConservacionUC = addEstadoConservacionUC;
        }



        // GET: EstadoConservacionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EstadoConservacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EstadoConservacionController/Create
        public ActionResult Create(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        // POST: EstadoConservacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstadoConservacion estadoConservacion, int minimo, int maximo)
        {
            try
            {
                estadoConservacion.Rangos = new Rangos(minimo, maximo);
                addEstadoConservacionUC.AddEstadoConservacion(estadoConservacion);
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Create), new { mensaje = ex.Message });
            }
        }

        // GET: EstadoConservacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstadoConservacionController/Edit/5
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

        // GET: EstadoConservacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstadoConservacionController/Delete/5
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
