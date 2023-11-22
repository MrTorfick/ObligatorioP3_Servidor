using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.DTOs
{
    public class EcosistemaMarinoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public CoordenadasDto Coordenadas { get; set; }
        public double Area { get; set; }
        public string DescripcionCaracteristicas { get; set; }
        public List<ImagenDto>? Imagen { get; set; }
        public List<EspecieMarinaDto>? EspeciesHabitan { get; set; }
        public List<AmenazasAsociadasDto>? Amenazas { get; set; }
        public int? PaisId { get; set; }
        public int? EstadoConservacionId { get; set; }
        //public string grados_Latitud { get; set; }
        // public string grados_Longitud { get; set; }
        public EcosistemaMarinoDto()
        {
        }
        public EcosistemaMarinoDto(EcosistemaMarino ecosistemaMarino)
        {
            this.Nombre = ecosistemaMarino.Nombre;
            this.Coordenadas = new CoordenadasDto(ecosistemaMarino.Coordenadas.Longitud, ecosistemaMarino.Coordenadas.Latitud);
            this.Area = ecosistemaMarino.Area;
            this.DescripcionCaracteristicas = ecosistemaMarino.DescripcionCaracteristicas;
            this.Id = ecosistemaMarino.Id;
            if (ecosistemaMarino.Imagen != null)
            {
                this.Imagen = new List<ImagenDto>();
                foreach (Imagen imagen in ecosistemaMarino.Imagen)
                {
                    ImagenDto imagen1 = new ImagenDto();
                    imagen1.Valor = imagen.Valor;
                    this.Imagen.Add(imagen1);
                }
            }
            if (ecosistemaMarino.EspeciesHabitan != null)
            {
                this.EspeciesHabitan = new List<EspecieMarinaDto>();
                foreach (EspecieMarina especieMarina in ecosistemaMarino.EspeciesHabitan)
                {
                    EspecieMarinaDto especieMarinaDto = new EspecieMarinaDto();
                    especieMarinaDto.Descripcion = especieMarina.Descripcion;
                    especieMarinaDto.EstadoConservacionId = especieMarina.EstadoConservacionId;
                    especieMarinaDto.Longitud = especieMarina.Longitud;
                    especieMarinaDto.Descripcion = especieMarina.Descripcion;
                    especieMarinaDto.NombreCientifico = especieMarina.NombreCientifico;
                    especieMarinaDto.NombreVulgar = especieMarina.NombreVulgar;
                    especieMarinaDto.Peso = especieMarina.Peso;
                    especieMarinaDto.Id = especieMarina.Id;
                    this.EspeciesHabitan.Add(especieMarinaDto);
                }
            }
            if (ecosistemaMarino.Amenazas != null)
            {
                this.Amenazas = new List<AmenazasAsociadasDto>();
                foreach (AmenazasAsociadas amenazasAsociadas in ecosistemaMarino.Amenazas)
                {
                    AmenazasAsociadasDto amenazasAsociadasDto = new AmenazasAsociadasDto();
                    amenazasAsociadasDto.AmenazaId = amenazasAsociadas.AmenazaId;
                    this.Amenazas.Add(amenazasAsociadasDto);

                }
            }
            this.EstadoConservacionId = ecosistemaMarino.EstadoConservacionId;
            this.PaisId = ecosistemaMarino.PaisId;


        }
    }
}
