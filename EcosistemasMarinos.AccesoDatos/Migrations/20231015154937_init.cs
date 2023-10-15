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
                    nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codigoISO = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => new { x.nombre, x.codigoISO });
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
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
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "EcosistemaMarinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordenadas_Longitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordenadas_Latitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    DescripcionCaracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paisnombre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    paiscodigoISO = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EstadoConservacionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaMarinos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcosistemaMarinos_EstadoConservacion_EstadoConservacionId",
                        column: x => x.EstadoConservacionId,
                        principalTable: "EstadoConservacion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EcosistemaMarinos_Pais_paisnombre_paiscodigoISO",
                        columns: x => new { x.paisnombre, x.paiscodigoISO },
                        principalTable: "Pais",
                        principalColumns: new[] { "nombre", "codigoISO" });
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
                        name: "FK_AmenazasAsociadas_EcosistemaMarinos_EcosistemaMarinoId",
                        column: x => x.EcosistemaMarinoId,
                        principalTable: "EcosistemaMarinos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AmenazasAsociadas_EspecieMarina_EspecieMarinaId",
                        column: x => x.EspecieMarinaId,
                        principalTable: "EspecieMarina",
                        principalColumn: "Id");
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
                        name: "FK_EspeciesHabitab_EcosistemaMarinos_EcosistemaMarinoId",
                        column: x => x.EcosistemaMarinoId,
                        principalTable: "EcosistemaMarinos",
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
                name: "IX_EcosistemaMarinos_EstadoConservacionId",
                table: "EcosistemaMarinos",
                column: "EstadoConservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaMarinos_paisnombre_paiscodigoISO",
                table: "EcosistemaMarinos",
                columns: new[] { "paisnombre", "paiscodigoISO" });

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
                name: "IX_Usuarios_Nombre",
                table: "Usuarios",
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
                name: "EspeciesHabitab");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "EcosistemaMarinos");

            migrationBuilder.DropTable(
                name: "EspecieMarina");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "EstadoConservacion");
        }
    }
}
