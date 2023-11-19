using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.DTOs
{
    public class ImagenDto
    {

        public string Valor { get; set; }

        public ImagenDto(string Valor)
        {
            this.Valor = Valor;
        }
        public ImagenDto()
        {
            Valor = "Sin Imagen";
        }
    }
}
