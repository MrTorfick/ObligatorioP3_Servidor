using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace _EcosistemasMarinos.LogicaAplicacion.DTOs
{
    public class EspecieMarinaDto
    {

        [JsonIgnore]
        public int Id { get; set; }
        public string NombreCientifico { get; set; }
        public string NombreVulgar { get; set; }
        public string Descripcion { get; set; }
        public List<ImagenDto> Imagen { get; set; }
        public double Peso { get; set; }
        public double Longitud { get; set; }
        public List<EcosistemaMarinoDto> EcosistemaMarinos { get; set; }
        public List<AmenazasAsociadasDto> Amenazas { get; set; }
        public int? EstadoConservacionId { get; set; }
    }
}
