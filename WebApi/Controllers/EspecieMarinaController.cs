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
        private IObtenerEcosistemaMarinoPorId obtenerEcosistemaMarinoPorId;
        private IObtenerEstadoConservacionPorId obtenerEstadoConservacionPorId;

        public EspecieMarinaController(IObtenerEspeciesMarinas getEspeciesMariansUC,
                                       IAddEspecieMarina addEspecieMarinaUC,
                                       IUpdateEspecieMarina updateEspecieMarina,
                                       IObtenerEspecieMarinaPorId obtenerEspecieMarinaPorId,
                                       IBuscarEspeciesQueHabitanUnEcosistema buscarEspeciesQueHabitanUnEcosistema,
                                       IAsociarEspecieEcosistema asociarEspecieEcosistema,
                                       IObtenerEspecieMarinaPorNombreCientifico obtenerEspecieMarinaPorNombreCientifico,
                                       IBuscarEspeciesEnPeligroDeExtincion buscarEspeciesEnPeligroDeExtincion,
                                       IObtenerEspecieMarinaPorRangoPeso obtenerEspecieMarinaPorRangoPeso,
                                       IObtenerEcosistemaMarinoPorId obtenerEcosistemaMarinoPorId,
                                       IObtenerEstadoConservacionPorId obtenerEstadoConservacionPorId
                                       )
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
            this.obtenerEcosistemaMarinoPorId = obtenerEcosistemaMarinoPorId;
            this.obtenerEstadoConservacionPorId = obtenerEstadoConservacionPorId;
        }
        /// <summary>
        /// Obtiene todas las especies marinas
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetEspeciesMarinas")]
        [ProducesResponseType(typeof(IEnumerable<EspecieMarinaDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
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


        /// <summary>
        /// Obtiene una especie marina a partir de su id
        /// </summary>
        /// <param name="id">id de la especie marina</param>
        /// <returns></returns>

        [HttpGet("Especie/{id}")]
        [ProducesResponseType(typeof(EspecieMarinaDto), 200)]
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



                return Ok(this.obtenerEspecieMarinaPorId.ObtenerEspecieMarinaPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Registra una especie en la base de datos
        /// </summary>
        /// <param name="especieMarinaDto">Objeto de tipo especieMarinaDto</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(EspecieMarinaDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        [Authorize]
        public IActionResult Post([FromBody] EspecieMarinaDto especieMarinaDto)
        {
            try
            {

                string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                if (nombreUsuario == "")
                {
                    return Unauthorized();
                }
                if (especieMarinaDto == null)
                {
                    return BadRequest("Debe ingresar los datos de la especie marina");
                }
                if (especieMarinaDto.EstadoConservacionId <= 0 || especieMarinaDto.EstadoConservacionId == null)
                {
                    return BadRequest("Debe ingresar el estado de conservacion de la especie marina");
                }
                if (nombreUsuario == null)
                {
                    nombreUsuario = "Prueba Api";
                }
                EspecieMarinaDto especieMarina = this.addEspecieMarinaUC.AddEspecieMarina(especieMarinaDto, nombreUsuario);
                return Created("api/EspecieMarina", especieMarina);
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }
        /// <summary>
        /// Asocia una especie a un ecosistema
        /// </summary>
        /// <param name="asociarDto">Objeto de tipo asociarDto</param>
        /// <returns></returns>
        [HttpPost("Asociar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]

        [Authorize]
        public IActionResult Post2([FromBody] AsociarEspecieDto asociarDto)
        {
            try
            {
                string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                if (nombreUsuario == "")
                {
                    return Unauthorized();
                }
                if (asociarDto == null)
                {
                    return BadRequest("Debe ingresar los datos de la especie marina");
                }
                IEnumerable<EspecieMarinaDto> especieMarinas = buscarEspeciesQueHabitanUnEcosistema.BuscarEspeciesQueHabitanUnEcosistema(asociarDto.EcosistemaSeleccionado);
                if (especieMarinas != null)
                {
                    foreach (var item in especieMarinas)
                    {
                        if (item.Id == asociarDto.IdEspecie)
                        {
                            return BadRequest("La especie ya se encuentra asociada al ecosistema");
                        }
                    }
                }


                EcosistemaMarinoDto ecosistema = obtenerEcosistemaMarinoPorId.ObtenerEcosistemaMarinoPorId(asociarDto.EcosistemaSeleccionado);
                if (ecosistema == null)
                {
                    return BadRequest("El ecosistema no existe");
                }
                EspecieMarinaDto especie = obtenerEspecieMarinaPorId.ObtenerEspecieMarinaPorId(asociarDto.IdEspecie);
                if (especie == null)
                {
                    return BadRequest("La especie no existe");
                }

                foreach (var item in ecosistema.Amenazas)
                {
                    foreach (var item1 in especie.Amenazas)
                    {
                        if (item.AmenazaId == item1.AmenazaId)
                        {
                            return BadRequest("La especie no puede habitar el ecosistema porque tiene amenazas en comun");
                        }
                    }
                }

                EstadoConservacionDto estadoEspecie = obtenerEstadoConservacionPorId.ObtenerEstadoConservacionPorId((int)especie.EstadoConservacionId);
                EstadoConservacionDto estadoEcosistema = obtenerEstadoConservacionPorId.ObtenerEstadoConservacionPorId((int)ecosistema.EstadoConservacionId);

                if (estadoEcosistema.Rangos.Minimo < estadoEspecie.Rangos.Minimo)
                {
                    return BadRequest("La especie no puede habitar el ecosistema porque el estado de conservacion del ecosistema es menor al de la especie");

                }
                if (nombreUsuario == null)
                {
                    nombreUsuario = "Prueba Api";
                }

                this.asociarEspecieEcosistema.AsociarEspecieAEcosistema(asociarDto.IdEspecie, asociarDto.EcosistemaSeleccionado, nombreUsuario);
                return Created("api/EspecieMarina", "La solicitud fue procesada con exito");
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }

        /// <summary>
        /// Actualiza los datos de una especie marina
        /// </summary>
        /// <param name="especieMarinaDto">Objeto de tipo especieMarinaDto</param>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        [Authorize]
        public IActionResult Put([FromBody] EspecieMarinaDto especieMarinaDto)
        {
            try
            {

                string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                if (nombreUsuario == "")
                {
                    return Unauthorized();
                }
                if (especieMarinaDto == null)
                {
                    return BadRequest("Debe ingresar los datos de la especie marina");
                }
                this.updateEcosistemaMarinoUC.UpdateEspecieMarina(especieMarinaDto, nombreUsuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene una especie marina por su nombre cientifico
        /// </summary>
        /// <param name="NombreCientifico">NombreCientifico de la especie marina</param>
        /// <returns></returns>
        [HttpGet("NombreCientifico/{NombreCientifico}")]
        [ProducesResponseType(typeof(EspecieMarinaDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        public IActionResult GetNombreCientifico(string NombreCientifico)
        {
            try
            {
                if (NombreCientifico == null)
                {
                    return BadRequest("Debe ingresar un Nombre Cientifico valido");
                }


                return Ok(this.obtenerEspecieMarinaPorNombreCientifico.GetEspecieMarinaPorNombreCientifico(NombreCientifico));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Obtiene las especies en peligro de extincion
        /// </summary>
        /// <returns></returns>
        [HttpGet("PeligroDeExtincion")]
        [ProducesResponseType(typeof(EspecieMarinaDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
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

        /// <summary>
        /// Obtiene las especies que esten entre un determinado rango de peso
        /// </summary>
        /// <param name="desde">Peso minimo</param>
        /// <param name="hasta">Peso maximo</param>
        /// <returns></returns>
        [HttpGet("RangoPeso")]
        [ProducesResponseType(typeof(EspecieMarinaDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        public IActionResult GetEspeciesPorRangoDePeso(int desde, int hasta)
        {
            try
            {
                if (desde > hasta)
                {
                    int aux = desde;
                    desde = hasta;
                    hasta = aux;
                }
                if (desde < 0 || hasta < 0)
                {
                    return BadRequest("El peso minimo y el peso maximo no pueden ser negativos");
                }
                else if (desde == 0 && hasta == 0)
                {
                    return BadRequest("Debe ingresar un peso minimo o un peso maximo");
                }

                return Ok(this.obtenerEspecieMarinaPorRangoPeso.GetEspecieMarinasPeso(desde, hasta));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Obtiene las especies que habitan un ecosistema
        /// </summary>
        /// <param name="idEcosistema">id del ecosistema a buscar</param>
        /// <returns></returns>
        [HttpGet("EspeciesHabitanEcosistema/{idEcosistema}")]
        [ProducesResponseType(typeof(EspecieMarinaDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
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
