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
    public class ObtenerEspecieMarinaPorNombreCientificoUC : IObtenerEspecieMarinaPorNombreCientifico
    {

        private IRepositorioEspecieMarina _repositorioEspecieMarina;


        public ObtenerEspecieMarinaPorNombreCientificoUC(IRepositorioEspecieMarina repositorioEspecieMarina)
        {
            this._repositorioEspecieMarina = repositorioEspecieMarina;
        }


        public EspecieMarinaDto GetEspecieMarinaPorNombreCientifico(string nombreCientifico)
        {
            EspecieMarina especieMarina = _repositorioEspecieMarina.GetEspecieMarinaPorNombreCientifico(nombreCientifico);
            if (especieMarina != null)
            {
                return new EspecieMarinaDto(especieMarina);
            }
            return null;

        }
    }
}
