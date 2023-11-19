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
    public class UpdateConfiguracionUC : IUpdateConfiguracion
    {
        private IRepositorioConfiguracion _repositorioConfiguracion;
        private IRepositorioAuditoria _repositorioAuditoria;

        public UpdateConfiguracionUC(IRepositorioConfiguracion repositorioConfiguracion, IRepositorioAuditoria repositorioAuditoria)
        {
            this._repositorioConfiguracion = repositorioConfiguracion;
            _repositorioAuditoria = repositorioAuditoria;
        }
        public void UpdateConfiguracion(ConfiguracionDto configuracion, string UsuarioLogueado)
        {
            Configuracion aux = new Configuracion();
            aux.Id = configuracion.Id;
            aux.NombreAtributo = configuracion.NombreAtributo;
            aux.topeInferior = configuracion.topeInferior;
            aux.topeSuperior = configuracion.topeSuperior;
            _repositorioConfiguracion.Update(aux);
            Auditoria(UsuarioLogueado, aux.Id);
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
