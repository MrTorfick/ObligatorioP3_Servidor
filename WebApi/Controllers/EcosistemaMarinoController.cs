using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Ecosistema_Marino;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using Microsoft.AspNetCore.Mvc;
using _EcosistemasMarinos.LogicaAplicacion.DTOs;

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
            IObtenerPaisPorISO obtenerPaisPorISOUC

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


    }
}
