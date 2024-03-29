﻿using EcosistemasMarinos.Excepciones;
using EcosistemasMarinos.Interfaces;
using EcosistemasMarinos.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class EstadoConservacion : IValidable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
     
        [Required]
        public Rangos Rangos { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("Debe ingresar un nombre valido");
            }
            if (Rangos == null)
            {
                throw new Exception("Debe ingresar rangos validos");
            }
        }
    }
}
