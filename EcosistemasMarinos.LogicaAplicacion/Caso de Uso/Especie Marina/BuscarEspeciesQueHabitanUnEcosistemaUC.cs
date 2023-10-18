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
    public class BuscarEspeciesQueHabitanUnEcosistemaUC : IBuscarEspeciesQueHabitanUnEcosistema
    {

        private IRepositorioEspecieMarina _repositorioEspecieMarina;

        public BuscarEspeciesQueHabitanUnEcosistemaUC(IRepositorioEspecieMarina repositorioEspecieMarina)
        {
            _repositorioEspecieMarina = repositorioEspecieMarina;
        }

        IEnumerable<EspecieMarina> IBuscarEspeciesQueHabitanUnEcosistema.BuscarEspeciesQueHabitanUnEcosistema(int idEcosistema)
        {
            return _repositorioEspecieMarina.GetEspecieHabitanEcosistema(idEcosistema);
        }
    }
}
