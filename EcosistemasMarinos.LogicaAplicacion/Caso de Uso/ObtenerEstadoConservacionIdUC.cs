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
        private IRepositorioEstadoConservacion repositorioEstadoConservacion;
        public ObtenerEstadoConservacionIdUC(IRepositorioEstadoConservacion repositorioEstadoConservacion)
        {
            this.repositorioEstadoConservacion = repositorioEstadoConservacion;
        }
        public EstadoConservacion ObtenerEstadoConservacionPorId(int id)
        {
            return repositorioEstadoConservacion.FindByID(id);
        }
    }
}
