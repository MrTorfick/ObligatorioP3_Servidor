using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    public class EcosistemaMarino
    {
        public string Nombre { get; set; }
        public string DetallesGeo { get; set; }
        public double Area { get; set; }
        public string DescripcionCaracteristicas { get; set; }
        public List<EspecieMarina> EspeciesHabitan { get; set; }
        public Amenaza Amenaza { get; set; }
        public Pais Pais { get; set; }
        public EstadoConservacion EstadoConservacion { get; set; }

    }
}
