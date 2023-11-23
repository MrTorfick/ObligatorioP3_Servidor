using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {

        private IObtenerConfiguraciones _obtenerConfiguracionesUC;
        private IUpdateConfiguracion _updateConfiguracionUC;
        private IObtenerConfiguracionPorNombre _obtenerConfiguracionPorNombreUC;


        public ConfiguracionController(
            IObtenerConfiguraciones obtenerConfiguracionesUC,
            IUpdateConfiguracion updateConfiguracionUC,
            IObtenerConfiguracionPorNombre obtenerConfiguracionPorNombreUC

            )
        {
            this._obtenerConfiguracionesUC = obtenerConfiguracionesUC;
            this._updateConfiguracionUC = updateConfiguracionUC;
            this._obtenerConfiguracionPorNombreUC = obtenerConfiguracionPorNombreUC;
        }

        /// <summary>
        /// Obtiene todas las configuraciones
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetConfiguraciones")]
        [ProducesResponseType(typeof(IEnumerable<ConfiguracionDto>), 200)]
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

                return Ok(this._obtenerConfiguracionesUC.ObtenerConfiguraciones());
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }
        /// <summary>
        /// Obtiene una configuracion por su nombre
        /// </summary>
        /// <param name="NombreAtributo">Nombre del atributo de la configuracion</param>
        /// <returns></returns>

        [HttpGet("{NombreAtributo}")]
        [ProducesResponseType(typeof(ConfiguracionDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        [Authorize]
        public IActionResult GetDetails(string NombreAtributo)
        {
            try
            {
                string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                if (nombreUsuario == "")
                {
                    return Unauthorized();
                }

                return Ok(this._obtenerConfiguracionPorNombreUC.ObtenerConfiguracionPorNombre(NombreAtributo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Modifica los datos de una configuracion existente
        /// </summary>
        /// <param name="config">Objeto de tipo ConfiguracionDto</param>
        /// <returns></returns>


        [HttpPut()]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        [Authorize]
        public IActionResult Put([FromBody] ConfiguracionDto config)
        {
            try
            {
                string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                if (nombreUsuario == "")
                {
                    return Unauthorized();
                }
                if (nombreUsuario == null)
                {
                    nombreUsuario = "Prueba Api";
                }

                this._updateConfiguracionUC.UpdateConfiguracion(config, nombreUsuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
