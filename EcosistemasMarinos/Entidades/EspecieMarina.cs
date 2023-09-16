using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    public class EspecieMarina
    {

        public string NombreCientifico { get; set; }
        public string NombreVulgar { get; set; }
        public string Descripcion { get; set; }
        public string RutaImagen { get; set; }
        public double Peso { get; set; }
        public double Longitud { get; set; }
        public EstadoConservacion EstadoConservacion { get; set; }
    }
}
