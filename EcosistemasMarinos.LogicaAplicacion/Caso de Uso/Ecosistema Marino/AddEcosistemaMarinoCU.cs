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
    public class AddEcosistemaMarinoCU : IAddEcosistemaMarino
    {
        private IRepositorioEcosistemaMarino repositorioEcosistemaMarino;
        private IRepositorioAuditoria repositorioAuditoria;

        public AddEcosistemaMarinoCU(IRepositorioEcosistemaMarino repositorioEcosistemaMarino, IRepositorioAuditoria repositorioAuditoria)
        {
            this.repositorioEcosistemaMarino = repositorioEcosistemaMarino;
            this.repositorioAuditoria = repositorioAuditoria;
        }

        public void AddEcosistemaMarino(EcosistemaMarino ecosistemaMarino, string usuarioLogueado)
        {
            repositorioEcosistemaMarino.Add(ecosistemaMarino);
            Auditoria(usuarioLogueado, ecosistemaMarino.Id);
        }

        private void Auditoria(string UsuarioLogueado, int idEntidad)
        {
            Auditoria auditoria = new Auditoria();
            auditoria.NombreUsuario = UsuarioLogueado;
            auditoria.Fecha = DateTime.Now;
            auditoria.IdEntidad = idEntidad;
            auditoria.TipoEntidad = "Ecosistema Marino";
            repositorioAuditoria.Add(auditoria);
        }
    }
}
