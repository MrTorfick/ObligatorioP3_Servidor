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
        private IObtenerEcosistemasMarinos GetEcosistemasMarinosUC;
        private IWebHostEnvironment _environment;

        public EcosistemaMarinoController(IAddEcosistemaMarino addEcosistemaMarinoUC, IWebHostEnvironment environment, IObtenerEcosistemasMarinos getEcosistemasMarinosUC)
        {
            this.addEcosistemaMarinoUC = addEcosistemaMarinoUC;
            _environment = environment;
            this.GetEcosistemasMarinosUC = getEcosistemasMarinosUC;
        }

        // GET: EcosistemaMarinoController1
        public ActionResult Index()
        {
            return View(this.GetEcosistemasMarinosUC.ObtenerEcosistemasMarinos());
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

        [HttpPost]
        public ActionResult Create(EcosistemaMarino ecosistemasMarinos, string Longitud, string Latitud, IFormFile imagen)
        {
            try
            {
                if (ecosistemasMarinos == null || imagen == null)
                    return View();
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
