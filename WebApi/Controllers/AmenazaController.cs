using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenazaController : ControllerBase
    {
        private IObtenerAmenazas _obtenerAmenazasUC;
        private IObtenerAmenazaPorId _obtenerAmenazaPorIdUC;

        public AmenazaController(
                       IObtenerAmenazas obtenerAmenazasUC,
                       IObtenerAmenazaPorId obtenerAmenazaPorIdUC
                       )
        {
            this._obtenerAmenazasUC = obtenerAmenazasUC;
            this._obtenerAmenazaPorIdUC = obtenerAmenazaPorIdUC;

        }

        [HttpGet(Name = "GetAmenazas")]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                return Ok(this._obtenerAmenazasUC.GetAmenazas());
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request" + ex.Message);
            }
        }


        [HttpGet("{AmenazaId}")]
        [Authorize]
        public IActionResult GetDetails(int AmenazaId)
        {
            try
            {
                return Ok(this._obtenerAmenazaPorIdUC.ObtenerAmenazaPorId(AmenazaId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
