using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Pais;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private IAddPaises addPaisesUC;
        private IObtenerPaises obtenerPaisesUC;
        public PaisController(IAddPaises addPaisesUC, IObtenerPaises obtenerPaises)
        {
            this.addPaisesUC = addPaisesUC;
            this.obtenerPaisesUC = obtenerPaises;
        }

        [HttpGet(Name = "GetPaises")]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.obtenerPaisesUC.ObtenerPaises());
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }



        [HttpPost()]
        public IActionResult Post([FromBody] List<PaisDto> paisDTOs)
        {
            try
            {
                string nombreUsuario = "prueba_api";
                List<PaisDto> aux = addPaisesUC.AddPaises(paisDTOs, nombreUsuario);

                return Created("api/Pais", paisDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
