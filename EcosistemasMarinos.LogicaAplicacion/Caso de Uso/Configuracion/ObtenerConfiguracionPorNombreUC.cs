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
    public class ObtenerConfiguracionPorNombreUC : IObtenerConfiguracionPorNombre
    {
        private IRepositorioConfiguracion _repositorioConfiguracion;


        public ObtenerConfiguracionPorNombreUC(IRepositorioConfiguracion repositorioConfiguracion)
        {
            this._repositorioConfiguracion = repositorioConfiguracion;
        }

        public ConfiguracionDto ObtenerConfiguracionPorNombre(string nombre)
        {
            Configuracion aux = _repositorioConfiguracion.FindByName(nombre);
            if (aux != null)
            {
                ConfiguracionDto configuracion = new ConfiguracionDto(aux);
                return configuracion;
            }
            else
            {
                return null;
            }
        }
    }
}
