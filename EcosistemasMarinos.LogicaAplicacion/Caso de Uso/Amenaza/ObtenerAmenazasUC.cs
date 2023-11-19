using _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL;
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
    public class ObtenerAmenazasUC : IObtenerAmenazas
    {

        private IRepositorioAmenaza _repositorioAmenaza;


        public ObtenerAmenazasUC(IRepositorioAmenaza repositorioAmenaza)
        {
            this._repositorioAmenaza = repositorioAmenaza;
        }
        public IEnumerable<AmenazaDto> GetAmenazas()
        {

            List<AmenazaDto> retornar = new List<AmenazaDto>();
            foreach (Amenaza e in _repositorioAmenaza.FindAll().ToList())
            {
                retornar.Add(new AmenazaDto(e));
            }
            return retornar;


            //return _repositorioAmenaza.FindAll();
        }
    }
}
