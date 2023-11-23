using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Especie_Marina;
using Microsoft.AspNetCore.Authorization;
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
        private IObtenerEspecieMarinaPorNombreCientifico obtenerEspecieMarinaPorNombreCientifico;
        private IBuscarEspeciesEnPeligroDeExtincion buscarEspeciesEnPeligroDeExtincion;
        private IObtenerEspecieMarinaPorRangoPeso obtenerEspecieMarinaPorRangoPeso;

        public EspecieMarinaController(IObtenerEspeciesMarinas getEspeciesMariansUC,
                                       IAddEspecieMarina addEspecieMarinaUC,
                                       IUpdateEspecieMarina updateEspecieMarina,
                                       IObtenerEspecieMarinaPorId obtenerEspecieMarinaPorId,
                                       IBuscarEspeciesQueHabitanUnEcosistema buscarEspeciesQueHabitanUnEcosistema,
                                       IAsociarEspecieEcosistema asociarEspecieEcosistema,
                                       IObtenerEspecieMarinaPorNombreCientifico obtenerEspecieMarinaPorNombreCientifico,
                                       IBuscarEspeciesEnPeligroDeExtincion buscarEspeciesEnPeligroDeExtincion,
                                       IObtenerEspecieMarinaPorRangoPeso obtenerEspecieMarinaPorRangoPeso)
        {
            this.getEspeciesMariansUC = getEspeciesMariansUC;
            this.addEspecieMarinaUC = addEspecieMarinaUC;
            this.updateEcosistemaMarinoUC = updateEspecieMarina;
            this.obtenerEspecieMarinaPorId = obtenerEspecieMarinaPorId;
            this.buscarEspeciesQueHabitanUnEcosistema = buscarEspeciesQueHabitanUnEcosistema;
            this.asociarEspecieEcosistema = asociarEspecieEcosistema;
            this.obtenerEspecieMarinaPorNombreCientifico = obtenerEspecieMarinaPorNombreCientifico;
            this.buscarEspeciesEnPeligroDeExtincion = buscarEspeciesEnPeligroDeExtincion;
            this.obtenerEspecieMarinaPorRangoPeso = obtenerEspecieMarinaPorRangoPeso;
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

        


        [HttpGet("Especie/{id}")]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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

        [HttpGet("NombreCientifico/{NombreCientifico}")]
        public IActionResult GetNombreCientifico(string NombreCientifico)
        {
            try
            {
                return Ok(this.obtenerEspecieMarinaPorNombreCientifico.GetEspecieMarinaPorNombreCientifico(NombreCientifico));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("PeligroDeExtincion")]
        public IActionResult GetEspeciesEnPeligroDeExtincion()
        {
            try
            {
                return Ok(this.buscarEspeciesEnPeligroDeExtincion.GetEspecieMarinaEnPeligroDeExtincion());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("RangoPeso")]
        public IActionResult GetEspeciesPorRangoDePeso(int desde, int hasta)
        {
            try
            {
                return Ok(this.obtenerEspecieMarinaPorRangoPeso.GetEspecieMarinasPeso(desde, hasta));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("EspeciesHabitanEcosistema/{idEcosistema}")]
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

        


    }
}
