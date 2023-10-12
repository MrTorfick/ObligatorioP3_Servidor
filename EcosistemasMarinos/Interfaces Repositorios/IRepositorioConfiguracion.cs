using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Interfaces_Repositorios
{
    public interface IRepositorioConfiguracion : IRepositorio<Configuracion>
    {
        public int GetTopeSuperior(string nombreAtributo);
        public int GetTopeInferior(string nombreAtributo);
    }
}
