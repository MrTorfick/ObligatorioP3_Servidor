using EcosistemasMarinos.Excepciones;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public List<EcosistemaMarino> EcosistemaMarinos { get; set; }
        //public List<EcosistemaMarino> EcosistemasMarinosVidaPosible { get; set; }

        public List<AmenazasAsociadas> Amenazas { get; set; }

       // public EstadoConservacion EstadoConservacion { get; set; }
        // [Column("Ecosistemas_Habita")]
        // public List<EcosistemaMarino> EcosistemaMarinos { get; set; }
        //[ForeignKey(nameof(EstadoConservacion))] public int EstadoConservacionId { get; set; }
        public EspecieMarina() { }
        public void Validar(IRepositorioConfiguracion configuracion)
        {

            if (string.IsNullOrEmpty(NombreCientifico))
                throw new Exception("El nombre cientifico no puede ser nulo ni vacío");

            if (string.IsNullOrEmpty(NombreVulgar))
                throw new Exception("El nombre vulgar no puede ser nulo ni vacío");

            if (string.IsNullOrEmpty(Descripcion))
                throw new Exception("La descripcion no puede ser nula ni vacía");
            if (string.IsNullOrEmpty(Imagen))
                throw new Exception("La imagen no puede ser nula ni vacía");
            if (Peso <= 0)
                throw new Exception("El peso debe ser mayor a 0");
            if (Longitud <= 0)
                throw new Exception("La longitud debe ser mayor a 0");


            if (NombreCientifico.Length < configuracion.GetTopeInferior("EspecieNombreCientifico"))
            {
                throw new RangoValoresException("Nombre cientifico demasiado corto");
            }

            if (NombreCientifico.Length > configuracion.GetTopeSuperior("EspecieNombreCientifico"))
            {
                throw new RangoValoresException("Nombre cientifico demasiado largo");
            }

            if (NombreVulgar.Length < configuracion.GetTopeInferior("EspecieNombreVulgar"))
            {
                throw new RangoValoresException("Nombre vulgar demasiado corto");
            }

            if (NombreVulgar.Length > configuracion.GetTopeSuperior("EspecieNombreVulgar"))
            {
                throw new RangoValoresException("Nombre vulgar demasiado largo");
            }

            if (Descripcion.Length < configuracion.GetTopeInferior("EspecieDescripcion"))
            {
                throw new RangoValoresException("Descripcion demasiado corta");
            }

            if (Descripcion.Length > configuracion.GetTopeSuperior("EspecieDescripcion"))
            {
                throw new RangoValoresException("Descripcion demasiado larga");
            }
        }


    }
}
