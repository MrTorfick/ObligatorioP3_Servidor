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


        public IEnumerable<Country> ObtenerPaises()
        {
            return this._repositorioPais.FindAll();
        }
    }
}
