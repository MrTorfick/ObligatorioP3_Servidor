using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoConservacionController : ControllerBase
    {

        private IObtenerEstadosConservacion _obtenerEstadosConservacionUC;
        private IObtenerEstadoConservacionPorId _obtenerEstadoConservacionPorIdUC;

        public EstadoConservacionController(IObtenerEstadosConservacion obtenerEstadosConservacionUC,
                                            IObtenerEstadoConservacionPorId obtenerEstadoConservacionPorIdUC)
        {
            _obtenerEstadosConservacionUC = obtenerEstadosConservacionUC;
            this._obtenerEstadoConservacionPorIdUC = obtenerEstadoConservacionPorIdUC;
        }


        [HttpGet(Name = "GetEstadosConservacion")]
       // [Authorize]
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



        [HttpGet("{EstadoConservacionId}")]
        //[Authorize]
        public IActionResult GetDetails(int EstadoConservacionId)
        {
            try
            {
                return Ok(this._obtenerEstadoConservacionPorIdUC.ObtenerEstadoConservacionPorId(EstadoConservacionId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
