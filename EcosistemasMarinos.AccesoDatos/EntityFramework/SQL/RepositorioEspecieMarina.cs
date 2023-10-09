﻿using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL
{
    public class RepositorioEspecieMarina : IRepositorioEspecieMarina
    {
        private EMContext _context;

        public RepositorioEspecieMarina()
        {
            _context = new EMContext();
        }
        public void Add(EspecieMarina unDato)
        {
            unDato.Validar();
            _context.EspecieMarina.Add(unDato);
            _context.SaveChanges();
        }

        public IEnumerable<EspecieMarina> FindAll()
        {
            return _context.EspecieMarina;
        }

        public EspecieMarina FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(EspecieMarina dato)
        {
            throw new NotImplementedException();
        }
    }
}
