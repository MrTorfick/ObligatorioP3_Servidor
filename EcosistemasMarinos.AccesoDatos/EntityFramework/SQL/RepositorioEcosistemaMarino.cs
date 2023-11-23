using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using EcosistemasMarinos.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL
{
    public class RepositorioEcosistemaMarino : IRepositorioEcosistemaMarino

    {
        private EMContext _context;
        private IRepositorioConfiguracion config;

        public RepositorioEcosistemaMarino(IRepositorioConfiguracion config)
        {
            _context = new EMContext();
            this.config = config;
        }

        public void Add(EcosistemaMarino unDato)
        {
            try
            {
                unDato.Validar(config);
                _context.EcosistemaMarino.Add(unDato);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el Ecosistema Marino: " + ex.Message);
            }

        }

        public IEnumerable<EcosistemaMarino> FindAll()
        {
            return _context.EcosistemaMarino.Include(nameof(Imagen));
        }

        public EcosistemaMarino FindByID(int id)
        {
            try
            {
                var amenazas = _context.AmenazasAsociadas.Where(amenaza => amenaza.EcosistemaMarinoId == id && amenaza.EspecieMarinaId == null).ToList();
                EcosistemaMarino ecosistemaMarino = _context.EcosistemaMarino.Where(EcosistemaMarino => EcosistemaMarino.Id == id).Include(nameof(EstadoConservacion)).FirstOrDefault();
                ecosistemaMarino.Amenazas = amenazas;
                return ecosistemaMarino;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al buscar el Ecosistema Marino: " + ex.Message);
            }

        }

        public void Remove(int id)
        {
            try
            {
                var especiesHabitan = _context.EspeciesHabitab.Where(especie => especie.EcosistemaMarinoId == id && especie.Habita == true).ToList();
                if (especiesHabitan.Count > 0)
                {
                    throw new Exception("No se puede eliminar el ecosistema marino porque tiene especies que habitan en él");
                }
                var especiesNoHabitan = _context.EspeciesHabitab.Where(especie => especie.EcosistemaMarinoId == id && especie.Habita == false).ToList();
                var amenazasAsignadas = _context.AmenazasAsociadas.Where(amenaza => amenaza.EcosistemaMarinoId == id).ToList();
                foreach (EspeciesHabitab especie in especiesNoHabitan)
                {
                    _context.EspeciesHabitab.Remove(especie);

                }

                foreach (AmenazasAsociadas amenaza in amenazasAsignadas)
                {
                    _context.AmenazasAsociadas.Remove(amenaza);
                }


                EcosistemaMarino ecosistemaMarino = new EcosistemaMarino();
                ecosistemaMarino = FindByID(id);
                //ecosistemaMarino.Id = id;
                _context.EcosistemaMarino.Remove(ecosistemaMarino);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                string test = ex.GetType().Name;
                throw new Exception("Error al borrar el Ecosistema Marino: " + ex.Message);
            }
        }

        public void Update(EcosistemaMarino dato)
        {
            try
            {
                dato.Validar(config);
                this._context.EcosistemaMarino.Update(dato);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al actualizar el Ecosistema Marino: " + ex.Message);
            }
        }
    }
}
