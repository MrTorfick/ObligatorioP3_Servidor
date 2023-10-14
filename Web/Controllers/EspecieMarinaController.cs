using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EspecieMarinaController : Controller
    {

        private IObtenerEcosistemasMarinos getEcosistemasMarinosUC;
        private IObtenerEcosistemaMarinoPorId obtenerEcosistemaMarinoPorIdUC;
        private IAddEspecieMarina addEspecieMarinaUC;
        private IObtenerAmenazas obtenerAmenazasUC;
        private IObtenerEspeciesMarinas obtenerEspeciesMarinasUC;

        public EspecieMarinaController(
            IObtenerEcosistemasMarinos getEcosistemasMarinosUC,
            IObtenerEcosistemaMarinoPorId obtenerEcosistemaMarinoPorIdUC,
            IAddEspecieMarina addEspecieMarinaUC,
            IObtenerAmenazas obtenerAmenazasUC,
            IObtenerEspeciesMarinas obtenerEspeciesMarinasUC
            )
        {
            this.getEcosistemasMarinosUC = getEcosistemasMarinosUC;
            this.obtenerEcosistemaMarinoPorIdUC = obtenerEcosistemaMarinoPorIdUC;
            this.addEspecieMarinaUC = addEspecieMarinaUC;
            this.obtenerAmenazasUC = obtenerAmenazasUC;
            this.obtenerEspeciesMarinasUC = obtenerEspeciesMarinasUC;
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
            ViewBag.EcosistemasMarinos = getEcosistemasMarinosUC.ObtenerEcosistemasMarinos();
            ViewBag.Amenazas = obtenerAmenazasUC.GetAmenazas();
            return View();
        }

        // POST: EspecieMarinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecieMarina especieMarina, IFormFile imagen, List<int> SelectedOptions)
        {
            try
            {

                especieMarina.EcosistemaMarinos = new List<EcosistemaMarino>();
                foreach (var id in SelectedOptions)
                {
                    EcosistemaMarino ecosistemaMarino = obtenerEcosistemaMarinoPorIdUC.ObtenerEcosistemaMarinoPorId(id);
                    if (ecosistemaMarino != null)
                    {
                        especieMarina.EcosistemaMarinos.Add(ecosistemaMarino);
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

        public ActionResult AsociarEspecieAEcosistema(string mensaje)
        {
            ViewBag.EcosistemasMarinos = getEcosistemasMarinosUC.ObtenerEcosistemasMarinos();
            ViewBag.EspeciesMarinas = obtenerEspeciesMarinasUC.ObtenerEspeciesMarinas();
            ViewBag.Mensaje = mensaje;
            return View();

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
