using EcosistemasMarinos.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    public class EspeciesHabitab : IValidable
    {

        public int EcosistemaMarinoId { get; set; }
        public int EspecieMarinaId { get; set; }

        public bool Habita { get; set; } = false;

        public EspeciesHabitab()
        {
            //Habita = false;
        }

        public void Validar()
        {
            if (EcosistemaMarinoId <= 0)
                throw new Exception("El id del ecosistema marino debe ser mayor a 0");

            if (EspecieMarinaId <= 0)
                throw new Exception("El id de la especie marina debe ser mayor a 0");

        }
    }
}
