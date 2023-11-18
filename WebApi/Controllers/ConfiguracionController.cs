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


        [HttpGet(Name = "GetConfiguraciones")]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                return Ok(this._obtenerConfiguracionesUC.ObtenerConfiguraciones());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{NombreAtributo}")]
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
    }
}
