using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EspecieMarinaController : Controller
    {

        private IObtenerEcosistemasMarinos GetEcosistemasMarinosUC;

        public EspecieMarinaController(IObtenerEcosistemasMarinos getEcosistemasMarinosUC)
        {
            this.GetEcosistemasMarinosUC = getEcosistemasMarinosUC;
        }


        // GET: EspecieMarinaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EspecieMarinaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EspecieMarinaController/Create
        public ActionResult Create(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            ViewBag.EcosistemasMarinos = GetEcosistemasMarinosUC.ObtenerEcosistemasMarinos();
            return View();
        }

        // POST: EspecieMarinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecieMarina especieMarina, IFormFile imagen)
        {
            try
            {
                List<string> selectedOptions = new List<string>(Request.Form["SelectedOptions"].ToString().Split(","));

                //List<string>selectedOptions = Request.Form["SelectedOptions"];
             //   especieMarina.EcosistemasMarinosVidaPosible.AddRange(selectedOptions);              

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EspecieMarinaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EspecieMarinaController/Edit/5
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

        // GET: EspecieMarinaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EspecieMarinaController/Delete/5
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
