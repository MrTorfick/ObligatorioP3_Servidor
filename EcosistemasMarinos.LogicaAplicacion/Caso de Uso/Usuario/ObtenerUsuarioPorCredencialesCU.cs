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
    public class ObtenerUsuarioPorCredencialesCU : IObtenerUsuarioPorCredenciales
    {

        private IRepositorioUsuario repositorioUsuario;

        public ObtenerUsuarioPorCredencialesCU(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public UsuarioDto ObtenerUsuarioPorCredenciales(string nombre, string contrasenia)
        {
            Usuario usuario = this.repositorioUsuario.FindUserByCredentials(nombre, contrasenia);
            UsuarioDto usuarioDto = new UsuarioDto(usuario.Nombre, usuario.Contrasenia);
            return usuarioDto;

        }

        
    }
}
