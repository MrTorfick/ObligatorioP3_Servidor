using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.DTOs
{
    public class EstadoConservacionDto
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public RangosDto Rangos { get; set; }


        public EstadoConservacionDto() { }

        public EstadoConservacionDto(EstadoConservacion estadoConservacion)
        {
            this.Id = estadoConservacion.Id;
            this.Nombre = estadoConservacion.Nombre;
            int minimo = estadoConservacion.Rangos.Minimo;
            int maximo = estadoConservacion.Rangos.Maximo;
            RangosDto rangos = new RangosDto(minimo, maximo);
            this.Rangos = rangos;
        }
    }
}
