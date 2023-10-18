using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenaza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peligrosidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenaza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configuracion",
                columns: table => new
                {
                    NombreAtributo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    topeSuperior = table.Column<int>(type: "int", nullable: false),
                    topeInferior = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracion", x => x.NombreAtributo);
                });

            migrationBuilder.CreateTable(
                name: "EstadoConservacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rangos_Minimo = table.Column<int>(type: "int", nullable: false),
                    Rangos_Maximo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoConservacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    PaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codigoISO = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContraseniaEncriptada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EspecieMarina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCientifico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreVulgar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen_Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    EstadoConservacionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecieMarina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EspecieMarina_EstadoConservacion_EstadoConservacionId",
                        column: x => x.EstadoConservacionId,
                        principalTable: "EstadoConservacion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EcosistemaMarino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordenadas_Longitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordenadas_Latitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    DescripcionCaracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    EstadoConservacionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaMarino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcosistemaMarino_EstadoConservacion_EstadoConservacionId",
                        column: x => x.EstadoConservacionId,
                        principalTable: "EstadoConservacion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EcosistemaMarino_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmenazasAsociadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmenazaId = table.Column<int>(type: "int", nullable: false),
                    EcosistemaMarinoId = table.Column<int>(type: "int", nullable: true),
                    EspecieMarinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenazasAsociadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmenazasAsociadas_EcosistemaMarino_EcosistemaMarinoId",
                        column: x => x.EcosistemaMarinoId,
                        principalTable: "EcosistemaMarino",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AmenazasAsociadas_EspecieMarina_EspecieMarinaId",
                        column: x => x.EspecieMarinaId,
                        principalTable: "EspecieMarina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EcosistemaMarino_Imagen",
                columns: table => new
                {
                    EcosistemaMarinoId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaMarino_Imagen", x => new { x.EcosistemaMarinoId, x.Id });
                    table.ForeignKey(
                        name: "FK_EcosistemaMarino_Imagen_EcosistemaMarino_EcosistemaMarinoId",
                        column: x => x.EcosistemaMarinoId,
                        principalTable: "EcosistemaMarino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EspeciesHabitab",
                columns: table => new
                {
                    EcosistemaMarinoId = table.Column<int>(type: "int", nullable: false),
                    EspecieMarinaId = table.Column<int>(type: "int", nullable: false),
                    Habita = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspeciesHabitab", x => new { x.EcosistemaMarinoId, x.EspecieMarinaId });
                    table.ForeignKey(
                        name: "FK_EspeciesHabitab_EcosistemaMarino_EcosistemaMarinoId",
                        column: x => x.EcosistemaMarinoId,
                        principalTable: "EcosistemaMarino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspeciesHabitab_EspecieMarina_EspecieMarinaId",
                        column: x => x.EspecieMarinaId,
                        principalTable: "EspecieMarina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmenazasAsociadas_EcosistemaMarinoId",
                table: "AmenazasAsociadas",
                column: "EcosistemaMarinoId");

            migrationBuilder.CreateIndex(
                name: "IX_AmenazasAsociadas_EspecieMarinaId",
                table: "AmenazasAsociadas",
                column: "EspecieMarinaId");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaMarino_EstadoConservacionId",
                table: "EcosistemaMarino",
                column: "EstadoConservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaMarino_PaisId",
                table: "EcosistemaMarino",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecieMarina_EstadoConservacionId",
                table: "EspecieMarina",
                column: "EstadoConservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EspeciesHabitab_EspecieMarinaId",
                table: "EspeciesHabitab",
                column: "EspecieMarinaId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoConservacion_Nombre",
                table: "EstadoConservacion",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pais_codigoISO",
                table: "Pais",
                column: "codigoISO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pais_nombre",
                table: "Pais",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Nombre",
                table: "Usuario",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenaza");

            migrationBuilder.DropTable(
                name: "AmenazasAsociadas");

            migrationBuilder.DropTable(
                name: "Configuracion");

            migrationBuilder.DropTable(
                name: "EcosistemaMarino_Imagen");

            migrationBuilder.DropTable(
                name: "EspeciesHabitab");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "EcosistemaMarino");

            migrationBuilder.DropTable(
                name: "EspecieMarina");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "EstadoConservacion");
        }
    }
}
