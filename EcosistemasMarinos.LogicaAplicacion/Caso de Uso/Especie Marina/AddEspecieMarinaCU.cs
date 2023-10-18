using _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL;
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
    public class AddEspecieMarinaCU : IAddEspecieMarina
    {
        private IRepositorioEspecieMarina _repositorioEspecieMarina;
        private IRepositorioAuditoria _repositorioAuditoria;

        public AddEspecieMarinaCU(IRepositorioEspecieMarina repositorioEspecieMarina, IRepositorioAuditoria repositorioAuditoria)
        {
            this._repositorioEspecieMarina = repositorioEspecieMarina;
            this._repositorioAuditoria = repositorioAuditoria;
        }


        public void AddEspecieMarina(EspecieMarina especieMarina, string usuarioLogueado)
        {
            _repositorioEspecieMarina.Add(especieMarina);
            Auditoria(usuarioLogueado, especieMarina.Id);
        }

        private void Auditoria(string UsuarioLogueado, int idEntidad)
        {
            Auditoria auditoria = new Auditoria();
            auditoria.NombreUsuario = UsuarioLogueado;
            auditoria.Fecha = DateTime.Now;
            auditoria.IdEntidad = idEntidad;
            auditoria.TipoEntidad = "Agregar especie marina";
            _repositorioAuditoria.Add(auditoria);
        }
    }
}
