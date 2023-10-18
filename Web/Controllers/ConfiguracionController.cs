using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ConfiguracionController : Controller
    {

        private IObtenerConfiguraciones _obtenerConfiguracionesUC;
        private IUpdateConfiguracion _updateConfiguracionUC;
        private IObtenerConfiguracionPorNombre _obtenerConfiguracionPorNombreUC;


        public ConfiguracionController(
            IObtenerConfiguraciones obtenerConfiguracionesUC,
            IUpdateConfiguracion updateConfiguracionUC,
            IObtenerConfiguracionPorNombre obtenerConfiguracionPorNombreUC

            )
        {
            this._obtenerConfiguracionesUC = obtenerConfiguracionesUC;
            this._updateConfiguracionUC = updateConfiguracionUC;
            this._obtenerConfiguracionPorNombreUC = obtenerConfiguracionPorNombreUC;
        }

        // GET: ConfiguracionController
        public ActionResult Index()
        {
            return View(_obtenerConfiguracionesUC.ObtenerConfiguraciones());
        }

        // GET: ConfiguracionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConfiguracionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConfiguracionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ConfiguracionController/Edit/5
        public ActionResult Edit(string NombreAtributo, string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View(_obtenerConfiguracionPorNombreUC.ObtenerConfiguracionPorNombre(NombreAtributo));
        }

        // POST: ConfiguracionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Configuracion configuracion)
        {
            try
            {
                _updateConfiguracionUC.UpdateConfiguracion(configuracion, HttpContext.Session.GetString("LogueadoNombre"));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Edit", new { NombreAtributo = configuracion.NombreAtributo, mensaje = ex.Message });
            }
        }

        // GET: ConfiguracionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConfiguracionController/Delete/5
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
