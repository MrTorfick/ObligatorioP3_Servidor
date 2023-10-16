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
        public IEnumerable<Configuracion> ObtenerConfiguraciones()
        {
            return _repositorioConfiguracion.FindAll();
        }
    }
}
