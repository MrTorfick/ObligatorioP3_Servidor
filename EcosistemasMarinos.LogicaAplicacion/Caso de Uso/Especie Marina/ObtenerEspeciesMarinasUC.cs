﻿using _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL;
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
    public class ObtenerEspeciesMarinasUC : IObtenerEspeciesMarinas
    {

        private IRepositorioEspecieMarina _repositorioEspecieMarina;

        public ObtenerEspeciesMarinasUC(IRepositorioEspecieMarina repositorioEspecieMarina)
        {
            this._repositorioEspecieMarina = repositorioEspecieMarina;
        }
        public IEnumerable<EspecieMarinaDto> ObtenerEspeciesMarinas()
        {

            List<EspecieMarinaDto> retornar = new List<EspecieMarinaDto>();
            foreach (EspecieMarina e in _repositorioEspecieMarina.FindAll().ToList())
            {
                retornar.Add(new EspecieMarinaDto(e));
            }
            return retornar;
        }
    }
}
