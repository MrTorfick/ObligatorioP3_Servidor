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
    public class ObtenerEspecieMarinaPorRangoDePesoUC : IObtenerEspecieMarinaPorRangoPeso
    {
        private IRepositorioEspecieMarina _repositorioEspecieMarina;

        public ObtenerEspecieMarinaPorRangoDePesoUC(IRepositorioEspecieMarina repositorioEspecieMarina)
        {
            _repositorioEspecieMarina = repositorioEspecieMarina;
        }

        public IEnumerable<EspecieMarina> GetEspecieMarinasPeso(double desde, double hasta)
        {
            return _repositorioEspecieMarina.GetEspecieMarinasPeso(desde, hasta);
        }
    }
}
