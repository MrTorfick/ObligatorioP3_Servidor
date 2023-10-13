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
        public DbSet<EcosistemaMarino> EcosistemaMarinos { get; set; }
        public DbSet<EspecieMarina> EspecieMarina { get; set; }
        public DbSet<Amenaza> Amenaza { get; set; }
        public DbSet<EstadoConservacion> EstadoConservacion { get; set; }
        public DbSet<Configuracion> Configuracion { get; set; }
        public DbSet<EspeciesHabitab> EspeciesHabitab { get; set; }
        public DbSet<AmenazasAsociadas> AmenazasAsociadas { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EspecieMarina>()
                .HasMany(e => e.EcosistemaMarinos)
                .WithMany(e => e.EspeciesHabitan)
                .UsingEntity<EspeciesHabitab>();

            /*
            modelBuilder.Entity<EspecieMarina>()
              .HasMany(e => e.EcosistemaMarinosViven)
              .WithMany(e => e.EspeciesHabitan)
              .UsingEntity<Dictionary<string, string>>(
                  "Especies_Habitan",
                  EcosistemaMarino => EcosistemaMarino.HasOne<EcosistemaMarino>().WithMany().OnDelete(DeleteBehavior.Restrict),
                  EspecieMarina => EspecieMarina.HasOne<EspecieMarina>().WithMany().OnDelete(DeleteBehavior.Restrict)
            */
        }

    }
}
