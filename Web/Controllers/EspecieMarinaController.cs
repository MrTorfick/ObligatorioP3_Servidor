using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EspecieMarinaController : Controller
    {

        private IObtenerEcosistemasMarinos GetEcosistemasMarinosUC;
        private IObtenerEcosistemaMarinoPorId obtenerEcosistemaMarinoPorIdUC;
        private IAddEspecieMarina addEspecieMarinaUC;

        public EspecieMarinaController(
            IObtenerEcosistemasMarinos getEcosistemasMarinosUC,
            IObtenerEcosistemaMarinoPorId obtenerEcosistemaMarinoPorIdUC,
            IAddEspecieMarina addEspecieMarinaUC
            )
        {
            this.GetEcosistemasMarinosUC = getEcosistemasMarinosUC;
            this.obtenerEcosistemaMarinoPorIdUC = obtenerEcosistemaMarinoPorIdUC;
            this.addEspecieMarinaUC = addEspecieMarinaUC;
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
        public ActionResult Create(EspecieMarina especieMarina, IFormFile imagen, List<int> SelectedOptions)
        {
            try
            {
                especieMarina.EcosistemasMarinosVidaPosible = new List<EcosistemaMarino>();
                foreach (var id in SelectedOptions)
                {
                    EcosistemaMarino ecosistemaMarino = obtenerEcosistemaMarinoPorIdUC.ObtenerEcosistemaMarinoPorId(id);
                    if (ecosistemaMarino != null)
                    {
                        especieMarina.EcosistemasMarinosVidaPosible.Add(ecosistemaMarino);
                    }

                }
                addEspecieMarinaUC.AddEspecieMarina(especieMarina);
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
