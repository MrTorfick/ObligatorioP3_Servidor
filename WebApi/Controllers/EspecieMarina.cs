using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieMarina : ControllerBase
    {

        private IObtenerEspeciesMarinas getEspeciesMariansUC;

        public EspecieMarina(IObtenerEspeciesMarinas getEspeciesMariansUC)
        {
            this.getEspeciesMariansUC = getEspeciesMariansUC;
        }

        [HttpGet(Name = "GetEspeciesMarians")]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.getEspeciesMariansUC.ObtenerEspeciesMarinas());
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }
    }
}
