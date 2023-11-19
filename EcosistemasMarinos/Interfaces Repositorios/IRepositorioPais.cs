using EcosistemasMarinos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Interfaces_Repositorios
{
    public interface IRepositorioPais:IRepositorio<Country>
    {
        public Country FindByIso(string codigoISO);
    }
}
