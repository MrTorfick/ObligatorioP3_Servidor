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
            throw new NotImplementedException();
        }

        public EstadoConservacion FindByID(int id)
        {
            throw new NotImplementedException();
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
