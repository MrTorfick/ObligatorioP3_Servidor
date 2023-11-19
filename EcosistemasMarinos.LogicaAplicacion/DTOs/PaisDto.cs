using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.DTOs
{
    public class PaisDto
    {

        public Name name { get; set; }
        public string cca3 { get; set; }



        public class Name
        {
            public string common { get; set; }
        }
    }
}
