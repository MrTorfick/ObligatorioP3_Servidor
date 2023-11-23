using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.DTOs
{
    public class CountryDto
    {
        public int Id { get; set; }
        public Name name { get; set; }
        public string cca3 { get; set; }

        public class Name
        {
            public string common { get; set; }
        }

        public CountryDto(Country country)
        {
            if (country != null)
            {
                this.name = new Name();
                this.name.common = country.nombre;
                this.cca3 = country.codigoISO;
                this.Id = country.PaisId;

            }

        }
    }
}
