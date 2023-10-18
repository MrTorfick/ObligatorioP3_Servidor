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
    public class AddEstadoConservacionCU : IAddEstadoConservacion
    {
        private IRepositorioEstadoConservacion repositorioEstadoConservacion;
        private IRepositorioAuditoria _repositorioAuditoria;

        public AddEstadoConservacionCU(IRepositorioEstadoConservacion repositorioEstadoConservacion, IRepositorioAuditoria repositorioAuditoria)
        {
            this.repositorioEstadoConservacion = repositorioEstadoConservacion;
            this._repositorioAuditoria = repositorioAuditoria;
        }

        public void AddEstadoConservacion(EstadoConservacion estadoConservacion, string UsuarioLogueado)
        {
            repositorioEstadoConservacion.Add(estadoConservacion);
            Auditoria(UsuarioLogueado, estadoConservacion.Id);
        }

        private void Auditoria(string UsuarioLogueado, int idEntidad)
        {
            Auditoria auditoria = new Auditoria();
            auditoria.NombreUsuario = UsuarioLogueado;
            auditoria.Fecha = DateTime.Now;
            auditoria.IdEntidad = idEntidad;
            auditoria.TipoEntidad = "Agregar estado de conservacion";
            _repositorioAuditoria.Add(auditoria);
        }
    }
}
