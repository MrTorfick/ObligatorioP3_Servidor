using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenazaController : ControllerBase
    {
        private IObtenerAmenazas _obtenerAmenazasUC;

        public AmenazaController(
                       IObtenerAmenazas obtenerAmenazasUC
                       )
        {
            this._obtenerAmenazasUC = obtenerAmenazasUC;
        }

        [HttpGet(Name = "GetAmenazas")]
        public IActionResult Get()
        {
            try
            {
                return Ok(this._obtenerAmenazasUC.GetAmenazas());
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }

    }
}
