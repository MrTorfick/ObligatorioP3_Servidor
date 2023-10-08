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
    public class AddEspecieMarinaCU : IAddEspecieMarina
    {
        private IRepositorioEspecieMarina repositorioEspecieMarina;

        public AddEspecieMarinaCU(IRepositorioEspecieMarina repositorioEspecieMarina)
        {
            this.repositorioEspecieMarina = repositorioEspecieMarina;
        }


        public void AddEspecieMarina(EspecieMarina especieMarina)
        {
            repositorioEspecieMarina.Add(especieMarina);
        }
    }
}
