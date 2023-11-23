using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion
{
    public class VerificarContraseniaCU : IVerificarContrasenia
    {

        private IRepositorioUsuario repositorioUsuario;

        public VerificarContraseniaCU(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }
        UsuarioDto IVerificarContrasenia.VerificarContrasenia(string contraseniaIngresada, string NombreUsuario)
        {
            Usuario aux = repositorioUsuario.ObtenerContraseniaEncriptada(NombreUsuario);
            if (aux == null)
            {
                return null;
            }
            string aux2 = ValidarContrasenia(contraseniaIngresada, aux.ContraseniaEncriptada);
            if (aux2 != null)
            {
                Usuario user = repositorioUsuario.FindUserByCredentials(NombreUsuario, aux2);
                UsuarioDto usuarioDto = new UsuarioDto();

                usuarioDto.Nombre = user.Nombre;
                usuarioDto.Password = user.ContraseniaEncriptada;
                return usuarioDto;
            }
            else
            {
                return null;
            }
        }


        private string ValidarContrasenia(string contraseniaIngresada, string contraseniaAlmacenada)
        {
            using (SHA256 sHA256 = SHA256.Create())
            {
                byte[] bytesContraseniaIngresada = Encoding.UTF8.GetBytes(contraseniaIngresada);
                byte[] hashContraseniaIngresada = sHA256.ComputeHash(bytesContraseniaIngresada);

                string contraseniaIngresadaEncriptada = BitConverter.ToString(hashContraseniaIngresada).Replace("-", "").ToLower();
                if (contraseniaIngresadaEncriptada.Equals(contraseniaAlmacenada))
                {
                    return contraseniaIngresadaEncriptada;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
