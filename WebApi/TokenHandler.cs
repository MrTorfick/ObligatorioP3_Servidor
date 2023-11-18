using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebApi
{
    public class TokenHandler
    {
        private IObtenerUsuarioPorCredenciales _obtenerUsuarioPorCredenciales;

        public TokenHandler(IObtenerUsuarioPorCredenciales obtenerUsuarioPorCredenciales)
        {
            _obtenerUsuarioPorCredenciales = obtenerUsuarioPorCredenciales;
        }



        public static string GenerarToken(UsuarioDto usuario, IConfiguration configuration)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario.Nombre)
            };

            var claveSecreta = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:SecretTokenKey").Value!));
            var credenciales = new SigningCredentials(claveSecreta, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credenciales);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }

        public UsuarioDto ObtenerUsuario(string email, string password)
        {
            return this._obtenerUsuarioPorCredenciales.ObtenerUsuarioPorCredenciales(email, password);
        }

    }
}
