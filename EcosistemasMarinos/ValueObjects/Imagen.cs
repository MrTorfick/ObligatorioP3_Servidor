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
    public class Imagen : IValidable
    {
        public string Valor { get; set; }

        public Imagen(string valor)
        {
            Valor = valor;
        }

        public Imagen()
        {
            Valor = "Sin imagen";
        }

        public void Validar()
        {
            if (Valor.Length <= 0) throw new Exception("La URL no puede ser vacía.");
            if (Valor.Length >= 50) throw new Exception("La URL es demasiado larga.");
        }
    }
}
