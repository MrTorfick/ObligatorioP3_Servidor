using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class amenazasasociadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmenazasAsociadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amenazaId = table.Column<int>(type: "int", nullable: false),
                    ecosistemaMarinoId = table.Column<int>(type: "int", nullable: true),
                    especieMarinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenazasAsociadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmenazasAsociadas_Amenaza_amenazaId",
                        column: x => x.amenazaId,
                        principalTable: "Amenaza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenazasAsociadas_EcosistemaMarinos_ecosistemaMarinoId",
                        column: x => x.ecosistemaMarinoId,
                        principalTable: "EcosistemaMarinos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AmenazasAsociadas_EspecieMarina_especieMarinaId",
                        column: x => x.especieMarinaId,
                        principalTable: "EspecieMarina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmenazasAsociadas_amenazaId",
                table: "AmenazasAsociadas",
                column: "amenazaId");

            migrationBuilder.CreateIndex(
                name: "IX_AmenazasAsociadas_ecosistemaMarinoId",
                table: "AmenazasAsociadas",
                column: "ecosistemaMarinoId");

            migrationBuilder.CreateIndex(
                name: "IX_AmenazasAsociadas_especieMarinaId",
                table: "AmenazasAsociadas",
                column: "especieMarinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenazasAsociadas");
        }
    }
}
