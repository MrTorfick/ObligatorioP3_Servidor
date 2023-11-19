using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Pais;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso.Pais
{
    public class AddPaisesUC : IAddPaises
    {

        private IRepositorioPais repositorioPais;
        private IRepositorioAuditoria _repositorioAuditoria;

        public AddPaisesUC(IRepositorioPais repositorioPais, IRepositorioAuditoria repositorioAuditoria)
        {
            this.repositorioPais = repositorioPais;
            this._repositorioAuditoria = repositorioAuditoria;
        }



        public List<PaisDto> AddPaises(List<PaisDto> paisDto, string UsuarioLogueado)
        {
            List<PaisDto> paisDtos = new List<PaisDto>();
            foreach (var aux in paisDto)
            {
                Country country = new Country(aux.name.common, aux.cca3);
                repositorioPais.Add(country);
                paisDtos.Add(aux);
                Auditoria(UsuarioLogueado, country.PaisId);
            }
            return paisDtos;

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
