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

        public RepositorioUsuario()
        {

            _context = new EMContext();
        }

        public void Add(Usuario usuario)
        {
            try
            {
                usuario.Validar();
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar el usuario: " + ex.Message);
            }

        }

        public IEnumerable<Usuario> FindAll()
        {
            return _context.Usuario.OrderByDescending(Usuario => Usuario.Id);
        }
        public Usuario FindUserByCredentials(string name, string password)
        {
            try
            {
                return _context.Usuario.Where(usuario => usuario.Nombre == name && usuario.Contrasenia == password).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al buscar el usuario: " + ex);
            }

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
