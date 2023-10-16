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
    public class AddUsuarioCU : IAddUsuario
    {
        private IRepositorioUsuario repositorioUsuario;

        public AddUsuarioCU(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public void AddUsuario(Usuario usuario)
        {
            repositorioUsuario.Add(usuario);
        }
    }
}
