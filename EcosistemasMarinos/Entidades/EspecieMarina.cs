using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    public class EspecieMarina
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreCientifico { get; set; }
        [Required]
        public string NombreVulgar { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required] 
        public string Imagen { get; set; }
        [Required]
        public double Peso { get; set; }
        [Required]
        public double Longitud { get; set; }
        //[ForeignKey(nameof(EstadoConservacion))] public int EstadoConservacionId { get; set; }
        [Column("Ecosistemas_Vida_Posible")]
        public List<EcosistemaMarino> EcosistemasMarinosVidaPosible { get; set; }
       // [Column("Ecosistemas_Habita")]
       // public List<EcosistemaMarino> EcosistemaMarinos { get; set; }
        //[ForeignKey(nameof(EstadoConservacion))] public int EstadoConservacionId { get; set; }

        public void Validar()
        {


        }


    }
}
