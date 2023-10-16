using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso
{
    public class AsociarEspecieAEcosistemaUC : IAsociarEspecieEcosistema
    {
        private IRepositorioEspecieMarina repositorioEspecieMarina;

        public AsociarEspecieAEcosistemaUC(IRepositorioEspecieMarina repositorioEspecieMarina)
        {
            this.repositorioEspecieMarina = repositorioEspecieMarina;
        }

        public void AsociarEspecieAEcosistema(int idEspecie, int idEcosistema)
        {
            repositorioEspecieMarina.AsociarEspecieAEcosistema(idEspecie, idEcosistema);
        }
    }
}
