using _EcosistemasMarinos.LogicaAplicacion.DTOs;
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

        /// <summary>
        /// Obtiene todos los estados de conservacion
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetEstadosConservacion")]
        [ProducesResponseType(typeof(IEnumerable<EstadoConservacionDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
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

                return Ok(this._obtenerEstadosConservacionUC.ObtenerEstadosConservacion());
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }


        /// <summary>
        /// Obtiene los estados de conservacion por su id
        /// </summary>
        /// <param name="EstadoConservacionId">Id del EstadoConservacion</param>
        /// <returns></returns>
        [HttpGet("{EstadoConservacionId}")]
        [ProducesResponseType(typeof(EstadoConservacionDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        [Authorize]
        public IActionResult GetDetails(int EstadoConservacionId)
        {
            try
            {

                string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                if (nombreUsuario == "")
                {
                    return Unauthorized();
                }
                return Ok(this._obtenerEstadoConservacionPorIdUC.ObtenerEstadoConservacionPorId(EstadoConservacionId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
