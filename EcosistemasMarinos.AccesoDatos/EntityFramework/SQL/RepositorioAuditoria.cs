using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL
{
    public class RepositorioAuditoria : IRepositorioAuditoria
    {

        private EMContext _context;

        public RepositorioAuditoria()
        {
            _context = new EMContext();
        }

        public void Add(Auditoria unDato)
        {
            try
            {
                unDato.Validar();
                _context.Auditoria.Add(unDato);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error en la Auditoria: " + ex.Message);
            }


        }

        public IEnumerable<Auditoria> FindAll()
        {
            throw new NotImplementedException();
        }

        public Auditoria FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Auditoria dato)
        {
            throw new NotImplementedException();
        }
    }
}
