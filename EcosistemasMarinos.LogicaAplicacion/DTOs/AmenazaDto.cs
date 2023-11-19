using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.DTOs
{
    public class AmenazaDto
    {

        public int Id { get; set; }

        public string Descripcion { get; set; }
        public int Peligrosidad { get; set; }

        public AmenazaDto(int id, string descripcion, int peligrosidad)
        {
            Id = id;
            Descripcion = descripcion;
            Peligrosidad = peligrosidad;
        }

        public AmenazaDto(Amenaza amenaza)
        {
            this.Id = amenaza.Id;
            this.Descripcion = amenaza.Descripcion;
            this.Peligrosidad = amenaza.Peligrosidad;
        }

        public AmenazaDto()
        {
        }
    }
}
