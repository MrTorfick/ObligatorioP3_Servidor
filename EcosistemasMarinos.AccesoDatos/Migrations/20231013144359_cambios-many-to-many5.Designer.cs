﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _EcosistemasMarinos.AccesoDatos.EntityFramework;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    [DbContext(typeof(EMContext))]
    [Migration("20231013144359_cambios-many-to-many5")]
    partial class cambiosmanytomany5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcosistemasMarinos.Entidades.Amenaza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EcosistemaMarinoId")
                        .HasColumnType("int");

                    b.Property<int?>("EspecieMarinaId")
                        .HasColumnType("int");

                    b.Property<int>("Peligrosidad")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EcosistemaMarinoId");

                    b.HasIndex("EspecieMarinaId");

                    b.ToTable("Amenaza");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.Configuracion", b =>
                {
                    b.Property<string>("NombreAtributo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("topeInferior")
                        .HasColumnType("int");

                    b.Property<int>("topeSuperior")
                        .HasColumnType("int");

                    b.HasKey("NombreAtributo");

                    b.ToTable("Configuracion");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EcosistemaMarino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<string>("DescripcionCaracteristicas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoConservacionId")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paiscodigoISO")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("paisnombre")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoConservacionId");

                    b.HasIndex("paisnombre", "paiscodigoISO");

                    b.ToTable("EcosistemaMarinos");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EspecieMarina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Longitud")
                        .HasColumnType("float");

                    b.Property<string>("NombreCientifico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreVulgar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("EspecieMarina");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EspeciesHabitab", b =>
                {
                    b.Property<int>("EcosistemaMarinoId")
                        .HasColumnType("int");

                    b.Property<int>("EspecieMarinaId")
                        .HasColumnType("int");

                    b.Property<bool>("Habita")
                        .HasColumnType("bit");

                    b.HasKey("EcosistemaMarinoId", "EspecieMarinaId");

                    b.HasIndex("EspecieMarinaId");

                    b.ToTable("EspeciesHabitab");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EstadoConservacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("EstadoConservacion");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.Pais", b =>
                {
                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("codigoISO")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("nombre", "codigoISO");

                    b.HasIndex("codigoISO")
                        .IsUnique();

                    b.HasIndex("nombre")
                        .IsUnique();

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.Amenaza", b =>
                {
                    b.HasOne("EcosistemasMarinos.Entidades.EcosistemaMarino", "ecosistemaMarino")
                        .WithMany("Amenazas")
                        .HasForeignKey("EcosistemaMarinoId");

                    b.HasOne("EcosistemasMarinos.Entidades.EspecieMarina", "especieMarina")
                        .WithMany("Amenazas")
                        .HasForeignKey("EspecieMarinaId");

                    b.Navigation("ecosistemaMarino");

                    b.Navigation("especieMarina");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EcosistemaMarino", b =>
                {
                    b.HasOne("EcosistemasMarinos.Entidades.EstadoConservacion", "EstadoConservacion")
                        .WithMany()
                        .HasForeignKey("EstadoConservacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcosistemasMarinos.Entidades.Pais", "pais")
                        .WithMany()
                        .HasForeignKey("paisnombre", "paiscodigoISO");

                    b.OwnsOne("EcosistemasMarinos.ValueObjects.Coordenadas", "Coordenadas", b1 =>
                        {
                            b1.Property<int>("EcosistemaMarinoId")
                                .HasColumnType("int");

                            b1.Property<string>("Latitud")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Longitud")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EcosistemaMarinoId");

                            b1.ToTable("EcosistemaMarinos");

                            b1.WithOwner()
                                .HasForeignKey("EcosistemaMarinoId");
                        });

                    b.Navigation("Coordenadas")
                        .IsRequired();

                    b.Navigation("EstadoConservacion");

                    b.Navigation("pais");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EspeciesHabitab", b =>
                {
                    b.HasOne("EcosistemasMarinos.Entidades.EcosistemaMarino", null)
                        .WithMany()
                        .HasForeignKey("EcosistemaMarinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcosistemasMarinos.Entidades.EspecieMarina", null)
                        .WithMany()
                        .HasForeignKey("EspecieMarinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EstadoConservacion", b =>
                {
                    b.OwnsOne("EcosistemasMarinos.ValueObjects.Rangos", "Rangos", b1 =>
                        {
                            b1.Property<int>("EstadoConservacionId")
                                .HasColumnType("int");

                            b1.Property<int>("Maximo")
                                .HasColumnType("int");

                            b1.Property<int>("Minimo")
                                .HasColumnType("int");

                            b1.HasKey("EstadoConservacionId");

                            b1.ToTable("EstadoConservacion");

                            b1.WithOwner()
                                .HasForeignKey("EstadoConservacionId");
                        });

                    b.Navigation("Rangos")
                        .IsRequired();
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EcosistemaMarino", b =>
                {
                    b.Navigation("Amenazas");
                });

            modelBuilder.Entity("EcosistemasMarinos.Entidades.EspecieMarina", b =>
                {
                    b.Navigation("Amenazas");
                });
#pragma warning restore 612, 618
        }
    }
}
