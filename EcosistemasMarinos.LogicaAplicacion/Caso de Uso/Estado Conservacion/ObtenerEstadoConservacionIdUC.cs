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
    public class ObtenerEstadoConservacionIdUC : IObtenerEstadoConservacionPorId
    {
        private IRepositorioEstadoConservacion _repositorioEstadoConservacion;
        public ObtenerEstadoConservacionIdUC(IRepositorioEstadoConservacion repositorioEstadoConservacion)
        {
            this._repositorioEstadoConservacion = repositorioEstadoConservacion;
        }
        public EstadoConservacionDto ObtenerEstadoConservacionPorId(int id)
        {
            EstadoConservacion estadoConservacion = _repositorioEstadoConservacion.FindByID(id);
            if (estadoConservacion == null)
            {
                return null;
            }
            return new EstadoConservacionDto(estadoConservacion);
        }
    }
}
