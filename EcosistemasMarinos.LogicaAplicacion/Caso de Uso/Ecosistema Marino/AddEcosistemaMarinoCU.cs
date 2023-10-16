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
    public class AddEcosistemaMarinoCU : IAddEcosistemaMarino
    {
        private IRepositorioEcosistemaMarino repositorioEcosistemaMarino;

        public AddEcosistemaMarinoCU(IRepositorioEcosistemaMarino repositorioEcosistemaMarino)
        {
            this.repositorioEcosistemaMarino = repositorioEcosistemaMarino;
        }

        public void AddEcosistemaMarino(EcosistemaMarino ecosistemaMarino)
        {
            repositorioEcosistemaMarino.Add(ecosistemaMarino);
        }
    }
}
