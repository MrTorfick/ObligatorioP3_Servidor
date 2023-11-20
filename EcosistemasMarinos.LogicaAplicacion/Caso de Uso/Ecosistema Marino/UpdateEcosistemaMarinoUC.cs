using _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL;
using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Ecosistema_Marino;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using EcosistemasMarinos.ValueObjects;
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

        public void UpdateEcosistemaMarino(EcosistemaMarinoDto ecosistemaMarino, string usuarioLogueado)
        {
            EcosistemaMarino aux = new EcosistemaMarino();
            aux.Id = ecosistemaMarino.Id;
            aux = _repositorioEcosistemaMarino.FindByID(aux.Id);
            aux.Nombre = ecosistemaMarino.Nombre;
            aux.Area = ecosistemaMarino.Area;
            aux.Coordenadas = new Coordenadas(ecosistemaMarino.Coordenadas.Longitud, ecosistemaMarino.Coordenadas.Latitud);
            aux.Area = ecosistemaMarino.Area;
            aux.DescripcionCaracteristicas = ecosistemaMarino.DescripcionCaracteristicas;
            if (ecosistemaMarino.Imagen != null)
            {
                aux.Imagen = new List<Imagen>();
                foreach (ImagenDto imagen in ecosistemaMarino.Imagen)
                {
                    Imagen imagen1 = new Imagen();
                    imagen1.Valor = imagen.Valor;
                    aux.Imagen.Add(imagen1);
                }
            }
            if (ecosistemaMarino.EspeciesHabitan != null)
            {
                aux.EspeciesHabitan = new List<EspecieMarina>();
                foreach (EspecieMarinaDto especieMarinaDto in ecosistemaMarino.EspeciesHabitan)
                {
                    EspecieMarina especieMarina = new EspecieMarina();
                    especieMarina.Descripcion = especieMarinaDto.Descripcion;
                    especieMarina.EstadoConservacionId = especieMarinaDto.EstadoConservacionId;
                    especieMarina.Longitud = especieMarinaDto.Longitud;
                    especieMarina.Descripcion = especieMarinaDto.Descripcion;
                    especieMarina.NombreCientifico = especieMarinaDto.NombreCientifico;
                    especieMarina.NombreVulgar = especieMarinaDto.NombreVulgar;
                    especieMarina.Peso = especieMarinaDto.Peso;

                }
            }
            if (ecosistemaMarino.Amenazas != null)
            {
                aux.Amenazas = new List<AmenazasAsociadas>();
                foreach (AmenazasAsociadasDto amenazasAsociadasDto in ecosistemaMarino.Amenazas)
                {
                    AmenazasAsociadas amenazasAsociadas = new AmenazasAsociadas();
                    amenazasAsociadas.AmenazaId = amenazasAsociadasDto.AmenazaId;
                    amenazasAsociadas.EspecieMarinaId = amenazasAsociadasDto.EspecieMarinaId;
                    amenazasAsociadas.EcosistemaMarinoId = amenazasAsociadasDto.EcosistemaMarinoId;
                    aux.Amenazas.Add(amenazasAsociadas);
                }
            }
            aux.EstadoConservacionId = ecosistemaMarino.EstadoConservacionId;
            aux.PaisId = ecosistemaMarino.PaisId;

            _repositorioEcosistemaMarino.Update(aux);
            Auditoria(usuarioLogueado, aux.Id);
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
