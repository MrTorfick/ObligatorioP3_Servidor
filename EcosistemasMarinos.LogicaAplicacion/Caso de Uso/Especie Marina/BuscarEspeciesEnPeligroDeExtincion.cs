using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Especie_Marina;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso.Especie_Marina
{
    public class BuscarEspeciesEnPeligroDeExtincion : IBuscarEspeciesEnPeligroDeExtincion
    {

        private IRepositorioEspecieMarina _repositorioEspecieMarina;


        public BuscarEspeciesEnPeligroDeExtincion(IRepositorioEspecieMarina repositorioEspecieMarina)
        {
            _repositorioEspecieMarina = repositorioEspecieMarina;
        }

        public IEnumerable<EspecieMarina> GetEspecieMarinaEnPeligroDeExtincion()
        {
            return _repositorioEspecieMarina.GetEspecieMarinaEnPeligroDeExtincion();
        }
    }
}
