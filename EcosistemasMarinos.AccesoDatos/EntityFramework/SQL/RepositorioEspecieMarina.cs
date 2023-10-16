using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL
{
    public class RepositorioEspecieMarina : IRepositorioEspecieMarina
    {
        private EMContext _context;
        private IRepositorioConfiguracion config;
        private IRepositorioEcosistemaMarino repositorioEcosistemaMarino;
        public RepositorioEspecieMarina(IRepositorioConfiguracion config, IRepositorioEcosistemaMarino repositorioEcosistemaMarino)
        {
            _context = new EMContext();
            this.config = config;
            this.repositorioEcosistemaMarino = repositorioEcosistemaMarino;
        }

        public void Add(EspecieMarina unDato)
        {

            try
            {
                unDato.Validar(config);
                foreach (EcosistemaMarino ecosistemaMarino in unDato.EcosistemaMarinos)
                {
                    _context.Entry(ecosistemaMarino).State = EntityState.Unchanged;//Marca la entidad como Unchanged. No se modifica ni se inserta en la base de datos
                }

                _context.EspecieMarina.Add(unDato);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar la Especie Marina: " + ex.Message);
            }

        }

        public void AsociarEspecieAEcosistema(int idEspecie, int idEcosistema)
        {
            try
            {
                EspeciesHabitab especiesHabitab = new EspeciesHabitab();
                especiesHabitab = _context.EspeciesHabitab.Where(eh => eh.EcosistemaMarinoId == idEcosistema && eh.EspecieMarinaId == idEspecie).FirstOrDefault();

                if (especiesHabitab != null)
                {
                    especiesHabitab.Habita = true;
                    _context.EspeciesHabitab.Update(especiesHabitab);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al asociar la especie al ecosistema" + ex);
            }
        }

        public IEnumerable<EspecieMarina> FindAll()
        {
            return _context.EspecieMarina;
        }

        public EspecieMarina FindByID(int id)
        {
            return _context.EspecieMarina.Where(em => em.Id == id).Include(em => em.EcosistemaMarinos).FirstOrDefault();
        }

        public IEnumerable<EcosistemaMarino> GetEcosistemaMarinosNoPuedenHabitarEspecies(int idEspecie)
        {
            var especie = FindByID(idEspecie);
            var amenazasEspecie = _context.AmenazasAsociadas.Where(aa => aa.EspecieMarinaId == idEspecie).ToList();
            List<EcosistemaMarino> ecosistemaMarinos = new List<EcosistemaMarino>();
            foreach (AmenazasAsociadas item in amenazasEspecie)
            {
                var amenazasEcosistema = _context.AmenazasAsociadas.Where(aa => aa.AmenazaId == item.AmenazaId && aa.EspecieMarinaId == null).FirstOrDefault();
                EcosistemaMarino ecosistemaMarino = repositorioEcosistemaMarino.FindByID((int)amenazasEcosistema.EcosistemaMarinoId);
                if (!ecosistemaMarinos.Contains(ecosistemaMarino))
                {
                    ecosistemaMarinos.Add(ecosistemaMarino);
                }
            }
            return ecosistemaMarinos;

        }

        public IEnumerable<EspecieMarina> GetEspecieHabitanEcosistema(int idEcosistema)
        {
            List<EspecieMarina> especieMarinas = new List<EspecieMarina>();
            var especiesHabitab = _context.EspeciesHabitab.Where(eh => eh.EcosistemaMarinoId == idEcosistema && eh.Habita == true).ToList();
            foreach (EspeciesHabitab item in especiesHabitab)
            {
                especieMarinas.Add(_context.EspecieMarina.Where(em => em.Id == item.EspecieMarinaId).FirstOrDefault());
            }

            return especieMarinas;
        }


        public IEnumerable<EspecieMarina> GetEspecieMarinaEnPeligroDeExtincion()
        {

            var ecosistemasMarinos = repositorioEcosistemaMarino.FindAll();
            List<EcosistemaMarino> ecosistemaMarinos = new List<EcosistemaMarino>();

            return _context.EspecieMarina.
                 Where(em => em.EstadoConservacion.Rangos.Minimo < 60 || em.Amenazas.Count > 3)
                 .ToList();
        }

        public EspecieMarina GetEspecieMarinaPorNombreCientifico(string nombre)
        {
            return _context.EspecieMarina.Where(em => em.NombreCientifico == nombre).FirstOrDefault();
        }

        public IEnumerable<EspecieMarina> GetEspecieMarinasPeso(double desde, double hasta)
        {
            return _context.EspecieMarina.Where(em => em.Peso >= desde && em.Peso <= hasta).ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(EspecieMarina dato)
        {
            throw new NotImplementedException();
        }
    }
}
