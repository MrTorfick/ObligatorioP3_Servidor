using EcosistemasMarinos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.ValueObjects
{
    [Owned]
    public class Coordenadas : IValidable
    {


        public string Longitud { get; set; }
        public string Latitud { get; set; }

        public Coordenadas(string Longitud, string Latitud)
        {
            this.Longitud = Longitud;
            this.Latitud = Latitud;
            Validar();
        }
        public Coordenadas()
        {
            Longitud = "";
            Latitud = "";
        }


        public void Validar()
        {
           if(string.IsNullOrEmpty(Longitud) || string.IsNullOrEmpty(Latitud))
            {
                throw new Exception("Debe ingresar un dato valido");
            }


        }
    }
}

