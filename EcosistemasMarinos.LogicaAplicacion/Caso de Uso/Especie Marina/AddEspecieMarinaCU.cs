using _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL;
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
    public class AddEspecieMarinaCU : IAddEspecieMarina
    {
        private IRepositorioEspecieMarina _repositorioEspecieMarina;
        private IRepositorioAuditoria _repositorioAuditoria;

        public AddEspecieMarinaCU(IRepositorioEspecieMarina repositorioEspecieMarina, IRepositorioAuditoria repositorioAuditoria)
        {
            this._repositorioEspecieMarina = repositorioEspecieMarina;
            this._repositorioAuditoria = repositorioAuditoria;
        }


        public EspecieMarinaDto AddEspecieMarina(EspecieMarinaDto especieMarina, string usuarioLogueado)
        {
            EspecieMarina aux = new EspecieMarina();
            aux.Id = 0;
            aux.NombreCientifico = especieMarina.NombreCientifico;
            aux.NombreVulgar = especieMarina.NombreVulgar;
            aux.Descripcion = especieMarina.Descripcion;
            if (especieMarina.Imagen != null)
            {
                aux.Imagen = new List<Imagen>();
                foreach (ImagenDto imagen in especieMarina.Imagen)
                {
                    Imagen imagen1 = new Imagen();
                    imagen1.Valor = imagen.Valor;
                    aux.Imagen.Add(imagen1);
                }
            }
            aux.Peso = especieMarina.Peso;
            aux.Longitud = especieMarina.Longitud;

            if (especieMarina.EcosistemaMarinos != null)
            {
                aux.EcosistemaMarinos = new List<EcosistemaMarino>();
                foreach (EcosistemaMarinoDto ecosistemaMarinoDto in especieMarina.EcosistemaMarinos)
                {
                    EcosistemaMarino ecosistemaMarino = new EcosistemaMarino();
                    ecosistemaMarino.Nombre = ecosistemaMarinoDto.Nombre;
                    ecosistemaMarino.Area = ecosistemaMarinoDto.Area;
                    ecosistemaMarino.DescripcionCaracteristicas = ecosistemaMarinoDto.DescripcionCaracteristicas;
                    ecosistemaMarino.Id = ecosistemaMarinoDto.Id;
                    ecosistemaMarino.Coordenadas = new Coordenadas(ecosistemaMarinoDto.Coordenadas.Longitud, ecosistemaMarinoDto.Coordenadas.Latitud);
                    ecosistemaMarino.Imagen = new List<Imagen>();
                    ecosistemaMarino.Amenazas = new List<AmenazasAsociadas>();
                    ecosistemaMarino.EspeciesHabitan = new List<EspecieMarina>();
                    aux.EcosistemaMarinos.Add(ecosistemaMarino);
                }
            }

            if (especieMarina.Amenazas != null)
            {
                aux.Amenazas = new List<AmenazasAsociadas>();
                foreach (AmenazasAsociadasDto amenazasAsociadasDto in especieMarina.Amenazas)
                {
                    AmenazasAsociadas amenazasAsociadas = new AmenazasAsociadas();
                    amenazasAsociadas.AmenazaId = amenazasAsociadasDto.AmenazaId;
                    amenazasAsociadas.EspecieMarinaId = amenazasAsociadasDto.EspecieMarinaId;
                    amenazasAsociadas.EcosistemaMarinoId = amenazasAsociadasDto.EcosistemaMarinoId;
                    aux.Amenazas.Add(amenazasAsociadas);
                }
            }
            aux.EstadoConservacionId = especieMarina.EstadoConservacionId;

            _repositorioEspecieMarina.Add(aux);
            Auditoria(usuarioLogueado, aux.Id);
            EspecieMarinaDto retornar = new EspecieMarinaDto(aux);
            return retornar;
        }

        private void Auditoria(string UsuarioLogueado, int idEntidad)
        {
            Auditoria auditoria = new Auditoria();
            auditoria.NombreUsuario = UsuarioLogueado;
            auditoria.Fecha = DateTime.Now;
            auditoria.IdEntidad = idEntidad;
            auditoria.TipoEntidad = "Agregar especie marina";
            _repositorioAuditoria.Add(auditoria);
        }
    }
}
