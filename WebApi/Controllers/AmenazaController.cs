using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenazaController : ControllerBase
    {
        private IObtenerAmenazas _obtenerAmenazasUC;
        private IObtenerAmenazaPorId _obtenerAmenazaPorIdUC;

        public AmenazaController(
                       IObtenerAmenazas obtenerAmenazasUC,
                       IObtenerAmenazaPorId obtenerAmenazaPorIdUC
                       )
        {
            this._obtenerAmenazasUC = obtenerAmenazasUC;
            this._obtenerAmenazaPorIdUC = obtenerAmenazaPorIdUC;

        }
        /// <summary>
        /// Obtiene todas las amenazas
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAmenazas")]
        [ProducesResponseType(typeof(IEnumerable<AmenazaDto>), 200)]
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


                return Ok(this._obtenerAmenazasUC.GetAmenazas());
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene una amenaza por id
        /// </summary>
        /// <param name="AmenazaId">Id de la amenaza a buscar</param>
        /// <returns></returns>
        [HttpGet("{AmenazaId}")]
        [ProducesResponseType(typeof(AmenazaDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        [Authorize]
        public IActionResult GetDetails(int AmenazaId)
        {
            try
            {

                string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                if (nombreUsuario == "")
                {
                    return Unauthorized();
                }


                return Ok(this._obtenerAmenazaPorIdUC.ObtenerAmenazaPorId(AmenazaId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
