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
    public class ObtenerEcosistemaMarinoPorIdUC : IObtenerEcosistemaMarinoPorId
    {

        private IRepositorioEcosistemaMarino _repositorioEcosistemaMarino;

        public ObtenerEcosistemaMarinoPorIdUC(IRepositorioEcosistemaMarino repositorioEcosistemaMarino)
        {
            this._repositorioEcosistemaMarino = repositorioEcosistemaMarino;
        }
        public EcosistemaMarino ObtenerEcosistemaMarinoPorId(int id)
        {
            return _repositorioEcosistemaMarino.FindByID(id);
        }
    }
}
