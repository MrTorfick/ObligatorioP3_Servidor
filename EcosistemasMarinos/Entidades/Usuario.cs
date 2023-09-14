using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    public abstract class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }

        public Usuario()
        {

        }
    }
}
