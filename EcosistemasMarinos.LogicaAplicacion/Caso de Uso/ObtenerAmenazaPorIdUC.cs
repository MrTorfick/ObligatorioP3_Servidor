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
    public class ObtenerAmenazaPorIdUC : IObtenerAmenazaPorId
    {
        private IRepositorioAmenaza _repositorioAmenaza;

        public ObtenerAmenazaPorIdUC(IRepositorioAmenaza repositorioAmenaza)
        {
            this._repositorioAmenaza = repositorioAmenaza;
        }

        public Amenaza ObtenerAmenazaPorId(int id)
        {
            return _repositorioAmenaza.FindByID(id);
        }
    }
}
