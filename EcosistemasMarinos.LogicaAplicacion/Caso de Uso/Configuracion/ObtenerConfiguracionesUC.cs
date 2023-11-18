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
    public class ObtenerConfiguracionesUC : IObtenerConfiguraciones
    {
        private IRepositorioConfiguracion _repositorioConfiguracion;

        public ObtenerConfiguracionesUC(IRepositorioConfiguracion repositorioConfiguracion)
        {
            this._repositorioConfiguracion = repositorioConfiguracion;
        }
        public IEnumerable<ConfiguracionDto> ObtenerConfiguraciones()
        {
            List<ConfiguracionDto> retornar = new List<ConfiguracionDto>();
            foreach (Configuracion e in _repositorioConfiguracion.FindAll().ToList())
            {
                retornar.Add(new ConfiguracionDto(e));
            }
            return retornar;
        }

    }
}