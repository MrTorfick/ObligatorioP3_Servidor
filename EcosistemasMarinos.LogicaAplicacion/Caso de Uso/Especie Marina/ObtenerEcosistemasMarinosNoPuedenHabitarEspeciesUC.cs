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
    public class ObtenerEcosistemasMarinosNoPuedenHabitarEspeciesUC : IObtenerEcosistemasMarinosNoPuedenHabitarEspecies
    {

        private IRepositorioEspecieMarina _repositorioEspecieMarina;

        public ObtenerEcosistemasMarinosNoPuedenHabitarEspeciesUC(IRepositorioEspecieMarina repositorioEspecieMarina)
        {
            _repositorioEspecieMarina = repositorioEspecieMarina;
        }
        public IEnumerable<EcosistemaMarino> ObtenerEcosistemasMarinosNoPuedenHabitarEspecies(int idEspecie)
        {
            return _repositorioEspecieMarina.GetEcosistemaMarinosNoPuedenHabitarEspecies(idEspecie);
        }
    }
}
