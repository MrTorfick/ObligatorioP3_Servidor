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


        /// <summary>
        /// Obtiene todos los ecosistemas marinos
        /// </summary>
        /// <returns></returns>

        [HttpGet(Name = "GetEcosistemasMarinos")]
        [ProducesResponseType(typeof(IEnumerable<EcosistemaMarinoDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
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
        /// <summary>
        /// Obtiene un ecosistema marino a partir de su id
        /// </summary>
        /// <param name="id">Id del ecosistema</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EcosistemaMarinoDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]

        [Authorize]
        public IActionResult GetDetails(int id)
        {
            try
            {

                string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                if (nombreUsuario == "")
                {
                    return Unauthorized();
                }

                return Ok(this.obtenerEcosistemaMarinoPorIdUC.ObtenerEcosistemaMarinoPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Registra un ecosistema en la base de datos
        /// </summary>
        /// <param name="ecosistemaMarinoDto">Objeto de tipo EcosistemaMarinoDto</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(EcosistemaMarinoDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        [Authorize]
        public IActionResult Post([FromBody] EcosistemaMarinoDto ecosistemaMarinoDto)
        {
            try
            {
                string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                if (nombreUsuario == "")
                {
                    return Unauthorized();
                }
                if (ecosistemaMarinoDto == null)
                {
                    return BadRequest("Debe ingresar los datos del ecosistema marino");
                }
                if (ecosistemaMarinoDto.Amenazas == null || ecosistemaMarinoDto.Amenazas.Count <= 0)
                {
                    return BadRequest("Debe ingresar al menos una amenaza");
                }
                if (ecosistemaMarinoDto.Coordenadas == null || ecosistemaMarinoDto.Coordenadas.Latitud == null || ecosistemaMarinoDto.Coordenadas.Longitud == null)
                {
                    return BadRequest("Debe ingresar las coordenadas");
                }
                if (nombreUsuario == null)
                {
                    nombreUsuario = "Prueba Api";
                }

                EcosistemaMarinoDto ecosistemaMarino = this.addEcosistemaMarinoUC.AddEcosistemaMarino(ecosistemaMarinoDto, nombreUsuario);
                return Created("api/EcosistemaMarino", ecosistemaMarino);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza los datos de un ecosistema marino
        /// </summary>
        /// <param name="ecosistemaMarinoDto">Objeto de tipo EcosistemaMarinoDto</param>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        [Authorize]
        public IActionResult Put([FromBody] EcosistemaMarinoDto ecosistemaMarinoDto)
        {
            try
            {
                string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                if (nombreUsuario == "")
                {
                    return Unauthorized();
                }


                EcosistemaMarinoDto aux = this.obtenerEcosistemaMarinoPorIdUC.ObtenerEcosistemaMarinoPorId(ecosistemaMarinoDto.Id);

                if (aux == null)
                {
                    return BadRequest("No existe el ecosistema marino");
                }


                if (ecosistemaMarinoDto == null)
                {
                    return BadRequest("Debe ingresar los datos del ecosistema marino");
                }
                if (ecosistemaMarinoDto.Amenazas == null || ecosistemaMarinoDto.Amenazas.Count <= 0)
                {
                    return BadRequest("Debe ingresar al menos una amenaza");
                }
                if (ecosistemaMarinoDto.Coordenadas == null || ecosistemaMarinoDto.Coordenadas.Latitud == null || ecosistemaMarinoDto.Coordenadas.Longitud == null)
                {
                    return BadRequest("Debe ingresar las coordenadas");
                }
                if (nombreUsuario == null)
                {
                    nombreUsuario = "Prueba Api";
                }

                this.updateEcosistemaMarinoUC.UpdateEcosistemaMarino(ecosistemaMarinoDto, nombreUsuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Borra un ecosistema marino de la base de datos
        /// </summary>
        /// <param name="id">Id del ecosistema a borrar</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                if (nombreUsuario == "")
                {
                    return Unauthorized();
                }
                EcosistemaMarinoDto ecosistemaMarinoDto = obtenerEcosistemaMarinoPorIdUC.ObtenerEcosistemaMarinoPorId(id);
                if (ecosistemaMarinoDto == null)
                {
                    return BadRequest("No existe el ecosistema marino");
                }
                if (nombreUsuario == null)
                {
                    nombreUsuario = "Prueba Api";
                }
                this.borrarEcosistemaMarinoUC.BorrarEcosistemaMarino(id, nombreUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Obtiene los ecosistemas marinos que no puede habitar la especie dada
        /// </summary>
        /// <param name="idEspecie">Id de la especie</param>
        /// <returns></returns>
        [HttpGet("EcosistemasNoPuedeHabitarEspecie/{idEspecie}")]
        [ProducesResponseType(typeof(IEnumerable<EcosistemaMarinoDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        public IActionResult GetEspeciesNoPuedenHabitarEcosistema(int idEspecie)
        {
            try
            {
                return Ok(this.obtenerEcosistemasMarinosNoPuedenHabitarEspecies.ObtenerEcosistemasMarinosNoPuedenHabitarEspecies(idEspecie));
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request " + ex.Message);
            }
        }


    }
}
