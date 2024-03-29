﻿using _EcosistemasMarinos.LogicaAplicacion.DTOs;
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

        public IEnumerable<EspecieMarinaDto> BuscarEspeciesQueHabitanUnEcosistema(int idEcosistema)
        {
            IEnumerable<EspecieMarina> especiesMarinas = new List<EspecieMarina>();
            especiesMarinas = _repositorioEspecieMarina.GetEspecieHabitanEcosistema(idEcosistema);
            List<EspecieMarinaDto> especieMarinaDto = new List<EspecieMarinaDto>();
            if (especiesMarinas.Count() == 0)
            {
                return null;
            }
            foreach (EspecieMarina especieMarina in especiesMarinas)
            {
                especieMarinaDto.Add(new EspecieMarinaDto(especieMarina));
            }
            return especieMarinaDto;

        }

    }
}
