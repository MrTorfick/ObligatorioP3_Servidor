using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.DTOs
{
    public class AmenazasAsociadasDto
    {
        public int AmenazaId { get; set; }
        public int? EcosistemaMarinoId { get; set; }

        public int? EspecieMarinaId { get; set; }

        public AmenazasAsociadasDto()
        {

        }


    }
}
