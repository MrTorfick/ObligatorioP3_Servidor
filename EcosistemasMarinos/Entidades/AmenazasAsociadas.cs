using EcosistemasMarinos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    public class AmenazasAsociadas : IValidable
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Amenaza))]
        public int AmenazaId { get; set; }
        public int? EcosistemaMarinoId { get; set; }

        public int? EspecieMarinaId { get; set; }


        public void Validar()
        {
            if (AmenazaId < 0)
            {
                throw new Exception("El id de la amenaza, no puede ser menor que 0");
            }
        }
    }
}
