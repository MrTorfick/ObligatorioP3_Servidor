using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using EcosistemasMarinos.ValueObjects;

namespace Web.Controllers
{
    public class EcosistemaMarinoController : Controller
    {

        private IAddEcosistemaMarino addEcosistemaMarinoUC;
        private IObtenerEcosistemasMarinos getEcosistemasMarinosUC;
        // private IObtenerEspeciesMarinas getEspeciesMarinasUC;
        private IObtenerEstadosConservacion getEstadosConservacionUC;
        private IWebHostEnvironment _environment;
        private IObtenerEstadoConservacionPorId obtenerEstadoConservacionPorIdUC;
        private IObtenerAmenazas getAmenazasUC;
        private IObtenerAmenazaPorId obtenerAmenazasPorIdUC;
        //private IUpdateAmenaza updateAmenazaUC;

        public EcosistemaMarinoController(
            IAddEcosistemaMarino addEcosistemaMarinoUC,
            IWebHostEnvironment environment,
            IObtenerEcosistemasMarinos getEcosistemasMarinosUC,
            //IObtenerEspeciesMarinas getEspeciesMarinasUC,
            IObtenerEstadosConservacion getEstadosConservacionUC,
            IObtenerEstadoConservacionPorId obtenerEstadoConservacionPorIdUC,
            IObtenerAmenazas getAmenazasUC,
            IObtenerAmenazaPorId obtenerAmenazasPorIdUC
            //IUpdateAmenaza updateAmenazaUC

            )
        {
            this.addEcosistemaMarinoUC = addEcosistemaMarinoUC;
            _environment = environment;
            this.getEcosistemasMarinosUC = getEcosistemasMarinosUC;
            //this.getEspeciesMarinasUC = getEspeciesMarinasUC;
            this.getEstadosConservacionUC = getEstadosConservacionUC;
            this.obtenerEstadoConservacionPorIdUC = obtenerEstadoConservacionPorIdUC;
            this.getAmenazasUC = getAmenazasUC;
            this.obtenerAmenazasPorIdUC = obtenerAmenazasPorIdUC;
            //this.updateAmenazaUC = updateAmenazaUC;

        }

        // GET: EcosistemaMarinoController1
        public ActionResult Index()
        {
            return View(this.getEcosistemasMarinosUC.ObtenerEcosistemasMarinos());
        }

        // GET: EcosistemaMarinoController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EcosistemaMarinoController1/Create
        public ActionResult Create(string mensaje)
        {
            ViewBag.EstadosConservacion = this.getEstadosConservacionUC.ObtenerEstadosConservacion();
            ViewBag.Amenazas = this.getAmenazasUC.GetAmenazas();
            ViewBag.Mensaje = mensaje;
            return View();
        }



        public ActionResult Create(EcosistemaMarino ecosistemasMarinos, string Longitud, string Latitud, IFormFile imagen, int SelectedOptionEstado, List<int> SelectedOptionsAmenazas)
        {
            try
            {

                if (ecosistemasMarinos == null || imagen == null || SelectedOptionEstado == 0)

                    return RedirectToAction(nameof(Create), new { mensaje = "Debe ingresar todos los datos" });


                //ecosistemasMarinos.EspeciesHabitan = new List<Especie>();
                //ecosistemasMarinos.EspeciesHabitan.Add(new Especie() { Nombre = "Tiburón" });

                string LongitudTipo = "Longitud";
                string LatitudTipo = "Latitud";

                string grados_Latitud = ecosistemasMarinos.GradosMinutosSegundos(Latitud, LatitudTipo);
                string grados_Longitud = ecosistemasMarinos.GradosMinutosSegundos(Longitud, LongitudTipo);

                // ecosistemasMarinos.DetallesGeo = $"Longitud {grados_Longitud}\n Latitud {grados_Latitud}";
                ecosistemasMarinos.Coordenadas = new Coordenadas(grados_Longitud, grados_Latitud);
                if (GuardarImagen(imagen, ecosistemasMarinos))
                {
                    ecosistemasMarinos.EstadoConservacionId = this.obtenerEstadoConservacionPorIdUC.ObtenerEstadoConservacionPorId(SelectedOptionEstado).Id;
                    //addEcosistemaMarinoUC.AddEcosistemaMarino(ecosistemasMarinos);
                    ecosistemasMarinos.Amenazas = new List<Amenaza>();
                    foreach (var item in SelectedOptionsAmenazas)
                    {
                        Amenaza amenaza = this.obtenerAmenazasPorIdUC.ObtenerAmenazaPorId(item);
                        amenaza.Id = 0;//De esta forma, sql no lanza una excepcion por intentar insertar una amenaza que ya contiene un id.
                                       //Cuando lo inicializo en 0, EF lo toma como que es una nueva amenaza y le asigna un id nuevo.

                        ecosistemasMarinos.Amenazas.Add(amenaza);
                        //amenaza.EcosistemaMarinoId= ecosistemasMarinos.Id;
                        //updateAmenazaUC.UpdateAmenaza(amenaza);
                        //ecosistemasMarinos.Amenazas.Add(amenaza);

                    }
                    addEcosistemaMarinoUC.AddEcosistemaMarino(ecosistemasMarinos);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Create), new { mensaje = ex.Message });
            }
        }









        //Futura version
        /*

        [HttpPost]
        public ActionResult Create(EcosistemaMarino ecosistemasMarinos, string Longitud, string Latitud, IFormFile imagen, int SelectedOptionEstado, List<int> SelectedOptionsAmenazas)
        {
            try
            {

                if (ecosistemasMarinos == null || imagen == null || SelectedOptionEstado == 0)

                    return RedirectToAction(nameof(Create), new { mensaje = "Debe ingresar todos los datos" });

                string LongitudTipo = "Longitud";
                string LatitudTipo = "Latitud";

                string grados_Latitud = ecosistemasMarinos.GradosMinutosSegundos(Latitud, LatitudTipo);
                string grados_Longitud = ecosistemasMarinos.GradosMinutosSegundos(Longitud, LongitudTipo);

                ecosistemasMarinos.Coordenadas = new Coordenadas(grados_Longitud, grados_Latitud);
                if (GuardarImagen(imagen, ecosistemasMarinos))
                {
                    ecosistemasMarinos.EstadoConservacionId = this.obtenerEstadoConservacionPorIdUC.ObtenerEstadoConservacionPorId(SelectedOptionEstado).Id;
                    ecosistemasMarinos.Amenazas = new List<Amenaza>();
                    foreach (var item in SelectedOptionsAmenazas)
                    {
                        Amenaza amenaza = this.obtenerAmenazasPorIdUC.ObtenerAmenazaPorId(item);
                        if (amenaza != null)
                        {
                            ecosistemasMarinos.Amenazas.Add(amenaza);
                        }
                    }
                    addEcosistemaMarinoUC.AddEcosistemaMarino(ecosistemasMarinos);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Create), new { mensaje = ex.Message });
            }
        }

        */






        private bool GuardarImagen(IFormFile imagen, EcosistemaMarino em)
        {
            if (imagen == null || em == null) return false;
            // SUBIR LA IMAGEN
            //ruta física de wwwroot
            string rutaFisicaWwwRoot = _environment.WebRootPath;

            string nombreImagen = imagen.FileName;
            //ruta donde se guardan las fotos de las personas
            string rutaFisicaFoto = Path.Combine
            (rutaFisicaWwwRoot, "images", "ecosistema_marino", nombreImagen);
            //FileStream permite manejar archivos
            try
            {
                //el método using libera los recursos del objeto FileStream al finalizar
                using (FileStream f = new FileStream(rutaFisicaFoto, FileMode.Create))
                {
                    //Para archivos grandes o varios archivos usar la versión
                    //asincrónica de CopyTo. Sería: await imagen.CopyToAsync (f);
                    imagen.CopyTo(f);
                }
                //GUARDAR EL NOMBRE DE LA IMAGEN SUBIDA EN EL OBJETO
                em.Imagen = nombreImagen;
                return true;
            }
            catch (Exception ex)
            {
                return false;
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
