using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Especie_Marina;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using EcosistemasMarinos.ValueObjects;
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

        public void UpdateEspecieMarina(EspecieMarinaDto especieMarina, string UsuarioLogueado)
        {

            EspecieMarina aux = new EspecieMarina();
            aux.Id = especieMarina.Id;
            aux = _repositorioEspecieMarina.FindByID(aux.Id);
            aux.NombreVulgar = especieMarina.NombreVulgar;
            aux.NombreCientifico = especieMarina.NombreCientifico;
            aux.Descripcion = especieMarina.Descripcion;
            aux.Peso = especieMarina.Peso;
            aux.Longitud = especieMarina.Longitud;
            aux.EstadoConservacionId = especieMarina.EstadoConservacionId;
            aux.Imagen = new List<Imagen>();
            foreach (ImagenDto imagen in especieMarina.Imagen)
            {
                Imagen imagen1 = new Imagen();
                imagen1.Valor = imagen.Valor;
                aux.Imagen.Add(imagen1);
            }
            _repositorioEspecieMarina.Update(aux);
            Auditoria(UsuarioLogueado, aux.Id);


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
