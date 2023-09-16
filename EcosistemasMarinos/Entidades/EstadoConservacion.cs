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
    public class EstadoConservacion : IValidable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required, Range(0, 100, ErrorMessage = "Debe ingresar un valor entre 0 y 100")]
        public int Seguro { get; set; }

        public void Validar()
        {
            if (Seguro < 0 || Seguro > 100)
            {
                throw new RangoValoresException("Debe ingresar un valor entre 0 y 100");
            }
        }
    }
}
