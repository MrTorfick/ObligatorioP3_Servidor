using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EspecieMarina_EcosistemaMarinos_EcosistemaMarinoId",
                table: "EspecieMarina");

            migrationBuilder.DropIndex(
                name: "IX_EspecieMarina_EcosistemaMarinoId",
                table: "EspecieMarina");

            migrationBuilder.DropColumn(
                name: "EcosistemaMarinoId",
                table: "EspecieMarina");

            migrationBuilder.RenameColumn(
                name: "Seguro",
                table: "EstadoConservacion",
                newName: "Rangos_Minimo");

            migrationBuilder.AddColumn<int>(
                name: "Rangos_Maximo",
                table: "EstadoConservacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EcosistemaMarinoEspecieMarina",
                columns: table => new
                {
                    EcosistemaMarinosId = table.Column<int>(type: "int", nullable: false),
                    EspeciesHabitanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaMarinoEspecieMarina", x => new { x.EcosistemaMarinosId, x.EspeciesHabitanId });
                    table.ForeignKey(
                        name: "FK_EcosistemaMarinoEspecieMarina_EcosistemaMarinos_EcosistemaMarinosId",
                        column: x => x.EcosistemaMarinosId,
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcosistemaMarinoEspecieMarina");

            migrationBuilder.DropColumn(
                name: "Rangos_Maximo",
                table: "EstadoConservacion");

            migrationBuilder.RenameColumn(
                name: "Rangos_Minimo",
                table: "EstadoConservacion",
                newName: "Seguro");

            migrationBuilder.AddColumn<int>(
                name: "EcosistemaMarinoId",
                table: "EspecieMarina",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EspecieMarina_EcosistemaMarinoId",
                table: "EspecieMarina",
                column: "EcosistemaMarinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EspecieMarina_EcosistemaMarinos_EcosistemaMarinoId",
                table: "EspecieMarina",
                column: "EcosistemaMarinoId",
                principalTable: "EcosistemaMarinos",
                principalColumn: "Id");
        }
    }
}
