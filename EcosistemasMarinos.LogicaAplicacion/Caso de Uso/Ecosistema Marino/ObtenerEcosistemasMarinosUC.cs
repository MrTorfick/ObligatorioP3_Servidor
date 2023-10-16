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
    public class ObtenerEcosistemasMarinosUC : IObtenerEcosistemasMarinos
    {

        private IRepositorioEcosistemaMarino _repositorioEcosistemaMarino;

        public ObtenerEcosistemasMarinosUC(IRepositorioEcosistemaMarino repositorioEcosistemaMarino)
        {
           this._repositorioEcosistemaMarino = repositorioEcosistemaMarino;
        }

        public IEnumerable<EcosistemaMarino> ObtenerEcosistemasMarinos()
        {
           return _repositorioEcosistemaMarino.FindAll();
        }
    }
}
