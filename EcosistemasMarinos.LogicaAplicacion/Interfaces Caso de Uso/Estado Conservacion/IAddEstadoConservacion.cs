using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso
{
    public interface IAddEstadoConservacion
    {

       public void AddEstadoConservacion(EstadoConservacion estadoConservacion, string UsuarioLogueado);
    }
}
