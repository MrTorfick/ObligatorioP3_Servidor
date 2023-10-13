using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    public class EspeciesHabitab
    {
        public int EcosistemaMarinoId { get; set; }
        public int EspecieMarinaId { get; set; }

        public bool Habita { get; set; } = false;


        public EspeciesHabitab()
        {
            //Habita = false;
        }
    }
}
