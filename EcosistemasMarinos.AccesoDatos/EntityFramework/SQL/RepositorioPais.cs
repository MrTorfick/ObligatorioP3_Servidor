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

        public RepositorioPais()
        {
            _context = new EMContext();
        }

        public void Add(Country unDato)
        {
            try
            {
                unDato.Validar();
                Country country = FindByIso(unDato.codigoISO);
                if (country == null)
                {
                    _context.Pais.Add(unDato);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el Pais: " + ex.Message);
            }
        }

        public IEnumerable<Country> FindAll()
        {
            return _context.Pais;
        }

        public Country FindByIso(string codigoISO)
        {
            return _context.Pais.Where(p => p.codigoISO == codigoISO).FirstOrDefault();
        }
        public Country FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Country dato)
        {
            throw new NotImplementedException();
        }

        public Country FindByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
