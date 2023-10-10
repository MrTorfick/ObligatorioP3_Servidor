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

        public RepositorioEcosistemaMarino()
        {
            _context = new EMContext();
        }

        public void Add(EcosistemaMarino unDato)
        {
            try
            {
                unDato.Validar();
                _context.EcosistemaMarinos.Add(unDato);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar el Ecosistema Marino" + unDato.Nombre);
            }

        }

        public IEnumerable<EcosistemaMarino> FindAll()
        {
            return _context.EcosistemaMarinos;
        }

        public EcosistemaMarino FindByID(int id)
        {
            return _context.EcosistemaMarinos.Where(EcosistemaMarino => EcosistemaMarino.Id == id).FirstOrDefault();
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
