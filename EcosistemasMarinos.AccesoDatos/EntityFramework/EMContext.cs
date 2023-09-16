using EcosistemasMarinos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.AccesoDatos.EntityFramework
{
    public class EMContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cadenaConexion =
                @"SERVER=(localdb)\MSsqlLocaldb;
                DATABASE=EM-v1;
                INTEGRATED SECURITY=TRUE;
                ENCRYPT=False"; //Puede evitar problemas si no hay un certificado y se usa SSL
            optionsBuilder.UseSqlServer(cadenaConexion)
            .EnableDetailedErrors();
        }


    }
}
