using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using EcosistemasMarinos.ValueObjects;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Ecosistema_Marino;

namespace Web.Controllers
{
    public class EcosistemaMarinoController : Controller
    {

        private IAddEcosistemaMarino addEcosistemaMarinoUC;
        private IObtenerEcosistemasMarinos getEcosistemasMarinosUC;
        //private IObtenerEspeciesMarinas getEspeciesMarinasUC;
        private IObtenerEstadosConservacion getEstadosConservacionUC;
        private IWebHostEnvironment _environment;
        private IObtenerEstadoConservacionPorId obtenerEstadoConservacionPorIdUC;
        private IObtenerAmenazas getAmenazasUC;
        private IObtenerAmenazaPorId obtenerAmenazasPorIdUC;
        private IObtenerEcosistemaMarinoPorId obtenerEcosistemaMarinoPorIdUC;
        private IBorrarEcosistemaMarino borrarEcosistemaMarinoUC;
        private IUpdateEcosistemaMarino updateEcosistemaMarinoUC;
        private IObtenerPaises obtenerPaisesUC;
        private IObtenerPaisPorId obtenerPaisPorIdUC;
        //private IUpdateAmenaza updateAmenazaUC;

        public EcosistemaMarinoController(
            IAddEcosistemaMarino addEcosistemaMarinoUC,
            IWebHostEnvironment environment,
            IObtenerEcosistemasMarinos getEcosistemasMarinosUC,
            //IObtenerEspeciesMarinas getEspeciesMarinasUC,
            IObtenerEstadosConservacion getEstadosConservacionUC,
            IObtenerEstadoConservacionPorId obtenerEstadoConservacionPorIdUC,
            IObtenerAmenazas getAmenazasUC,
            IObtenerAmenazaPorId obtenerAmenazasPorIdUC,
            IObtenerEcosistemaMarinoPorId obtenerEcosistemaMarinoPorIdUC,
            IBorrarEcosistemaMarino borrarEcosistemaMarinoUC,
            IUpdateEcosistemaMarino updateEcosistemaMarinoUC,
            IObtenerPaises obtenerPaisesUC,
            IObtenerPaisPorId obtenerPaisPorIdUC
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
            this.obtenerEcosistemaMarinoPorIdUC = obtenerEcosistemaMarinoPorIdUC;
            this.borrarEcosistemaMarinoUC = borrarEcosistemaMarinoUC;
            this.updateEcosistemaMarinoUC = updateEcosistemaMarinoUC;
            this.obtenerPaisesUC = obtenerPaisesUC;
            this.obtenerPaisPorIdUC = obtenerPaisPorIdUC;
            //this.updateAmenazaUC = updateAmenazaUC;

        }

        // GET: EcosistemaMarinoController1
        public ActionResult Index(string mensaje)
        {
            ViewBag.mensaje = mensaje;
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
            if (HttpContext.Session.GetString("LogueadoNombre") != null)
            {
                ViewBag.EstadosConservacion = this.getEstadosConservacionUC.ObtenerEstadosConservacion();
                ViewBag.Amenazas = this.getAmenazasUC.GetAmenazas();
                ViewBag.Paises = this.obtenerPaisesUC.ObtenerPaises();
                ViewBag.Mensaje = mensaje;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }



        }


        [HttpPost]
        public ActionResult Create(EcosistemaMarino ecosistemasMarinos, string Longitud, string Latitud, List<IFormFile> imagen, int SelectedOptionEstado, List<int> SelectedOptionsAmenazas, int PaisSeleccionado)
        {
            try
            {

                if (ecosistemasMarinos == null || imagen.Count == 0 || SelectedOptionEstado == 0 || PaisSeleccionado == 0)

                    return RedirectToAction(nameof(Create), new { mensaje = "Debe ingresar todos los datos" });

                string LongitudTipo = "Longitud";
                string LatitudTipo = "Latitud";

                string grados_Latitud = ecosistemasMarinos.GradosMinutosSegundos(Latitud, LatitudTipo);
                string grados_Longitud = ecosistemasMarinos.GradosMinutosSegundos(Longitud, LongitudTipo);

                ecosistemasMarinos.Coordenadas = new Coordenadas(grados_Longitud, grados_Latitud);

                ecosistemasMarinos.EstadoConservacionId = this.obtenerEstadoConservacionPorIdUC.ObtenerEstadoConservacionPorId(SelectedOptionEstado).Id;
                ecosistemasMarinos.Amenazas = new List<AmenazasAsociadas>();
                foreach (var item in SelectedOptionsAmenazas)
                {
                    Amenaza amenaza = this.obtenerAmenazasPorIdUC.ObtenerAmenazaPorId(item);

                    if (amenaza != null)
                    {
                        AmenazasAsociadas amenazasAsociadas = new AmenazasAsociadas();
                        amenazasAsociadas.AmenazaId = amenaza.Id;
                        ecosistemasMarinos.Amenazas.Add(amenazasAsociadas);
                    }
                }
                ecosistemasMarinos.pais = obtenerPaisPorIdUC.ObtenerPaisPorId(PaisSeleccionado);
                addEcosistemaMarinoUC.AddEcosistemaMarino(ecosistemasMarinos, HttpContext.Session.GetString("LogueadoNombre"));
                if (GuardarImagen(imagen, ecosistemasMarinos))
                {
                    updateEcosistemaMarinoUC.UpdateEcosistemaMarino(ecosistemasMarinos, HttpContext.Session.GetString("LogueadoNombre"));
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



        private bool GuardarImagen(List<IFormFile> imagen, EcosistemaMarino em)
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
                (rutaFisicaWwwRoot, "images", "ecosistema", nombreImagen);
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

            if (HttpContext.Session.GetString("LogueadoNombre") != null)
            {

                EcosistemaMarino ecosistemaMarino = obtenerEcosistemaMarinoPorIdUC.ObtenerEcosistemaMarinoPorId(id);
                //Hay que validar que ecosistemaMarino no sea null. 
                //TODO
                if (ecosistemaMarino != null && ecosistemaMarino.EspeciesHabitan != null)
                {
                    if (ecosistemaMarino.EspeciesHabitan.Count > 0)
                    {
                        return RedirectToAction(nameof(Index), new { mensaje = "No se puede eliminar el ecosistema marino porque tiene especies que lo habitan" });
                    }
                }
                return View(ecosistemaMarino);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }



        }

        // POST: EcosistemaMarinoController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                this.borrarEcosistemaMarinoUC.BorrarEcosistemaMarino(id, HttpContext.Session.GetString("LogueadoNombre"));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index), new { mensaje = ex.Message });
            }
        }
    }
}
