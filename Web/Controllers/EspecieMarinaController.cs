using _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Especie_Marina;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.ValueObjects;
using EcosistemasMarinos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Cryptography;

namespace Web.Controllers
{

    public class EspecieMarinaController : Controller
    {
        #region
        private IWebHostEnvironment _environment;
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
        private IUpdateEspecieMarina updateEspecieMarinaUC;

        public EspecieMarinaController(
            IWebHostEnvironment environment,
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
            IBuscarEspeciesEnPeligroDeExtincion buscarEspeciesEnPeligroDeExtincionUC,
            IUpdateEspecieMarina updateEspecieMarinaUC
            )
        {
            _environment = environment;
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
            this.updateEspecieMarinaUC = updateEspecieMarinaUC;
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
            catch (Exception ex)
            {

                return RedirectToAction(nameof(BuscarEcosistemasMarinosNoPuedenHabitarEspecie), new { mensaje = ex.Message, listaEspecies = obtenerEspeciesMarinasUC.ObtenerEspeciesMarinas() });
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
            catch (Exception ex)
            {

                return RedirectToAction(nameof(BuscarPorNombreCientifico), new { mensaje = ex.Message });
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
                }else if(pesoMinimo==0 && pesoMaximo==0)
                {
                    return RedirectToAction(nameof(BuscarPorRangoDePeso), new { mensaje = "El peso minimo y el peso maximo no pueden ser cero o vacios" });
                }

                IEnumerable<EspecieMarina> especieMarinas = obtenerEspecieMarinaPorRangoPesoUC.GetEspecieMarinasPeso(pesoMinimo, pesoMaximo);
                if (especieMarinas != null && especieMarinas.Count()>0)
                {
                    return View(especieMarinas);
                }
                else
                {
                    return RedirectToAction(nameof(BuscarPorRangoDePeso), new { mensaje = "No se encontro una especie/s que cumplan con el rango de peso ingresado" });
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction(nameof(BuscarPorRangoDePeso), new { mensaje = ex.Message });
            }
        }



        // GET: EspecieMarinaController
        public ActionResult Index()
        {
            ViewBag.Logueado = HttpContext.Session.GetString("LogueadoNombre");
            return View(obtenerEspeciesMarinasUC.ObtenerEspeciesMarinas());
        }



        // GET: EspecieMarinaController/Create
        public ActionResult Create(string mensaje)
        {
            if (HttpContext.Session.GetString("LogueadoNombre") != null)
            {
                ViewBag.Mensaje = mensaje;
                IEnumerable<EcosistemaMarino> ecosistemasMarinos = getEcosistemasMarinosUC.ObtenerEcosistemasMarinos();
                if (ecosistemasMarinos.Count() > 0)
                {
                    ViewBag.EcosistemasMarinos = ecosistemasMarinos;
                }
                else
                {
                    ViewBag.EcosistemasMarinos = null;
                }
                ViewBag.Amenazas = obtenerAmenazasUC.GetAmenazas();
                ViewBag.EstadosConservacion = getEstadosConservacionUC.ObtenerEstadosConservacion();
                return View();

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }

        // POST: EspecieMarinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecieMarina especieMarina, List<IFormFile> imagen, List<int> SelectedOptions, int SelectedOptionEstado, List<int> SelectedOptionsAmenazas)
        {
            try
            {
                if (especieMarina == null || imagen.Count == 0 || SelectedOptions.Count == 0 || SelectedOptionEstado == 0 || SelectedOptionsAmenazas.Count == 0)
                {
                    return RedirectToAction(nameof(Create), new { mensaje = "Debe completar todos los campos" });
                }

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
                addEspecieMarinaUC.AddEspecieMarina(especieMarina, HttpContext.Session.GetString("LogueadoNombre"));
                if (GuardarImagen(imagen, especieMarina))
                {
                    updateEspecieMarinaUC.UpdateEspecieMarina(especieMarina, HttpContext.Session.GetString("LogueadoNombre"));
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Create), new { mensaje = "No se pudo guardar la imagen" });
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Create), new { mensaje = ex.Message });
            }
        }


        private bool GuardarImagen(List<IFormFile> imagen, EspecieMarina em)
        {
            if (imagen == null || em == null) return false;
            // SUBIR LA IMAGEN
            //ruta física de wwwroot
            string rutaFisicaWwwRoot = _environment.WebRootPath;
            int num = 0;
            foreach (var item in imagen)
            {
                string tipoImagen;
                if (item.ContentType.Contains("png"))
                {
                    tipoImagen = ".png";
                }
                else if (item.ContentType.Contains("jpeg"))
                {
                    tipoImagen = ".jpeg";
                }
                else
                {
                    tipoImagen = ".jpg";
                }

                string numString = num.ToString("D3");
                string nombreImagen = item.FileName;
                nombreImagen = em.Id + "_" + numString + tipoImagen;
                num++;
                //ruta donde se guardan las fotos de las personas
                string rutaFisicaFoto = Path.Combine
                (rutaFisicaWwwRoot, "images", "especie", nombreImagen);
                //FileStream permite manejar archivos
                try
                {
                    //el método using libera los recursos del objeto FileStream al finalizar
                    using (FileStream f = new FileStream(rutaFisicaFoto, FileMode.Create))
                    {
                        //Para archivos grandes o varios archivos usar la versión
                        //asincrónica de CopyTo. Sería: await imagen.CopyToAsync (f);
                        item.CopyTo(f);
                    }
                    //GUARDAR EL NOMBRE DE LA IMAGEN SUBIDA EN EL OBJETO
                    Imagen imagenEnviar = new Imagen(nombreImagen);
                    em.Imagen.Add(imagenEnviar);

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;

        }


        public ActionResult AsociarEspecieAEcosistema(string mensaje, int id)
        {
            try
            {
                if (HttpContext.Session.GetString("LogueadoNombre") != null)
                {
                    List<EspecieEcosistemaVM> especieAsociarEcosistemaVMs = new List<EspecieEcosistemaVM>();
                    EspecieMarina especieMarina = obtenerEspecieMarinaPorIdUC.ObtenerEspecieMarinaPorId(id);
                    if (especieMarina != null)
                    {

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
                    else
                    {
                        return RedirectToAction(nameof(AsociarEspecieAEcosistema), new { mensaje = "No se encontro la especie" });
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {

                return RedirectToAction(nameof(AsociarEspecieAEcosistema), new { mensaje = ex.Message });
            }


        }


        [HttpPost]
        public ActionResult AsociarEspecieAEcosistema(int EcosistemaSeleccionado)
        {

            try
            {
                int idEspecie = (int)TempData["idEspecie"];
                EspecieMarina especieMarina = obtenerEspecieMarinaPorIdUC.ObtenerEspecieMarinaPorId(idEspecie);

                IEnumerable<EspecieMarina> especieMarinas = buscarEspeciesQueHabitanUnEcosistemaUC.BuscarEspeciesQueHabitanUnEcosistema(EcosistemaSeleccionado);

                foreach (var item in especieMarinas)
                {
                    if (item.Id == idEspecie)
                    {
                        return RedirectToAction(nameof(AsociarEspecieAEcosistema), new { mensaje = "La especie ya se encuentra asociada al ecosistema" });
                    }
                }

                EcosistemaMarino ecosistemaMarino = obtenerEcosistemaMarinoPorIdUC.ObtenerEcosistemaMarinoPorId(EcosistemaSeleccionado);

                foreach (var item in ecosistemaMarino.Amenazas)
                {
                    foreach (var item1 in especieMarina.Amenazas)
                    {
                        if (item.AmenazaId == item1.AmenazaId)
                        {
                            return RedirectToAction(nameof(AsociarEspecieAEcosistema), new { mensaje = "La especie no puede habitar el ecosistema porque tiene amenazas en comun" });
                        }
                    }
                }
                if (ecosistemaMarino.EstadoConservacion.Rangos.Minimo < especieMarina.EstadoConservacion.Rangos.Minimo)
                {
                    return RedirectToAction(nameof(AsociarEspecieAEcosistema), new { mensaje = "La especie no puede habitar el ecosistema porque el estado de conservacion del ecosistema es menor al de la especie" });
                }


                asociarEspecieEcosistemaUC.AsociarEspecieAEcosistema(idEspecie, EcosistemaSeleccionado, HttpContext.Session.GetString("LogueadoNombre"));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return RedirectToAction(nameof(AsociarEspecieAEcosistema), new { mensaje = ex.Message });
            }
        }
    }
}
