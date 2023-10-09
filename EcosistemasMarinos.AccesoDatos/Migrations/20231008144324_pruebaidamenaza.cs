using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class pruebaidamenaza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcosistemaMarinoEspecieMarina");

            migrationBuilder.AddColumn<int>(
                name: "EspecieMarinaId",
                table: "EcosistemaMarinos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaMarinos_EspecieMarinaId",
                table: "EcosistemaMarinos",
                column: "EspecieMarinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EcosistemaMarinos_EspecieMarina_EspecieMarinaId",
                table: "EcosistemaMarinos",
                column: "EspecieMarinaId",
                principalTable: "EspecieMarina",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosistemaMarinos_EspecieMarina_EspecieMarinaId",
                table: "EcosistemaMarinos");

            migrationBuilder.DropIndex(
                name: "IX_EcosistemaMarinos_EspecieMarinaId",
                table: "EcosistemaMarinos");

            migrationBuilder.DropColumn(
                name: "EspecieMarinaId",
                table: "EcosistemaMarinos");

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
        }
    }
}
