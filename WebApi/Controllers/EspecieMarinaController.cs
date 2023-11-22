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
        private IObtenerEspecieMarinaPorId obtenerEspecieMarinaPorId;
        private IBuscarEspeciesQueHabitanUnEcosistema buscarEspeciesQueHabitanUnEcosistema;
        private IAsociarEspecieEcosistema asociarEspecieEcosistema;

        public EspecieMarinaController(IObtenerEspeciesMarinas getEspeciesMariansUC,
                                       IAddEspecieMarina addEspecieMarinaUC,
                                       IUpdateEspecieMarina updateEspecieMarina,
                                       IObtenerEspecieMarinaPorId obtenerEspecieMarinaPorId,
                                       IBuscarEspeciesQueHabitanUnEcosistema buscarEspeciesQueHabitanUnEcosistema,
                                       IAsociarEspecieEcosistema asociarEspecieEcosistema)
        {
            this.getEspeciesMariansUC = getEspeciesMariansUC;
            this.addEspecieMarinaUC = addEspecieMarinaUC;
            this.updateEcosistemaMarinoUC = updateEspecieMarina;
            this.obtenerEspecieMarinaPorId = obtenerEspecieMarinaPorId;
            this.buscarEspeciesQueHabitanUnEcosistema = buscarEspeciesQueHabitanUnEcosistema;
            this.asociarEspecieEcosistema = asociarEspecieEcosistema;
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

        [HttpGet("EspeciesPorEcosistema/{idEcosistema}")]
        public IActionResult GetEspeciesHabitanEcosistema(int idEcosistema)
        {
            try
            {
                return Ok(this.buscarEspeciesQueHabitanUnEcosistema.BuscarEspeciesQueHabitanUnEcosistema(idEcosistema));
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }


        [HttpGet("Especie/{id}")]
        public IActionResult GetDetails(int id)
        {
            try
            {
                return Ok(this.obtenerEspecieMarinaPorId.ObtenerEspecieMarinaPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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

        [HttpPost("Asociar")]
        public IActionResult Post2([FromBody] AsociarEspecieDto asociarDto)
        {
            try
            {
                string nombreUsuario = "prueba_api";
                this.asociarEspecieEcosistema.AsociarEspecieAEcosistema(asociarDto.IdEspecie, asociarDto.EcosistemaSeleccionado, nombreUsuario);
                return Created("api/EspecieMarina", "La solicitud fue procesada con exito");
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
