using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.DTOs
{
    public class UsuarioDto
    {

        public string Nombre { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public bool EsAdmin { get; set; }

        public UsuarioDto()
        {
        }

        public UsuarioDto(string nombre, string password, bool esAdmin)
        {
            Nombre = nombre;
            Password = password;
            EsAdmin = esAdmin;
        }
    }
}
