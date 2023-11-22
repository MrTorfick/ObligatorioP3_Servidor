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
    public class ObtenerEspecieMarinaPorIdUC : IObtenerEspecieMarinaPorId
    {
        private IRepositorioEspecieMarina _repositorioEspecieMarina;


        public ObtenerEspecieMarinaPorIdUC(IRepositorioEspecieMarina repositorioEspecieMarina)
        {
            this._repositorioEspecieMarina = repositorioEspecieMarina;
        }

        public EspecieMarinaDto ObtenerEspecieMarinaPorId(int id)
        {
            EspecieMarina especieMarina = _repositorioEspecieMarina.FindByID(id);
            if(especieMarina != null)
            {
                EspecieMarinaDto especieMarinaDto = new EspecieMarinaDto(especieMarina);
                return especieMarinaDto;
            }
            else
            {
                return null;
            }
        }
    }
}
