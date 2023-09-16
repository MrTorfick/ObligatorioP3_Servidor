using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    public class EcosistemaMarino
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DetallesGeo { get; set; }
        public double Area { get; set; }
        public string DescripcionCaracteristicas { get; set; }
        public string RutaImagen { get; set; }
        public List<EspecieMarina> EspeciesHabitan { get; set; }
        [ForeignKey(nameof(Amenaza))]
        public Amenaza Amenaza { get; set; }
        [ForeignKey(nameof(Pais))]
        public Pais Pais { get; set; }
        [ForeignKey(nameof(EstadoConservacion))]
        public EstadoConservacion EstadoConservacion { get; set; }

    }
}
