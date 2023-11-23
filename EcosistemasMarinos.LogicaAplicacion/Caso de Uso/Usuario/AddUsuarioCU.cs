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
    public class AddUsuarioCU : IAddUsuario
    {
        private IRepositorioUsuario repositorioUsuario;
        private IRepositorioAuditoria _repositorioAuditoria;

        public AddUsuarioCU(IRepositorioUsuario repositorioUsuario, IRepositorioAuditoria repositorioAuditoria)
        {
            this.repositorioUsuario = repositorioUsuario;
            _repositorioAuditoria = repositorioAuditoria;
        }

        public UsuarioDto AddUsuario(UsuarioDto usuario, string IdUsuarioLogueado)
        {
            if (usuario == null)
            {
                throw new Exception("Debe ingresar todos los datos");
            }
            Usuario aux = new Usuario();
            aux.Nombre = usuario.Nombre;
            aux.Contrasenia = usuario.Password;
            aux.ContraseniaEncriptada = EncriptarContrasenia(usuario.Password);
            aux.FechaIngreso = DateTime.Now;
            repositorioUsuario.Add(aux);
            UsuarioDto usuarioDto = new UsuarioDto();
            usuarioDto.Nombre = aux.Nombre;
            usuarioDto.Password = aux.ContraseniaEncriptada;
            return usuarioDto;
            Auditoria(IdUsuarioLogueado, aux.Id);
        }

        private void Auditoria(string UsuarioLogueado, int idEntidad)
        {
            Auditoria auditoria = new Auditoria();
            auditoria.NombreUsuario = UsuarioLogueado;
            auditoria.Fecha = DateTime.Now;
            auditoria.IdEntidad = idEntidad;
            auditoria.TipoEntidad = "Agregar usuario";
            _repositorioAuditoria.Add(auditoria);
        }

        private string EncriptarContrasenia(string contrasenia)
        {
            byte[] bytesContrasenia = Encoding.UTF8.GetBytes(contrasenia);

            using (SHA256 sHA256 = SHA256.Create())
            {
                byte[] hashContrasenia = sHA256.ComputeHash(bytesContrasenia);

                string contraseniaEncriptada = BitConverter.ToString(hashContrasenia).Replace("-", "").ToLower();//Se eliminan los guiones
                return contraseniaEncriptada;
            }
        }


    }
}
