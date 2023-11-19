using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoConservacionController : ControllerBase
    {

        private IObtenerEstadosConservacion _obtenerEstadosConservacionUC;

        public EstadoConservacionController(IObtenerEstadosConservacion obtenerEstadosConservacionUC)
        {
            _obtenerEstadosConservacionUC = obtenerEstadosConservacionUC;
        }


        [HttpGet(Name = "GetEstadosConservacion")]
        public IActionResult Get()
        {
            try
            {
                return Ok(this._obtenerEstadosConservacionUC.ObtenerEstadosConservacion());
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }
    }
}
