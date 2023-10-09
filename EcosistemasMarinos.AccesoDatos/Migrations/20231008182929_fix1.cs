using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EcosistemaMarinoId",
                table: "Amenaza",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amenaza_EcosistemaMarinoId",
                table: "Amenaza",
                column: "EcosistemaMarinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenaza_EcosistemaMarinos_EcosistemaMarinoId",
                table: "Amenaza",
                column: "EcosistemaMarinoId",
                principalTable: "EcosistemaMarinos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenaza_EcosistemaMarinos_EcosistemaMarinoId",
                table: "Amenaza");

            migrationBuilder.DropIndex(
                name: "IX_Amenaza_EcosistemaMarinoId",
                table: "Amenaza");

            migrationBuilder.DropColumn(
                name: "EcosistemaMarinoId",
                table: "Amenaza");
        }
    }
}
