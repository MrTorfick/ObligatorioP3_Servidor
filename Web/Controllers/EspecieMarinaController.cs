using _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Especie_Marina;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Web.Controllers
{

    public class EspecieMarinaController : Controller
    {
        #region
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
        private IObtenerEspecieMarinaPorRangoPeso obtenerEspecieMarinaPorRangoPesoUC;
        private IObtenerEcosistemasMarinosNoPuedenHabitarEspecies obtenerEcosistemasMarinosNoPuedenHabitarEspeciesUC;
        private IBuscarEspeciesQueHabitanUnEcosistema buscarEspeciesQueHabitanUnEcosistemaUC;
        private IBuscarEspeciesEnPeligroDeExtincion buscarEspeciesEnPeligroDeExtincionUC;

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
            IObtenerEspecieMarinaPorNombreCientifico obtenerEspecieMarinaPorNombreCientificoUC,
            IObtenerEspecieMarinaPorRangoPeso obtenerEspecieMarinaPorRangoPesoUC,
            IObtenerEcosistemasMarinosNoPuedenHabitarEspecies obtenerEcosistemasMarinosNoPuedenHabitarEspeciesUC,
            IBuscarEspeciesQueHabitanUnEcosistema buscarEspeciesQueHabitanUnEcosistemaUC,
            IBuscarEspeciesEnPeligroDeExtincion buscarEspeciesEnPeligroDeExtincionUC
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
            this.obtenerEspecieMarinaPorRangoPesoUC = obtenerEspecieMarinaPorRangoPesoUC;
            this.obtenerEcosistemasMarinosNoPuedenHabitarEspeciesUC = obtenerEcosistemasMarinosNoPuedenHabitarEspeciesUC;
            this.buscarEspeciesQueHabitanUnEcosistemaUC = buscarEspeciesQueHabitanUnEcosistemaUC;
            this.buscarEspeciesEnPeligroDeExtincionUC = buscarEspeciesEnPeligroDeExtincionUC;
        }
        #endregion


        public ActionResult BuscarEspeciesEnPeligroDeExtincion()
        {
            try
            {
                IEnumerable<EspecieMarina> especieMarinas = buscarEspeciesEnPeligroDeExtincionUC.GetEspecieMarinaEnPeligroDeExtincion();
                if (especieMarinas.Count() > 0)
                {
                    return View(especieMarinas);
                }
                else
                {
                    ViewBag.Mensaje = "No se encontraron especies en peligro de extincion";
                    return View();
                }
            }
            catch (Exception ex)
            {

                ViewBag.Mensaje = ex.Message;
                return View();
            }

        }



        public ActionResult BuscarEspeciesQueHabitanEcosistema(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            ViewBag.listaEcosistemas = getEcosistemasMarinosUC.ObtenerEcosistemasMarinos();

            return View();

        }

        [HttpPost]
        public ActionResult BuscarEspeciesQueHabitanEcosistema(int EcosistemaSeleccionado)
        {
            try
            {
                IEnumerable<EspecieMarina> especiesMarinas = buscarEspeciesQueHabitanUnEcosistemaUC.BuscarEspeciesQueHabitanUnEcosistema(EcosistemaSeleccionado);
                if (especiesMarinas.Count() > 0)
                {
                    return View(especiesMarinas);
                }
                else
                {
                    return RedirectToAction(nameof(BuscarEspeciesQueHabitanEcosistema), new { mensaje = "No se encontro una especie que habite el ecosistema" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(BuscarEspeciesQueHabitanEcosistema), new { mensaje = ex.Message });
            }

        }



        public ActionResult BuscarEcosistemasMarinosNoPuedenHabitarEspecie(string mensaje, IEnumerable<EspecieMarina> listaEspecies)
        {
            listaEspecies = obtenerEspeciesMarinasUC.ObtenerEspeciesMarinas();
            ViewBag.listaEspecies = listaEspecies;
            ViewBag.Mensaje = mensaje;
            return View();
        }


        [HttpPost]
        public ActionResult BuscarEcosistemasMarinosNoPuedenHabitarEspecie(int EspecieSeleccionada)
        {
            try
            {
                IEnumerable<EcosistemaMarino> ecosistemaMarinos = obtenerEcosistemasMarinosNoPuedenHabitarEspeciesUC.ObtenerEcosistemasMarinosNoPuedenHabitarEspecies(EspecieSeleccionada);

                if (ecosistemaMarinos.Count() > 0)
                {
                    ViewBag.listaEspecies = obtenerEspeciesMarinasUC.ObtenerEspeciesMarinas();
                    return View(ecosistemaMarinos);
                    //return View(nameof(BuscarEcosistemasMarinosNoPuedenHabitarEspecie), ecosistemaMarinos);
                }
                else
                {
                    return RedirectToAction(nameof(BuscarEcosistemasMarinosNoPuedenHabitarEspecie), new { mensaje = "No se encontro un ecosistema que no pueda habitar la especie", listaEspecies = obtenerEspeciesMarinasUC.ObtenerEspeciesMarinas() });
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult BuscarPorNombreCientifico(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public ActionResult BuscarPorNombreCientifico(string nombreCientifico, IFormCollection collection)
        {
            try
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
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult BuscarPorRangoDePeso(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public ActionResult BuscarPorRangoDePeso(double pesoMinimo, double pesoMaximo)
        {
            try
            {
                if (pesoMinimo > pesoMaximo)
                {
                    return RedirectToAction(nameof(BuscarPorRangoDePeso), new { mensaje = "El peso minimo no puede ser mayor al peso maximo" });
                }
                else if (pesoMinimo < 0 || pesoMaximo < 0)
                {
                    return RedirectToAction(nameof(BuscarPorRangoDePeso), new { mensaje = "El peso minimo y el peso maximo no pueden ser negativos" });
                }

                IEnumerable<EspecieMarina> especieMarinas = obtenerEspecieMarinaPorRangoPesoUC.GetEspecieMarinasPeso(pesoMinimo, pesoMaximo);
                if (especieMarinas != null)
                {
                    return View(especieMarinas);
                }
                else
                {
                    return RedirectToAction(nameof(BuscarPorRangoDePeso), new { mensaje = "No se encontro una especie" });
                }
            }
            catch (Exception)
            {

                throw;
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
            List<EspecieEcosistemaVM> especieAsociarEcosistemaVMs = new List<EspecieEcosistemaVM>();
            EspecieMarina especieMarina = obtenerEspecieMarinaPorIdUC.ObtenerEspecieMarinaPorId(id);
            TempData["idEspecie"] = especieMarina.Id;

            //ViewBag.NombreEspecie = especieAsociarEcosistemaVM.especieMarina.NombreVulgar;;
            foreach (EcosistemaMarino item in especieMarina.EcosistemaMarinos)
            {
                if (item != null)
                {
                    EspecieEcosistemaVM especieAsociarEcosistemaVM = new EspecieEcosistemaVM();
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
