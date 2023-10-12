using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    public class Configuracion
    {

        [Key]
        public string NombreAtributo { get; set; }
        public int topeSuperior { get; set; }
        public int topeInferior { get; set; }
        public Configuracion() { }
    }
}
