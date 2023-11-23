using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {


        private IAddUsuario ucAddUsuario;
        private IObtenerUsuarioPorCredenciales ObtenerUsuario;

        public UsuarioController(IAddUsuario ucAddUsuario, IObtenerUsuarioPorCredenciales obtenerUsuario)
        {
            this.ucAddUsuario = ucAddUsuario;
            ObtenerUsuario = obtenerUsuario;
        }

        [HttpPost()]
        [Authorize]
        public IActionResult Post([FromBody] UsuarioDto usuario)
        {
            try
            {
                string nombreUsuario = HttpContext.Request.Headers["NombreUsuario"];
                if (nombreUsuario == "")
                {
                    return Unauthorized();
                }

                string rol = HttpContext.Request.Headers["Rol"];
                if (rol != "admin")
                {
                    return Unauthorized();
                }

                if (usuario == null)
                {
                    return BadRequest("Debe ingresar todos los datos");
                }

                UsuarioDto user = this.ucAddUsuario.AddUsuario(usuario, nombreUsuario);
                return Created("api/Usuario", user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
