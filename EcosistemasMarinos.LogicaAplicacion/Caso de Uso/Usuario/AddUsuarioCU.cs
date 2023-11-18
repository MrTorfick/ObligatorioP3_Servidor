using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso
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

        public void AddUsuario(Usuario usuario, string IdUsuarioLogueado)
        {
            usuario.ContraseniaEncriptada = EncriptarContrasenia(usuario.Contrasenia);
            usuario.FechaIngreso = DateTime.Now;
            repositorioUsuario.Add(usuario);
            Auditoria(IdUsuarioLogueado, usuario.Id);
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
