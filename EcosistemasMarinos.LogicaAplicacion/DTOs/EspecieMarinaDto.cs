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

        public EspecieMarinaDto()
        {
        }


        public EspecieMarinaDto(EspecieMarina especieMarina)
        {
            Id = especieMarina.Id;
            NombreCientifico = especieMarina.NombreCientifico;
            NombreVulgar = especieMarina.NombreVulgar;
            Descripcion = especieMarina.Descripcion;

            if (especieMarina.Imagen != null)
            {
                this.Imagen = new List<ImagenDto>();
                foreach (Imagen imagen in especieMarina.Imagen)
                {
                    ImagenDto imagen1 = new ImagenDto();
                    imagen1.Valor = imagen.Valor;
                    this.Imagen.Add(imagen1);
                }
            }

            if (especieMarina.EcosistemaMarinos != null)
            {
                this.EcosistemaMarinos = new List<EcosistemaMarinoDto>();
                foreach (EcosistemaMarino ecosistemaMarino in especieMarina.EcosistemaMarinos)
                {
                    EcosistemaMarinoDto ecosistemaMarinoDto = new EcosistemaMarinoDto();
                    ecosistemaMarinoDto.Nombre = ecosistemaMarino.Nombre;
                    ecosistemaMarinoDto.Area = ecosistemaMarino.Area;
                    ecosistemaMarinoDto.DescripcionCaracteristicas = ecosistemaMarino.DescripcionCaracteristicas;
                    ecosistemaMarinoDto.Id = ecosistemaMarino.Id;
                    ecosistemaMarinoDto.Coordenadas = new CoordenadasDto(ecosistemaMarino.Coordenadas.Longitud, ecosistemaMarino.Coordenadas.Latitud);
                    this.EcosistemaMarinos.Add(ecosistemaMarinoDto);

                    
                }
            }

            if (especieMarina.Amenazas != null)
            {
                this.Amenazas = new List<AmenazasAsociadasDto>();
                foreach (AmenazasAsociadas amenazasAsociadas in especieMarina.Amenazas)
                {
                    AmenazasAsociadasDto amenazasAsociadasDto = new AmenazasAsociadasDto();
                    amenazasAsociadasDto.AmenazaId = amenazasAsociadas.Id;
                    this.Amenazas.Add(amenazasAsociadasDto);
                }
            }

            Peso = especieMarina.Peso;
            Longitud = especieMarina.Longitud;
            EstadoConservacionId = especieMarina.EstadoConservacionId;
        }

    }
}
