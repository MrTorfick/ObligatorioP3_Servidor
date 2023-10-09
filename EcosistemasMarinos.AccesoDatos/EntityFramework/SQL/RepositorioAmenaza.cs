using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL
{
    public class RepositorioAmenaza : IRepositorioAmenaza
    {

        private EMContext _context;

        public RepositorioAmenaza()
        {
            _context = new EMContext();
        }
        public void Add(Amenaza unDato)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Amenaza> FindAll()
        {
            return _context.Amenaza;
        }

        public Amenaza FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Amenaza dato)
        {
            throw new NotImplementedException();
        }
    }
}
