using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
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

        public RepositorioEcosistemaMarino()
        {
            _context = new EMContext();
        }

        public void Add(EcosistemaMarino unDato)
        {
            unDato.Validar();
            _context.EcosistemaMarinos.Add(unDato);
            _context.SaveChanges();
        }

        public IEnumerable<EcosistemaMarino> FindAll()
        {
            throw new NotImplementedException();
        }

        public EcosistemaMarino FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(EcosistemaMarino dato)
        {
            throw new NotImplementedException();
        }
    }
}
