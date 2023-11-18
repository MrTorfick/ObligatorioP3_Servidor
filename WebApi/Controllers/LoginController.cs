using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _configuration { get; set; }
        private IObtenerUsuarioPorCredenciales _obtenerUsuarioPorCredenciales { get; set; }

        public LoginController(IConfiguration configuration, IObtenerUsuarioPorCredenciales obtenerUsuarioPorCredenciales)
        {
            _configuration = configuration;
            _obtenerUsuarioPorCredenciales = obtenerUsuarioPorCredenciales;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login([FromBody] UsuarioDto usuario)
        {
            try
            {
                TokenHandler tokenHandler = new TokenHandler(this._obtenerUsuarioPorCredenciales);
                var user = tokenHandler.ObtenerUsuario(usuario.Nombre, usuario.Password);
                if (user == null || user.Password != usuario.Password)
                {
                    return Unauthorized("Nombre de usuario o contraseña incorrecta.");
                }
                var token = TokenHandler.GenerarToken(usuario, this._configuration);
                usuario.Token = token;
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return Unauthorized("Nombre de usuario o contraseña incorrecta.");
            }
        }

    }
}
