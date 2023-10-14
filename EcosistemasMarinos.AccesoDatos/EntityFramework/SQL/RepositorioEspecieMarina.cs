using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL
{
    public class RepositorioEspecieMarina : IRepositorioEspecieMarina
    {
        private EMContext _context;
        private IRepositorioConfiguracion config;

        public RepositorioEspecieMarina(IRepositorioConfiguracion config)
        {
            _context = new EMContext();
            this.config = config;
        }

        /*
         
         var ecosistemas = db.EspeciesMarinas.Find(id).EspeciesHabitab.Select(eh => eh.EcosistemaMarino);

         */
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

                throw new Exception("Error al agregar la Especie Marina" + ex);
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
