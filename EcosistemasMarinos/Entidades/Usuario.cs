using EcosistemasMarinos.Excepciones;
using EcosistemasMarinos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Usuario : IValidable
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(30, MinimumLength =6, ErrorMessage ="El nombre debe tener al menos 6 caracteres")]
        public string Nombre { get; set; }
        [Required]
        public string Contrasenia { get; set; }

        public Usuario(){}

        public void Validar()
        {
            if(Nombre.Length < 6)
            {
                throw new RangoValoresException("El nombre debe tener al menos 6 caracteres");
            }
        }
    }
}
