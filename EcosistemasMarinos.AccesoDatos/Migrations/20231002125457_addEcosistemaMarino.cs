using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class addEcosistemaMarino : Migration
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
                name: "EcosistemaMarinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DetallesGeo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    DescripcionCaracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RutaImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmenazaId = table.Column<int>(type: "int", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    EstadoConservacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaMarinos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "estadoConservacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Seguro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoConservacions", x => x.Id);
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
                    RutaImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    EstadoConservacionId = table.Column<int>(type: "int", nullable: false),
                    EcosistemaMarinoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecieMarina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EspecieMarina_EcosistemaMarinos_EcosistemaMarinoId",
                        column: x => x.EcosistemaMarinoId,
                        principalTable: "EcosistemaMarinos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EspecieMarina_EcosistemaMarinoId",
                table: "EspecieMarina",
                column: "EcosistemaMarinoId");

            migrationBuilder.CreateIndex(
                name: "IX_estadoConservacions_Nombre",
                table: "estadoConservacions",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenaza");

            migrationBuilder.DropTable(
                name: "EspecieMarina");

            migrationBuilder.DropTable(
                name: "estadoConservacions");

            migrationBuilder.DropTable(
                name: "EcosistemaMarinos");
        }
    }
}
