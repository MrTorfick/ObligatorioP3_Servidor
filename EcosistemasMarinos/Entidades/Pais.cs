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
    public class Pais
    {
        [Key]
        public string nombre { get; set; }
        [Key]
        public string codigoISO { get; set; }
    }
}
