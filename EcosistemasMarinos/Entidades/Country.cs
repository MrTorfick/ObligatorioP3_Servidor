﻿using EcosistemasMarinos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcosistemasMarinos.Entidades
{

    [Index(nameof(nombre), IsUnique = true)]
    [Index(nameof(codigoISO), IsUnique = true)]

    public class Country : IValidable
    {
        [Key]
        public int PaisId { get; set; }

        public string nombre { get; set; }

        public string codigoISO { get; set; }


        public Country()
        {

        }
        public Country(string nombre, string codigoISO)
        {
            this.nombre = nombre;
            this.codigoISO = codigoISO;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new Exception("El nombre no puede ser nulo ni vacío");
            }
            if (string.IsNullOrEmpty(codigoISO))
            {
                throw new Exception("El código ISO no puede ser nulo ni vacío");
            }
        }
    }
}
