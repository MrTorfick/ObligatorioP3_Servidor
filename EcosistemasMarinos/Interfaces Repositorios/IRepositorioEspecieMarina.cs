using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Interfaces_Repositorios
{
    public interface IRepositorioEspecieMarina : IRepositorio<EspecieMarina>
    {

        public void AsociarEspecieAEcosistema(int idEspecie, int idEcosistema);
        public EspecieMarina GetEspecieMarinaPorNombreCientifico(string nombre);

        public IEnumerable<EspecieMarina> GetEspecieMarinaEnPeligroDeExtincion();

        public IEnumerable<EspecieMarina> GetEspecieMarinasPeso(double desde, double hasta);

        public IEnumerable<EspecieMarina> GetEspecieHabitanEcosistema(int idEcosistema);

        public IEnumerable<EcosistemaMarino> GetEcosistemaMarinosNoPuedenHabitarEspecies(int idEspecie);

    }
}
