using EcosistemasMarinos.Excepciones;
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
    public class Rangos : IValidable
    {
        public int Minimo { get; set; }
        public int Maximo { get; set; }
        public Rangos() { }
        public Rangos(int Minimo, int Maximo)
        {
            this.Minimo = Minimo;
            this.Maximo = Maximo;
            Validar();
        }
        public void Validar()
        {
            if (Minimo > Maximo)
            {
                throw new Exception("El valor minimo no puede ser mayor al valor maximo");
            }

            if (Minimo < 0 || Maximo < 0)
            {
                throw new RangoValoresException("Los valores no pueden ser negativos");
            }

        }
    }
}
