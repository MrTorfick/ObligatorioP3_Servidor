using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenaza_EcosistemaMarinos_EcosistemaMarinoId",
                table: "Amenaza");

            migrationBuilder.RenameColumn(
                name: "EcosistemaMarinoId",
                table: "Amenaza",
                newName: "ecosistemaMarinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Amenaza_EcosistemaMarinoId",
                table: "Amenaza",
                newName: "IX_Amenaza_ecosistemaMarinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenaza_EcosistemaMarinos_ecosistemaMarinoId",
                table: "Amenaza",
                column: "ecosistemaMarinoId",
                principalTable: "EcosistemaMarinos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenaza_EcosistemaMarinos_ecosistemaMarinoId",
                table: "Amenaza");

            migrationBuilder.RenameColumn(
                name: "ecosistemaMarinoId",
                table: "Amenaza",
                newName: "EcosistemaMarinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Amenaza_ecosistemaMarinoId",
                table: "Amenaza",
                newName: "IX_Amenaza_EcosistemaMarinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenaza_EcosistemaMarinos_EcosistemaMarinoId",
                table: "Amenaza",
                column: "EcosistemaMarinoId",
                principalTable: "EcosistemaMarinos",
                principalColumn: "Id");
        }
    }
}
