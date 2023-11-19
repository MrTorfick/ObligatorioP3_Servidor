using _EcosistemasMarinos.LogicaAplicacion.DTOs;
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
        public PaisController(IAddPaises addPaisesUC)
        {
            this.addPaisesUC = addPaisesUC;
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
