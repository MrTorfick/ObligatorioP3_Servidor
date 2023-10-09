using EcosistemasMarinos.Excepciones;
using EcosistemasMarinos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    public class Amenaza : IValidable
    {


        public int Id { get; set; }
        // [Required, StringLength(500, MinimumLength = 50, ErrorMessage = "La descripcion debe tener entre 50 y 500 caracteres")]
        public string Descripcion { get; set; }
        [Required, Range(1, 10, ErrorMessage = "Debe ingresar un valor entre 1 y 10")]
        public int Peligrosidad { get; set; }
        //Necesito que permita null, en la base de datos

        public int? EcosistemaMarinoId { get; set; }
        public EcosistemaMarino? ecosistemaMarino { get; set; }

        public void Validar()
        {
            if (Peligrosidad < 1 || Peligrosidad > 10)
            {
                throw new RangoValoresException("Debe ingresar un valor entre 1 y 10");

            }

        }

        public void CambiarTopesDescripcion(int min, int max)
        {


        }


    }



}
