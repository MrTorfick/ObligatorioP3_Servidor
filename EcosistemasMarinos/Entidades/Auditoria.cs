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
                throw new Exception("Auditoria: El nombre de usuario no puede ser nulo");
            if (Fecha == null)
                throw new Exception("Auditoria: La fecha no puede ser nula");
            if (IdEntidad == null)
                throw new Exception("Auditoria: El id de la entidad no puede ser nulo");
            if (TipoEntidad == null)
                throw new Exception("Auditoria: El tipo de entidad no puede ser nulo");


        }
    }
}
