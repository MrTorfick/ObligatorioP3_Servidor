using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Pais
{
    public interface IAddPaises
    {
        public List<PaisDto> AddPaises(List<PaisDto> paisDto, string UsuarioLogueado);
    }
}
