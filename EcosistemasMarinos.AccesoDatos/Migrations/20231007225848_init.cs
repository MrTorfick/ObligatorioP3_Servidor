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
                    Descripcion = table.Column<int>(type: "int", maxLength: 500, nullable: false),
                    Peligrosidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenaza", x => x.Id);
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
                    Longitud = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecieMarina", x => x.Id);
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
                name: "EcosistemaMarinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Coordenadas_Longitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordenadas_Latitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    DescripcionCaracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAmenaza = table.Column<int>(type: "int", nullable: false),
                    Paisnombre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaiscodigoISO = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EstadoConservacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaMarinos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcosistemaMarinos_Amenaza_IdAmenaza",
                        column: x => x.IdAmenaza,
                        principalTable: "Amenaza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EcosistemaMarinos_Pais_Paisnombre_PaiscodigoISO",
                        columns: x => new { x.Paisnombre, x.PaiscodigoISO },
                        principalTable: "Pais",
                        principalColumns: new[] { "nombre", "codigoISO" });
                });

            migrationBuilder.CreateTable(
                name: "EcosistemaMarinoEspecieMarina",
                columns: table => new
                {
                    EcosistemasMarinosVidaPosibleId = table.Column<int>(type: "int", nullable: false),
                    EspeciesHabitanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaMarinoEspecieMarina", x => new { x.EcosistemasMarinosVidaPosibleId, x.EspeciesHabitanId });
                    table.ForeignKey(
                        name: "FK_EcosistemaMarinoEspecieMarina_EcosistemaMarinos_EcosistemasMarinosVidaPosibleId",
                        column: x => x.EcosistemasMarinosVidaPosibleId,
                        principalTable: "EcosistemaMarinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EcosistemaMarinoEspecieMarina_EspecieMarina_EspeciesHabitanId",
                        column: x => x.EspeciesHabitanId,
                        principalTable: "EspecieMarina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaMarinoEspecieMarina_EspeciesHabitanId",
                table: "EcosistemaMarinoEspecieMarina",
                column: "EspeciesHabitanId");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaMarinos_IdAmenaza",
                table: "EcosistemaMarinos",
                column: "IdAmenaza");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaMarinos_Paisnombre_PaiscodigoISO",
                table: "EcosistemaMarinos",
                columns: new[] { "Paisnombre", "PaiscodigoISO" });

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
                name: "EcosistemaMarinoEspecieMarina");

            migrationBuilder.DropTable(
                name: "EstadoConservacion");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "EcosistemaMarinos");

            migrationBuilder.DropTable(
                name: "EspecieMarina");

            migrationBuilder.DropTable(
                name: "Amenaza");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
