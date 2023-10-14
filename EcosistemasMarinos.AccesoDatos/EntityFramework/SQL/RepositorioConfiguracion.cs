using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL
{
    public class RepositorioConfiguracion : IRepositorioConfiguracion
    {
        private EMContext _context;

        public RepositorioConfiguracion()
        {
            this._context = new EMContext();
        }

        public void Add(Configuracion unDato)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Configuracion> FindAll()
        {
            return _context.Configuracion;
        }

        public Configuracion FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public Configuracion FindByName(string nombreAtributo)
        {
            return _context.Configuracion.Where(config => config.NombreAtributo == nombreAtributo).FirstOrDefault();
        }

        public int GetTopeInferior(string nombreAtributo)
        {
            Configuracion configuracion = _context.Configuracion.Where(config => config.NombreAtributo == nombreAtributo).FirstOrDefault();
            if (configuracion == null) throw new Exception("El Nombre del atributo configuracion es incorrecto");
            return configuracion.topeInferior;
        }

        public int GetTopeSuperior(string nombreAtributo)
        {
            Configuracion configuracion = _context.Configuracion.Where(config => config.NombreAtributo == nombreAtributo).FirstOrDefault();
            if (configuracion == null) throw new Exception("El Nombre del atributo configuracion es incorrecto");
            return configuracion.topeSuperior;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Configuracion dato)
        {
            try
            {
                dato.Validar();
                this._context.Configuracion.Update(dato);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al actualizar la configuracion: " + ex.Message);
            }
        }
    }
}
