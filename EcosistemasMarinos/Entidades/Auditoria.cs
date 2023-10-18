using EcosistemasMarinos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    public class Auditoria : IValidable
    {
        [Key]
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEntidad { get; set; }
        public string TipoEntidad { get; set; }

        public void Validar()
        {
            if (NombreUsuario == null)
                throw new Exception("Ocurrio un error al ingresar el nombre de usuario");
            if (Fecha == DateTime.MinValue)
                throw new Exception("Ocurrio un error al ingresar la fecha");
            if (IdEntidad == null)
                throw new Exception("Ocurrio un error en el id de la entidad");
            if (TipoEntidad == null)
                throw new Exception("Ocurrio un error en el tipo de entidad");


        }
    }
}
