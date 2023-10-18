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
    public class BorrarEcosistemaMarinoUC : IBorrarEcosistemaMarino
    {
        private IRepositorioEcosistemaMarino _repositorioEcosistemaMarino;
        private IRepositorioAuditoria _repositorioAuditoria;
        public BorrarEcosistemaMarinoUC(IRepositorioEcosistemaMarino repositorioEcosistemaMarino, IRepositorioAuditoria repositorioAuditoria)
        {
            this._repositorioEcosistemaMarino = repositorioEcosistemaMarino;
            this._repositorioAuditoria = repositorioAuditoria;
        }


        public void BorrarEcosistemaMarino(int id, string usuarioLogueado)
        {
            this._repositorioEcosistemaMarino.Remove(id);
            Auditoria(usuarioLogueado, id);
        }

        private void Auditoria(string UsuarioLogueado, int idEntidad)
        {
            Auditoria auditoria = new Auditoria();
            auditoria.NombreUsuario = UsuarioLogueado;
            auditoria.Fecha = DateTime.Now;
            auditoria.IdEntidad = idEntidad;
            auditoria.TipoEntidad = "Borrar Ecosistema Marino";
            _repositorioAuditoria.Add(auditoria);
        }

    }
}
