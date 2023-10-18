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
                /*
                foreach (AmenazasAsociadas amenaza in unDato.Amenazas)
                {
                    _context.Entry(amenaza).State = EntityState.Unchanged;
                }
                */
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
            return _context.EcosistemaMarino;
        }

        public EcosistemaMarino FindByID(int id)
        {
            try
            {
                return _context.EcosistemaMarino.Where(EcosistemaMarino => EcosistemaMarino.Id == id).FirstOrDefault();
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
                //Creo que cuando las trae, les esta asignado false. Hay que verificar eso
                //TODO
                var especiesNoHabitan = _context.EspeciesHabitab.Where(especie => especie.EcosistemaMarinoId == id && especie.Habita == false).ToList();
                var amenazasAsignadas = _context.AmenazasAsociadas.Where(amenaza => amenaza.EcosistemaMarinoId == id).ToList();
                foreach (EspeciesHabitab especie in especiesNoHabitan)
                {
                    _context.EspeciesHabitab.Remove(especie);//Se eliminan de la tabla de EspeciesHabitad, las foreign key de las especies(que no habitan) que
                                                             //hacen referencia al habitad que se va a borrar

                }

                foreach (AmenazasAsociadas amenaza in amenazasAsignadas)
                {
                    _context.AmenazasAsociadas.Remove(amenaza);
                }


                EcosistemaMarino ecosistemaMarino = new EcosistemaMarino();
                ecosistemaMarino.Id = id;
                this._context.EcosistemaMarino.Remove(ecosistemaMarino);
                this._context.SaveChanges();


                _context.SaveChanges();
            }
            catch (Exception ex)
            {
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
