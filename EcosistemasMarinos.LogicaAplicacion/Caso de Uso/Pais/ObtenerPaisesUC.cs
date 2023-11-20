using _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL;
using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso
{
    public class ObtenerPaisesUC : IObtenerPaises
    {

        private IRepositorioPais _repositorioPais;


        public ObtenerPaisesUC(IRepositorioPais repositorioPais)
        {
            this._repositorioPais = repositorioPais;
        }


        public IEnumerable<CountryDto> ObtenerPaises()
        {

            var listaOrdenada = _repositorioPais.FindAll()
            .OrderBy(o => o.nombre)
            .Select(e => new CountryDto(e));

            return listaOrdenada;
            /*
            List<CountryDto> retornar = new List<CountryDto>();
            foreach (Country e in _repositorioPais.FindAll().ToList())
            {
                retornar.Add(new CountryDto(e));
            }
            List<CountryDto> listaOrdenada = retornar.OrderBy(o => o.name.common).ToList();
            return listaOrdenada;
            */
        }
    }
}
