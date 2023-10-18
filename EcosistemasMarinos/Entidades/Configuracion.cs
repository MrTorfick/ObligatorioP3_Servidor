using EcosistemasMarinos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    [Index(nameof(NombreAtributo), IsUnique = true)]
    public class Configuracion : IValidable
    {
        [Key]
        public int Id { get; set; }

        public string NombreAtributo { get; set; }
        public int topeSuperior { get; set; }
        public int topeInferior { get; set; }
        public Configuracion() { }



        public void Validar()
        {
            if (string.IsNullOrEmpty(NombreAtributo))
                throw new Exception("El nombre del atributo no puede estar vacío.");

            if (topeSuperior < topeInferior)
                throw new Exception("El tope superior no puede ser menor al tope inferior.");

            if (topeSuperior < 0)
                throw new Exception("El tope superior no puede ser menor a 0.");

            if (topeInferior < 0)
                throw new Exception("El tope inferior no puede ser menor a 0.");

        }
    }
}
