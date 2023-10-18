using _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Ecosistema_Marino;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso.Ecosistema_Marino
{
    public class UpdateEcosistemaMarinoUC : IUpdateEcosistemaMarino
    {

        private IRepositorioEcosistemaMarino _repositorioEcosistemaMarino;
        private IRepositorioAuditoria _repositorioAuditoria;

        public UpdateEcosistemaMarinoUC(IRepositorioEcosistemaMarino repositorioEcosistemaMarino, IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioEcosistemaMarino = repositorioEcosistemaMarino;
            _repositorioAuditoria = repositorioAuditoria;
        }

        public void UpdateEcosistemaMarino(EcosistemaMarino ecosistemaMarino, string usuarioLogueado)
        {
            _repositorioEcosistemaMarino.Update(ecosistemaMarino);
            Auditoria(usuarioLogueado, ecosistemaMarino.Id);
        }

        private void Auditoria(string UsuarioLogueado, int idEntidad)
        {
            Auditoria auditoria = new Auditoria();
            auditoria.NombreUsuario = UsuarioLogueado;
            auditoria.Fecha = DateTime.Now;
            auditoria.IdEntidad = idEntidad;
            auditoria.TipoEntidad = "Update ecosistema marino";
            _repositorioAuditoria.Add(auditoria);
        }


    }
}
