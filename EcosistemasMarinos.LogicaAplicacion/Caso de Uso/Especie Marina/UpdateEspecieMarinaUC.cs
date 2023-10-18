using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Especie_Marina;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso.Especie_Marina
{
    public class UpdateEspecieMarinaUC : IUpdateEspecieMarina
    {

        private IRepositorioEspecieMarina _repositorioEspecieMarina;
        private IRepositorioAuditoria _repositorioAuditoria;

        public UpdateEspecieMarinaUC(IRepositorioEspecieMarina repositorioEspecieMarina, IRepositorioAuditoria repositorioAuditoria)
        {
            this._repositorioEspecieMarina = repositorioEspecieMarina;
            this._repositorioAuditoria = repositorioAuditoria;
        }

        public void UpdateEspecieMarina(EspecieMarina especieMarina, string UsuarioLogueado)
        {
            _repositorioEspecieMarina.Update(especieMarina);
            Auditoria(UsuarioLogueado, especieMarina.Id);
        }


        private void Auditoria(string UsuarioLogueado, int idEntidad)
        {
            Auditoria auditoria = new Auditoria();
            auditoria.NombreUsuario = UsuarioLogueado;
            auditoria.Fecha = DateTime.Now;
            auditoria.IdEntidad = idEntidad;
            auditoria.TipoEntidad = "Update especie marina";
            _repositorioAuditoria.Add(auditoria);
        }


    }
}
