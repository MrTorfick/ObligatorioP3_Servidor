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
    public class UpdateAmenazaCU : IUpdateAmenaza
    {
        private IRepositorioAmenaza _repositorioAmenaza;
        private IRepositorioAuditoria _repositorioAuditoria;


        public UpdateAmenazaCU(IRepositorioAmenaza repositorioAmenaza, IRepositorioAuditoria repositorioAuditoria)
        {
            this._repositorioAmenaza = repositorioAmenaza;
            _repositorioAuditoria = repositorioAuditoria;
        }

        public void UpdateAmenaza(Amenaza amenaza, string UsuarioLogueado)
        {
            this._repositorioAmenaza.Update(amenaza);
            Auditoria(UsuarioLogueado, amenaza.Id);
        }

        private void Auditoria(string UsuarioLogueado, int idEntidad)
        {
            Auditoria auditoria = new Auditoria();
            auditoria.NombreUsuario = UsuarioLogueado;
            auditoria.Fecha = DateTime.Now;
            auditoria.IdEntidad = idEntidad;
            auditoria.TipoEntidad = "Amenaza";
            _repositorioAuditoria.Add(auditoria);
        }
    }
}
