using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Ecosistema_Marino;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using Microsoft.AspNetCore.Mvc;
using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcosistemaMarinoController : ControllerBase
    {

        private IAddEcosistemaMarino addEcosistemaMarinoUC;
        private IObtenerEcosistemasMarinos getEcosistemasMarinosUC;
        private IObtenerEstadosConservacion getEstadosConservacionUC;
        private IWebHostEnvironment _environment;
        private IObtenerEstadoConservacionPorId obtenerEstadoConservacionPorIdUC;
        private IObtenerAmenazas getAmenazasUC;
        private IObtenerAmenazaPorId obtenerAmenazasPorIdUC;
        private IObtenerEcosistemaMarinoPorId obtenerEcosistemaMarinoPorIdUC;
        private IBorrarEcosistemaMarino borrarEcosistemaMarinoUC;
        private IUpdateEcosistemaMarino updateEcosistemaMarinoUC;
        private IObtenerPaises obtenerPaisesUC;
        private IObtenerPaisPorISO obtenerPaisPorISOUC;
        private IObtenerEcosistemasMarinosNoPuedenHabitarEspecies obtenerEcosistemasMarinosNoPuedenHabitarEspecies;

        public EcosistemaMarinoController(
            IAddEcosistemaMarino addEcosistemaMarinoUC,
            IWebHostEnvironment environment,
            IObtenerEcosistemasMarinos getEcosistemasMarinosUC,
            IObtenerEstadosConservacion getEstadosConservacionUC,
            IObtenerEstadoConservacionPorId obtenerEstadoConservacionPorIdUC,
            IObtenerAmenazas getAmenazasUC,
            IObtenerAmenazaPorId obtenerAmenazasPorIdUC,
            IObtenerEcosistemaMarinoPorId obtenerEcosistemaMarinoPorIdUC,
            IBorrarEcosistemaMarino borrarEcosistemaMarinoUC,
            IUpdateEcosistemaMarino updateEcosistemaMarinoUC,
            IObtenerPaises obtenerPaisesUC,
            IObtenerPaisPorISO obtenerPaisPorISOUC,
            IObtenerEcosistemasMarinosNoPuedenHabitarEspecies obtenerEcosistemasMarinosNoPuedenHabitarEspecies

            )
        {
            this.addEcosistemaMarinoUC = addEcosistemaMarinoUC;
            _environment = environment;
            this.getEcosistemasMarinosUC = getEcosistemasMarinosUC;
            this.getEstadosConservacionUC = getEstadosConservacionUC;
            this.obtenerEstadoConservacionPorIdUC = obtenerEstadoConservacionPorIdUC;
            this.getAmenazasUC = getAmenazasUC;
            this.obtenerAmenazasPorIdUC = obtenerAmenazasPorIdUC;
            this.obtenerEcosistemaMarinoPorIdUC = obtenerEcosistemaMarinoPorIdUC;
            this.borrarEcosistemaMarinoUC = borrarEcosistemaMarinoUC;
            this.updateEcosistemaMarinoUC = updateEcosistemaMarinoUC;
            this.obtenerPaisesUC = obtenerPaisesUC;
            this.obtenerPaisPorISOUC = obtenerPaisPorISOUC;
            this.obtenerEcosistemasMarinosNoPuedenHabitarEspecies = obtenerEcosistemasMarinosNoPuedenHabitarEspecies;

        }


        [HttpGet(Name = "GetEcosistemasMarinos")]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.getEcosistemasMarinosUC.ObtenerEcosistemasMarinos());
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetDetails(int id)
        {
            try
            {
                return Ok(this.obtenerEcosistemaMarinoPorIdUC.ObtenerEcosistemaMarinoPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost()]
        [Authorize]
        public IActionResult Post([FromBody] EcosistemaMarinoDto ecosistemaMarinoDto)
        {
            try
            {
                string nombreUsuario = "prueba_api";
                EcosistemaMarinoDto ecosistemaMarino = this.addEcosistemaMarinoUC.AddEcosistemaMarino(ecosistemaMarinoDto, nombreUsuario);
                return Created("api/EcosistemaMarino", ecosistemaMarino);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        [Authorize]
        public IActionResult Put([FromBody] EcosistemaMarinoDto ecosistemaMarinoDto)
        {
            try
            {
                string nombreUsuario = "prueba_api";
                this.updateEcosistemaMarinoUC.UpdateEcosistemaMarino(ecosistemaMarinoDto, nombreUsuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                string nombreUsuario = "prueba_api";
                this.borrarEcosistemaMarinoUC.BorrarEcosistemaMarino(id, nombreUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("EcosistemasNoPuedeHabitarEspecie/{idEspecie}")]
        public IActionResult GetEspeciesNoPuedenHabitarEcosistema(int idEspecie)
        {
            try
            {
                return Ok(this.obtenerEcosistemasMarinosNoPuedenHabitarEspecies.ObtenerEcosistemasMarinosNoPuedenHabitarEspecies(idEspecie));
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }


    }
}
