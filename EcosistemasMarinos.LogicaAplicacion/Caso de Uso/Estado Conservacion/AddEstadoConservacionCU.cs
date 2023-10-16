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
    public class AddEstadoConservacionCU : IAddEstadoConservacion
    {
        private IRepositorioEstadoConservacion repositorioEstadoConservacion;

        public AddEstadoConservacionCU(IRepositorioEstadoConservacion repositorioEstadoConservacion)
        {
           this.repositorioEstadoConservacion = repositorioEstadoConservacion;
        }

        public void AddEstadoConservacion(EstadoConservacion estadoConservacion)
        {
            repositorioEstadoConservacion.Add(estadoConservacion);
        }
    }
}
