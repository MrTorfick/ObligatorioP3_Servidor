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
    public class AsociarEspecieAEcosistemaUC : IAsociarEspecieEcosistema
    {
        private IRepositorioEspecieMarina _repositorioEspecieMarina;
        private IRepositorioAuditoria _repositorioAuditoria;

        public AsociarEspecieAEcosistemaUC(IRepositorioEspecieMarina repositorioEspecieMarina, IRepositorioAuditoria repositorioAuditoria)
        {
            this._repositorioEspecieMarina = repositorioEspecieMarina;
            this._repositorioAuditoria = repositorioAuditoria;
        }

        public void AsociarEspecieAEcosistema(int idEspecie, int idEcosistema, string usuarioLogueado)
        {
            _repositorioEspecieMarina.AsociarEspecieAEcosistema(idEspecie, idEcosistema);
            Auditoria(usuarioLogueado, idEspecie);
        }

        private void Auditoria(string UsuarioLogueado, int idEntidad)
        {
            Auditoria auditoria = new Auditoria();
            auditoria.NombreUsuario = UsuarioLogueado;
            auditoria.Fecha = DateTime.Now;
            auditoria.IdEntidad = idEntidad;
            auditoria.TipoEntidad = "Asociar especie a Ecosistema";
            _repositorioAuditoria.Add(auditoria);
        }
    }
}
