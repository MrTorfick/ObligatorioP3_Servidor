using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.DTOs
{
    public class CoordenadasDto
    {

        public string Longitud { get; set; }
        public string Latitud { get; set; }

        public CoordenadasDto(string Longitud, string Latitud)
        {
            this.Longitud = Longitud;
            this.Latitud = Latitud;
        }
        public CoordenadasDto()
        {
            Longitud = "";
            Latitud = "";
        }
    }
}
