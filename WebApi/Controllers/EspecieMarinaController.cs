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
        private IObtenerEstadoConservacionPorId IObtenerEstadoConservacionPorId;

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
                                       IObtenerEstadoConservacionPorId iObtenerEstadoConservacionPorId)
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
            IObtenerEstadoConservacionPorId = iObtenerEstadoConservacionPorId;
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
                if (especieMarinaDto == null)
                {
                    return BadRequest("Debe ingresar los datos de la especie marina");
                }
                if (especieMarinaDto.EstadoConservacionId <= 0 || especieMarinaDto.EstadoConservacionId == null)
                {
                    return BadRequest("Debe ingresar el estado de conservacion de la especie marina");
                }
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
                if (asociarDto == null)
                {
                    return BadRequest("Debe ingresar los datos de la especie marina");
                }
                IEnumerable<EspecieMarinaDto> especieMarinas = buscarEspeciesQueHabitanUnEcosistema.BuscarEspeciesQueHabitanUnEcosistema(asociarDto.EcosistemaSeleccionado);

                foreach (var item in especieMarinas)
                {
                    if (item.Id == asociarDto.IdEspecie)
                    {
                        return BadRequest("La especie ya se encuentra asociada al ecosistema");
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

                EstadoConservacionDto estadoEspecie = IObtenerEstadoConservacionPorId.ObtenerEstadoConservacionPorId((int)especie.EstadoConservacionId);
                EstadoConservacionDto estadoEcosistema = IObtenerEstadoConservacionPorId.ObtenerEstadoConservacionPorId((int)ecosistema.EstadoConservacionId);

                if (estadoEcosistema.Rangos.Minimo < estadoEspecie.Rangos.Minimo)
                {
                    return BadRequest("La especie no puede habitar el ecosistema porque el estado de conservacion del ecosistema es menor al de la especie");

                }

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
                if (especieMarinaDto == null)
                {
                    return BadRequest("Debe ingresar los datos de la especie marina");
                }

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
                if (desde > hasta)
                {
                    int aux = desde;
                    desde = hasta;
                    hasta = aux;
                }

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
