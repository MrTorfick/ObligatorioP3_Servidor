using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Especie_Marina;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieMarinaController : ControllerBase
    {

        private IObtenerEspeciesMarinas getEspeciesMariansUC;
        private IAddEspecieMarina addEspecieMarinaUC;
        private IUpdateEspecieMarina updateEcosistemaMarinoUC;

        public EspecieMarinaController(IObtenerEspeciesMarinas getEspeciesMariansUC,
                                       IAddEspecieMarina addEspecieMarinaUC,
                                       IUpdateEspecieMarina updateEspecieMarina)
        {
            this.getEspeciesMariansUC = getEspeciesMariansUC;
            this.addEspecieMarinaUC = addEspecieMarinaUC;
            this.updateEcosistemaMarinoUC = updateEspecieMarina;
        }

        [HttpGet(Name = "GetEspeciesMarinas")]
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



        [HttpPost()]

        public IActionResult Post([FromBody] EspecieMarinaDto especieMarinaDto)
        {
            try
            {
                string nombreUsuario = "prueba_api";
                EspecieMarinaDto especieMarina = this.addEspecieMarinaUC.AddEspecieMarina(especieMarinaDto, nombreUsuario);
                return Created("api/EspecieMarina", especieMarina);
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }


        [HttpPut()]
        public IActionResult Put([FromBody] EspecieMarinaDto especieMarinaDto)
        {
            try
            {
                string nombreUsuario = "prueba_api";
                this.updateEcosistemaMarinoUC.UpdateEspecieMarina(especieMarinaDto, nombreUsuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
