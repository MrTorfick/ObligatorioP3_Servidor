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
    public class UpdateAmenazaCU : IUpdateAmenaza
    {
        private IRepositorioAmenaza _repositorioAmenaza;


        public UpdateAmenazaCU(IRepositorioAmenaza repositorioAmenaza)
        {
            this._repositorioAmenaza = repositorioAmenaza;
        }

        public void UpdateAmenaza(Amenaza amenaza)
        {
            this._repositorioAmenaza.Update(amenaza);
        }
    }
}
