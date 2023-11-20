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
    public class ObtenerPaisPorISOUC : IObtenerPaisPorISO
    {
        private IRepositorioPais _repositorioPais;

        public ObtenerPaisPorISOUC(IRepositorioPais repositorioPais)
        {
            this._repositorioPais = repositorioPais;
        }

        public PaisDto IObtenerPaisPorISO(string iso)
        {
            Country pais = this._repositorioPais.FindByIso(iso);
            if (pais != null)
            {
                PaisDto paisDto = new PaisDto();
                paisDto.name.common = pais.nombre;
                paisDto.cca3 = pais.codigoISO;
                paisDto.id = pais.PaisId;
                return paisDto;
            }
            return null;
        }
    }
}
