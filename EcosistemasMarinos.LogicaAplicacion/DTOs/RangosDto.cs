using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.DTOs
{
    public class RangosDto
    {
        public int Minimo { get; set; }
        public int Maximo { get; set; }

        public RangosDto() { }
        public RangosDto(int Minimo, int Maximo)
        {
            this.Minimo = Minimo;
            this.Maximo = Maximo;
        }
    }
}
