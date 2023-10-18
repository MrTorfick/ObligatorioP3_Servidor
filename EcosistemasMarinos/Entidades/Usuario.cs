using EcosistemasMarinos.Excepciones;
using EcosistemasMarinos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Usuario : IValidable
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(30, MinimumLength = 6, ErrorMessage = "El nombre debe tener al menos 6 caracteres")]
        public string Nombre { get; set; }
        [Required]
        public string Contrasenia { get; set; }
        public string ContraseniaEncriptada { get; set; }

        public bool EsAdmin { get; set; }
        public DateTime FechaIngreso { get; set; }

        //public string TipoUsuario { get; set; }

        public Usuario() { }

        public void Validar()
        {
            if (Nombre.Length < 6)
            {
                throw new RangoValoresException("El nombre debe tener al menos 6 caracteres");
            }

            //Crea un regex, para validar una contrasenia para estos requisitos: -Largo minimo de 8 caracteres, al menos una mayuscula, una minuscula, un digito y al menos un caracter de los siguientes: punto, coma, numeral, punto y coma, dos puntos, exclamación de cierre
            string patron = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[.,;:!]).{8,}$";

            if (!Regex.IsMatch(Contrasenia, patron))
            {
                throw new Exception("La contraseña no cumple con los requisitos necesarios\n" +
                    "-Largo minimo de 8 caracteres\n" +
                    "-Al menos: \n" +
                    "Una mayuscula, una minuscula, un digito, y un caracter de los siguientes: \n" +
                    "punto, coma, numeral, punto y coma, dos puntos, exclamacion de cierre");
            }

        }
    }
}
