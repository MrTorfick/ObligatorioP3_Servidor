using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using EcosistemasMarinos.ValueObjects;
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

        public EcosistemaMarinoDto AddEcosistemaMarino(EcosistemaMarinoDto ecosistemaMarino, string usuarioLogueado)
        {
            EcosistemaMarino aux = new EcosistemaMarino();
            aux.Id = 0;
            aux.Nombre = ecosistemaMarino.Nombre;
            aux.Area = ecosistemaMarino.Area;
            aux.Coordenadas = new Coordenadas(ecosistemaMarino.Coordenadas.Longitud, ecosistemaMarino.Coordenadas.Latitud);
            aux.Area = ecosistemaMarino.Area;
            aux.DescripcionCaracteristicas= ecosistemaMarino.DescripcionCaracteristicas;
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
            aux.EstadoConservacionId = 1;
            aux.PaisId = 1;
            repositorioEcosistemaMarino.Add(aux);
            Auditoria(usuarioLogueado, aux.Id);
            return new EcosistemaMarinoDto(aux);
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
