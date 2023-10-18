using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL
{
    public class RepositorioPais : IRepositorioPais
    {

        private EMContext _context;

        public void Add(Pais unDato)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> FindAll()
        {
            return _context.Pais;
        }

        public Pais FindByID(int id)
        {
            return _context.Pais.Where(p => p.PaisId == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pais dato)
        {
            throw new NotImplementedException();
        }
    }
}
