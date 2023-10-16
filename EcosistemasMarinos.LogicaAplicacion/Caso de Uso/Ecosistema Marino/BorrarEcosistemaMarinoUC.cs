using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso
{
    public class BorrarEcosistemaMarinoUC : IBorrarEcosistemaMarino
    {
        private IRepositorioEcosistemaMarino _repositorioEcosistemaMarino;
        public BorrarEcosistemaMarinoUC(IRepositorioEcosistemaMarino repositorioEcosistemaMarino)
        {
            this._repositorioEcosistemaMarino = repositorioEcosistemaMarino;
        }


        public void BorrarEcosistemaMarino(int id)
        {
            this._repositorioEcosistemaMarino.Remove(id);
        }

    }
}
