using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
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
            if (string.IsNullOrEmpty(Nombre))
                throw new Exception("El nombre no puede ser nulo ni vacío");

            if (string.IsNullOrEmpty(DetallesGeo))
                throw new Exception("Los detalles geográficos no pueden ser nulos ni vacíos");

            if (Area <= 0)
                throw new Exception("El área debe ser mayor a 0");

        }

        public string GradosMinutosSegundos(string valor)
        {

            string[] grados = valor.Split('.');
            double parteEnteraGrados = int.Parse(grados[0]);
            int parteDecimal = int.Parse(grados[1]);
            int minutos = (parteDecimal * 60);
            string StringMinutos = minutos.ToString();
            int parteEnteraMinutos = int.Parse(StringMinutos.Substring(0, 2));
            int parteDecimalMinutos = int.Parse(StringMinutos.Substring(2, StringMinutos.Length - 2));
            double segundos = (parteDecimalMinutos * 60);
            string StringSegundos = segundos.ToString();
            segundos = double.Parse(StringSegundos.Substring(0, 4));
            segundos = segundos / 100;
            parteEnteraGrados = Math.Abs(parteEnteraGrados);

            return $"{parteEnteraGrados}° {parteEnteraMinutos}' {segundos}''";


        }
    }
}
