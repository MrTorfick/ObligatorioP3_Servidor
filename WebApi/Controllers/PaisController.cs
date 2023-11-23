using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Pais;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private IAddPaises addPaisesUC;
        private IObtenerPaises obtenerPaisesUC;
        private IObtenerPaisPorISO obtenerPaisPorISOUC;
        private HttpClient cliente = new HttpClient();
        public PaisController(IAddPaises addPaisesUC, IObtenerPaises obtenerPaises, IObtenerPaisPorISO obtenerPaisPorISOUC)
        {
            this.addPaisesUC = addPaisesUC;
            this.obtenerPaisesUC = obtenerPaises;
            this.obtenerPaisPorISOUC = obtenerPaisPorISOUC;
        }

        [HttpGet(Name = "GetPaises")]
         [Authorize]
        public IActionResult Get()
        {
            try
            {
                string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                if (nombreUsuario == "")
                {
                    return Unauthorized();
                }


                //Descomentar para cargar los paises
                //List<PaisDto> paises = ObtenerPaisesRestCountries();
                //Post(paises);
                return Ok(this.obtenerPaisesUC.ObtenerPaises());
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request, " + ex.Message);
            }
        }



        [HttpGet("{PaisISO}")]
        [Authorize]
        public IActionResult GetDetails(string PaisISO)
        {
            try
            {
                string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                if (nombreUsuario == "")
                {
                    return Unauthorized();
                }
                if (PaisISO == null)
                {
                    return BadRequest("El ISO del pais no puede ser nulo");
                }
                return Ok(this.obtenerPaisPorISOUC.IObtenerPaisPorISO(PaisISO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private List<PaisDto> ObtenerPaisesRestCountries()
        {
            try
            {
                string url = "https://restcountries.com/v3.1/all";
                Uri uriPaises = new Uri(url);
                HttpRequestMessage solicitudPaises = new HttpRequestMessage(HttpMethod.Get, uriPaises);
                Task<HttpResponseMessage> respuestaPaises = cliente.SendAsync(solicitudPaises);
                respuestaPaises.Wait();

                if (respuestaPaises.Result.IsSuccessStatusCode)
                {
                    Task<string> responsePaises = respuestaPaises.Result.Content.ReadAsStringAsync();
                    responsePaises.Wait();
                    IEnumerable<PaisDto> paises = JsonConvert.DeserializeObject<IEnumerable<PaisDto>>(responsePaises.Result);
                    return paises.ToList();
                }
                else
                {
                    throw new Exception("Error al obtener los paises de REST Countries " + "Error: " + respuestaPaises.Result.StatusCode);

                }

            }
            catch (Exception)
            {

                throw;
            }



        }

        [HttpPost()]
        private IActionResult Post([FromBody] List<PaisDto> paisDTOs)
        {
            try
            {
                string nombreUsuario = "Carga interna paises";
                paisDTOs = ObtenerPaisesRestCountries();
                List<PaisDto> aux = addPaisesUC.AddPaises(paisDTOs, nombreUsuario);

                return Created("api/Pais", paisDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
