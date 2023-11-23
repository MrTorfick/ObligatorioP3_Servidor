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
    public class ObtenerEspecieMarinaPorRangoDePesoUC : IObtenerEspecieMarinaPorRangoPeso
    {
        private IRepositorioEspecieMarina _repositorioEspecieMarina;

        public ObtenerEspecieMarinaPorRangoDePesoUC(IRepositorioEspecieMarina repositorioEspecieMarina)
        {
            _repositorioEspecieMarina = repositorioEspecieMarina;
        }

        public IEnumerable<EspecieMarinaDto> GetEspecieMarinasPeso(double desde, double hasta)
        {
            List<EspecieMarina> especieMarinas = _repositorioEspecieMarina.GetEspecieMarinasPeso(desde, hasta).ToList();
            List<EspecieMarinaDto> especieMarinaDto = new List<EspecieMarinaDto>();
            if (especieMarinas.Count>0)
            {
                foreach (EspecieMarina especieMarina in especieMarinas)
                {
                    especieMarinaDto.Add(new EspecieMarinaDto(especieMarina));
                }
            }
            else
            {
                return null;
            }
            return especieMarinaDto;
        }
    }
}
