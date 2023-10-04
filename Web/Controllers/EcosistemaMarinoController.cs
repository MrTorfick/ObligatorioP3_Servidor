using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EcosistemaMarinoController : Controller
    {

        private IAddEcosistemaMarino addEcosistemaMarinoUC;

        public EcosistemaMarinoController(IAddEcosistemaMarino addEcosistemaMarinoUC)
        {
            this.addEcosistemaMarinoUC = addEcosistemaMarinoUC;
        }

        // GET: EcosistemaMarinoController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: EcosistemaMarinoController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EcosistemaMarinoController1/Create
        public ActionResult Create(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        // POST: EcosistemaMarinoController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EcosistemaMarino ecosistemasMarinos, string Longitud, string Latitud)
        {
            try
            {
                //ecosistemasMarinos.EspeciesHabitan = new List<Especie>();
                //ecosistemasMarinos.EspeciesHabitan.Add(new Especie() { Nombre = "Tiburón" });

                string LongitudTipo = "Longitud";
                string LatitudTipo = "Latitud";

                string grados_Latitud = ecosistemasMarinos.GradosMinutosSegundos(Latitud, LatitudTipo);
                string grados_Longitud = ecosistemasMarinos.GradosMinutosSegundos(Longitud, LongitudTipo);

                // ecosistemasMarinos.DetallesGeo = $"Longitud {grados_Longitud}\n Latitud {grados_Latitud}";
                ecosistemasMarinos.coordenadas.Longitud = grados_Longitud;
                ecosistemasMarinos.coordenadas.Latitud = grados_Latitud;
                this.addEcosistemaMarinoUC.AddEcosistemaMarino(ecosistemasMarinos);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Create), new { mensaje = ex.Message });
            }
        }

        // GET: EcosistemaMarinoController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EcosistemaMarinoController1/Edit/5
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

        // GET: EcosistemaMarinoController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EcosistemaMarinoController1/Delete/5
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
