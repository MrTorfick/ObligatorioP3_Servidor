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
        /// <returns>
        /// Retorna una lista de configuraciones
        /// </returns>
        [HttpGet(Name = "GetConfiguraciones")]
        [ProducesResponseType(typeof(IEnumerable<ConfiguracionDto>), 200)] // 200 OK
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        //[Authorize]
        public IActionResult Get()
        {
            try
            {
                return Ok(this._obtenerConfiguracionesUC.ObtenerConfiguraciones());
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NombreAtributo"></param>
        /// <returns></returns>

        [HttpGet("{NombreAtributo}")]
        //[Authorize]
        public IActionResult GetDetails(string NombreAtributo)
        {
            try
            {
                return Ok(this._obtenerConfiguracionPorNombreUC.ObtenerConfiguracionPorNombre(NombreAtributo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>


        [HttpPut()]
        //[Authorize]
        public IActionResult Put([FromBody] ConfiguracionDto config)
        {
            try
            {
                //TODO

                //string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                string nombreUsuario = "prueba_api";

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
