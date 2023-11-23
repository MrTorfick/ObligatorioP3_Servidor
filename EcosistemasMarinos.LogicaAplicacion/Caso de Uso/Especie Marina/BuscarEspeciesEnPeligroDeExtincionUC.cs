using _EcosistemasMarinos.LogicaAplicacion.DTOs;
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
    public class BuscarEspeciesEnPeligroDeExtincionUC : IBuscarEspeciesEnPeligroDeExtincion
    {

        private IRepositorioEspecieMarina _repositorioEspecieMarina;


        public BuscarEspeciesEnPeligroDeExtincionUC(IRepositorioEspecieMarina repositorioEspecieMarina)
        {
            _repositorioEspecieMarina = repositorioEspecieMarina;
        }

        public IEnumerable<EspecieMarinaDto> GetEspecieMarinaEnPeligroDeExtincion()
        {
            List<EspecieMarina> especieMarinas = _repositorioEspecieMarina.GetEspecieMarinaEnPeligroDeExtincion().ToList();

            List<EspecieMarinaDto> especieMarinasDto = new List<EspecieMarinaDto>();
            if (especieMarinas.Count > 0)
            {
                foreach (EspecieMarina especieMarina in especieMarinas)
                {
                    especieMarinasDto.Add(new EspecieMarinaDto(especieMarina));
                }
            }
            else
            {
                return null;
            }
            return especieMarinasDto;

        }
    }
}
