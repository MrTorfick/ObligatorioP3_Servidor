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
        private IVerificarContrasenia _verificarContrasenia { get; set; }

        public LoginController(IConfiguration configuration, IObtenerUsuarioPorCredenciales obtenerUsuarioPorCredenciales, IVerificarContrasenia verificarContrasenia)
        {
            _configuration = configuration;
            _obtenerUsuarioPorCredenciales = obtenerUsuarioPorCredenciales;
            _verificarContrasenia = verificarContrasenia;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login([FromBody] UsuarioDto usuario)
        {
            try
            {
                TokenHandler tokenHandler = new TokenHandler(this._obtenerUsuarioPorCredenciales, _verificarContrasenia);
                UsuarioDto aux = tokenHandler.VerificarDatos(usuario.Password, usuario.Nombre);

                if (aux == null)
                {
                    return Unauthorized("Nombre de usuario o contraseña incorrecta.");
                }

                var token = TokenHandler.GenerarToken(usuario, this._configuration);
                usuario.Token = token;
                usuario.EsAdmin = aux.EsAdmin;
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return Unauthorized("Nombre de usuario o contraseña incorrecta.");
            }
        }

    }
}
