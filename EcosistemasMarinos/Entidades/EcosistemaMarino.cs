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

        public string RutaImagen { get; set; }
        //[Required]
        public List<EspecieMarina> EspeciesHabitan { get; set; }
        [ForeignKey(nameof(Amenaza))] public int AmenazaId { get; set; }
        
        //public Amenaza Amenaza { get; set; }
        [ForeignKey(nameof(Pais))] public int PaisId { get; set; }
        //public Pais Pais { get; set; }
        [ForeignKey(nameof(EstadoConservacion))] public int EstadoConservacionId { get; set; }
        //public EstadoConservacion EstadoConservacion { get; set; }

        public void Validar()
        {
            if(string.IsNullOrEmpty(Nombre))
                throw new Exception("El nombre no puede ser nulo ni vacío");

            if (string.IsNullOrEmpty(DetallesGeo))
                throw new Exception("Los detalles geográficos no pueden ser nulos ni vacíos");

            if (Area <= 0)
                throw new Exception("El área debe ser mayor a 0");

        }
    }
}
