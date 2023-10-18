﻿using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso
{
    public class ObtenerPaisPorIdUC : IObtenerPaisPorId
    {
        private IRepositorioPais _repositorioPais;

        public ObtenerPaisPorIdUC(IRepositorioPais repositorioPais)
        {
            this._repositorioPais = repositorioPais;
        }

        public Pais ObtenerPaisPorId(int id)
        {
            return this._repositorioPais.FindByID(id);
        }
    }
}
