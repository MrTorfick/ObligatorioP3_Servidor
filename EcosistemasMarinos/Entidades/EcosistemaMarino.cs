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
        [Required, StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        public string Nombre { get; set; }
        [Required]
        public string DetallesGeo { get; set; }
        [Required]
        public double Area { get; set; }
        [Required]
        public string DescripcionCaracteristicas { get; set; }
        [Required]
        public string RutaImagen { get; set; }
        [Required]
        public List<EspecieMarina> EspeciesHabitan { get; set; }
        [Required, ForeignKey(nameof(Amenaza))]
        public Amenaza Amenaza { get; set; }
        [Required, ForeignKey(nameof(Pais))]
        public Pais Pais { get; set; }
        [Required, ForeignKey(nameof(EstadoConservacion))]
        public EstadoConservacion EstadoConservacion { get; set; }

    }
}
