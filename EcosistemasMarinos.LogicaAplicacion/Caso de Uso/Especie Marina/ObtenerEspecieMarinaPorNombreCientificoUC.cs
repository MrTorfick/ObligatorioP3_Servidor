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
    public class ObtenerEspecieMarinaPorNombreCientificoUC : IObtenerEspecieMarinaPorNombreCientifico
    {

        private IRepositorioEspecieMarina _repositorioEspecieMarina;


        public ObtenerEspecieMarinaPorNombreCientificoUC(IRepositorioEspecieMarina repositorioEspecieMarina)
        {
            this._repositorioEspecieMarina = repositorioEspecieMarina;
        }


        public EspecieMarina GetEspecieMarinaPorNombreCientifico(string nombreCientifico)
        {
            return _repositorioEspecieMarina.GetEspecieMarinaPorNombreCientifico(nombreCientifico);
        }
    }
}
