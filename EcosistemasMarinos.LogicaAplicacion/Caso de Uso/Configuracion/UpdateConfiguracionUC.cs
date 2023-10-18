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
    public class UpdateConfiguracionUC : IUpdateConfiguracion
    {
        private IRepositorioConfiguracion _repositorioConfiguracion;
        private IRepositorioAuditoria _repositorioAuditoria;

        public UpdateConfiguracionUC(IRepositorioConfiguracion repositorioConfiguracion, IRepositorioAuditoria repositorioAuditoria)
        {
            this._repositorioConfiguracion = repositorioConfiguracion;
            _repositorioAuditoria = repositorioAuditoria;
        }
        public void UpdateConfiguracion(Configuracion configuracion, string UsuarioLogueado)
        {
            _repositorioConfiguracion.Update(configuracion);
            Auditoria(UsuarioLogueado, configuracion.Id);
        }

        private void Auditoria(string UsuarioLogueado, int idEntidad)
        {
            Auditoria auditoria = new Auditoria();
            auditoria.NombreUsuario = UsuarioLogueado;
            auditoria.Fecha = DateTime.Now;
            auditoria.IdEntidad = idEntidad;
            auditoria.TipoEntidad = "Configuracion";
            _repositorioAuditoria.Add(auditoria);
        }

    }
}
