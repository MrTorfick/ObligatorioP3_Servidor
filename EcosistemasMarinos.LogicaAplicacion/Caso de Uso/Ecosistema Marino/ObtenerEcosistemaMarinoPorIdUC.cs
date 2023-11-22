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
    public class ObtenerEcosistemaMarinoPorIdUC : IObtenerEcosistemaMarinoPorId
    {

        private IRepositorioEcosistemaMarino _repositorioEcosistemaMarino;

        public ObtenerEcosistemaMarinoPorIdUC(IRepositorioEcosistemaMarino repositorioEcosistemaMarino)
        {
            this._repositorioEcosistemaMarino = repositorioEcosistemaMarino;
        }
        public EcosistemaMarinoDto ObtenerEcosistemaMarinoPorId(int id)
        {

            EcosistemaMarino ecosistemaMarino = _repositorioEcosistemaMarino.FindByID(id);

            if (ecosistemaMarino == null)
            {
                throw new Exception("No existe el ecosistema marino");
            }

            EcosistemaMarinoDto ecosistemaMarinoDto = new EcosistemaMarinoDto(ecosistemaMarino);

            return ecosistemaMarinoDto;


        }
    }
}
