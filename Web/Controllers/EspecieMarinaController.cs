using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Web.Controllers
{
    public class EspecieMarinaController : Controller
    {

        private IObtenerEcosistemasMarinos getEcosistemasMarinosUC;
        private IObtenerEcosistemaMarinoPorId obtenerEcosistemaMarinoPorIdUC;
        private IAddEspecieMarina addEspecieMarinaUC;
        private IObtenerAmenazas obtenerAmenazasUC;
        private IObtenerEspeciesMarinas obtenerEspeciesMarinasUC;
        private IObtenerEspecieMarinaPorId obtenerEspecieMarinaPorIdUC;
        private IAsociarEspecieEcosistema asociarEspecieEcosistemaUC;
        private IObtenerEstadosConservacion getEstadosConservacionUC;
        private IObtenerAmenazaPorId obtenerAmenazasPorIdUC;
        private IObtenerEspecieMarinaPorNombreCientifico obtenerEspecieMarinaPorNombreCientificoUC;

        public EspecieMarinaController(
            IObtenerEcosistemasMarinos getEcosistemasMarinosUC,
            IObtenerEcosistemaMarinoPorId obtenerEcosistemaMarinoPorIdUC,
            IAddEspecieMarina addEspecieMarinaUC,
            IObtenerAmenazas obtenerAmenazasUC,
            IObtenerEspeciesMarinas obtenerEspeciesMarinasUC,
            IObtenerEspecieMarinaPorId obtenerEspecieMarinaPorIdUC,
            IAsociarEspecieEcosistema asociarEspecieEcosistemaUC,
            IObtenerEstadosConservacion getEstadosConservacionUC,
            IObtenerAmenazaPorId obtenerAmenazasPorIdUC,
            IObtenerEspecieMarinaPorNombreCientifico obtenerEspecieMarinaPorNombreCientificoUC
            )
        {
            this.getEcosistemasMarinosUC = getEcosistemasMarinosUC;
            this.obtenerEcosistemaMarinoPorIdUC = obtenerEcosistemaMarinoPorIdUC;
            this.addEspecieMarinaUC = addEspecieMarinaUC;
            this.obtenerAmenazasUC = obtenerAmenazasUC;
            this.obtenerEspeciesMarinasUC = obtenerEspeciesMarinasUC;
            this.obtenerEspecieMarinaPorIdUC = obtenerEspecieMarinaPorIdUC;
            this.asociarEspecieEcosistemaUC = asociarEspecieEcosistemaUC;
            this.getEstadosConservacionUC = getEstadosConservacionUC;
            this.obtenerAmenazasPorIdUC = obtenerAmenazasPorIdUC;
            this.obtenerEspecieMarinaPorNombreCientificoUC = obtenerEspecieMarinaPorNombreCientificoUC;
        }

        public ActionResult BuscarPorNombreCientifico(string mensaje)
        {

            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public ActionResult BuscarPorNombreCientifico(string nombreCientifico, IFormCollection collection)
        {
            EspecieMarina especieMarina = obtenerEspecieMarinaPorNombreCientificoUC.GetEspecieMarinaPorNombreCientifico(nombreCientifico);
            if (especieMarina != null)
            {
                return View(especieMarina);
            }
            else
            {
                return RedirectToAction(nameof(BuscarPorNombreCientifico), new { mensaje = "No se encontro la especie" });
            }
        }




        // GET: EspecieMarinaController
        public ActionResult Index()
        {
            return View(obtenerEspeciesMarinasUC.ObtenerEspeciesMarinas());
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
            ViewBag.EstadosConservacion = getEstadosConservacionUC.ObtenerEstadosConservacion();
            return View();
        }

        // POST: EspecieMarinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecieMarina especieMarina, IFormFile imagen, List<int> SelectedOptions, int SelectedOptionEstado, List<int> SelectedOptionsAmenazas)
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
                especieMarina.Amenazas = new List<AmenazasAsociadas>();
                foreach (var item in SelectedOptionsAmenazas)
                {
                    Amenaza amenaza = this.obtenerAmenazasPorIdUC.ObtenerAmenazaPorId(item);

                    if (amenaza != null)
                    {
                        AmenazasAsociadas amenazasAsociadas = new AmenazasAsociadas();
                        amenazasAsociadas.AmenazaId = amenaza.Id;
                        especieMarina.Amenazas.Add(amenazasAsociadas);
                    }
                }

                especieMarina.EstadoConservacionId = SelectedOptionEstado;
                addEspecieMarinaUC.AddEspecieMarina(especieMarina);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Create), new { mensaje = ex.Message });
            }
            {

            }
        }

        public ActionResult AsociarEspecieAEcosistema(string mensaje, int id)
        {
            List<EspecieAsociarEcosistemaVM> especieAsociarEcosistemaVMs = new List<EspecieAsociarEcosistemaVM>();
            EspecieMarina especieMarina = obtenerEspecieMarinaPorIdUC.ObtenerEspecieMarinaPorId(id);
            TempData["idEspecie"] = especieMarina.Id;

            //ViewBag.NombreEspecie = especieAsociarEcosistemaVM.especieMarina.NombreVulgar;;
            foreach (EcosistemaMarino item in especieMarina.EcosistemaMarinos)
            {
                if (item != null)
                {
                    EspecieAsociarEcosistemaVM especieAsociarEcosistemaVM = new EspecieAsociarEcosistemaVM();
                    especieAsociarEcosistemaVM.ecosistemasMarinos = item;
                    especieAsociarEcosistemaVMs.Add(especieAsociarEcosistemaVM);
                    //EcosistemaMarino ecosistemaMarino = obtenerEcosistemaMarinoPorIdUC.ObtenerEcosistemaMarinoPorId(item.Id);
                    //especieAsociarEcosistemaVM.ecosistemasMarinos.Add(ecosistemaMarino);
                }

            }
            ViewBag.Mensaje = mensaje;
            return View(especieAsociarEcosistemaVMs);

        }


        [HttpPost]
        public ActionResult AsociarEspecieAEcosistema(int EcosistemaSeleccionado)
        {

            try
            {
                int idEspecie = (int)TempData["idEspecie"];
                asociarEspecieEcosistemaUC.AsociarEspecieAEcosistema(idEspecie, EcosistemaSeleccionado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return RedirectToAction(nameof(AsociarEspecieAEcosistema), new { mensaje = ex.Message });
            }
        }

        /*
        try
            {
                EspecieMarina especieMarina = obtenerEspecieMarinaPorNombreCientificoUC.GetEspecieMarinaPorNombreCientifico(nombreCientifico);

                if (especieMarina != null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction(nameof(BuscarPorNombreCientifico), new { mensaje = "No se encontro la especie" });
                }
            }
            catch (Exception ex)
            {
                RedirectToAction(nameof(BuscarPorNombreCientifico), new { mensaje = ex.Message });
            }
         

         */
    }
}
