using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private EMContext _context;

        public RepositorioUsuario() { 
        
            _context= new EMContext();
        }

        public void Add(Usuario usuario)
        {
            usuario.Validar();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> FindAll()
        {
            return _context.Usuarios.OrderByDescending(Usuario => Usuario.Id);
        }
        public Usuario FindUserByCredentials(string name, string password)
        {
            return _context.Usuarios.Where(usuario => usuario.Nombre == name && usuario.Contrasenia == password).FirstOrDefault();
        }

        public Usuario FindByID(int id)
        {
            throw new NotImplementedException();
            
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario dato)
        {
            throw new NotImplementedException();
        }

       
    }
}
