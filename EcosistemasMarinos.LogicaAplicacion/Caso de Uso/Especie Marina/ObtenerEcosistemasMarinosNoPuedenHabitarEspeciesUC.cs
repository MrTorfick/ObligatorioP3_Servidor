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
    public class ObtenerEcosistemasMarinosNoPuedenHabitarEspeciesUC : IObtenerEcosistemasMarinosNoPuedenHabitarEspecies
    {

        private IRepositorioEspecieMarina _repositorioEspecieMarina;

        public ObtenerEcosistemasMarinosNoPuedenHabitarEspeciesUC(IRepositorioEspecieMarina repositorioEspecieMarina)
        {
            _repositorioEspecieMarina = repositorioEspecieMarina;
        }
        public IEnumerable<EcosistemaMarinoDto> ObtenerEcosistemasMarinosNoPuedenHabitarEspecies(int idEspecie)
        {
            List<EcosistemaMarino> ecosistemasMarinos = _repositorioEspecieMarina.GetEcosistemaMarinosNoPuedenHabitarEspecies(idEspecie).ToList();
            List<EcosistemaMarinoDto> ecosistemaMarinoDto = new List<EcosistemaMarinoDto>();
            if (ecosistemasMarinos.Count > 0)
            {
                foreach (EcosistemaMarino ecosistemaMarino in ecosistemasMarinos)
                {
                    ecosistemaMarinoDto.Add(new EcosistemaMarinoDto(ecosistemaMarino));
                }
            }
            else
            {
                return null;
            }
            return ecosistemaMarinoDto;

        }
    }
}
