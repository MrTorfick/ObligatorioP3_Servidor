using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL
{
    public class RepositorioEstadoConservacion : IRepositorioEstadoConservacion
    {

        private EMContext _context;

        public RepositorioEstadoConservacion()
        {
            _context = new EMContext();
        }
        public void Add(EstadoConservacion unDato)
        {
            unDato.Validar();
            _context.EstadoConservacion.Add(unDato);
            _context.SaveChanges();
        }

        public IEnumerable<EstadoConservacion> FindAll()
        {
            if (_context.EstadoConservacion.Count() == 0)
            {
                return null;
            }
            else
            {
                return _context.EstadoConservacion;
            }

        }

        public EstadoConservacion FindByID(int id)
        {
            try
            {
                return _context.EstadoConservacion.Where(EstadoConservacion => EstadoConservacion.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al buscar el Estado de Conservacion: " + ex);
            }


        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(EstadoConservacion dato)
        {
            throw new NotImplementedException();
        }
    }
}
