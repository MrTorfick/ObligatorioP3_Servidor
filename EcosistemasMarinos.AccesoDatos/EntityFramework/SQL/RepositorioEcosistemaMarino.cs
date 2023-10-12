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
                foreach (Amenaza amenaza in unDato.Amenazas)
                {
                    _context.Entry(amenaza).State = EntityState.Unchanged;
                }
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
