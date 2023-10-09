using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class configEcosistema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosistemaMarinos_Amenaza_AmenazaId",
                table: "EcosistemaMarinos");

            migrationBuilder.DropIndex(
                name: "IX_EcosistemaMarinos_AmenazaId",
                table: "EcosistemaMarinos");

            migrationBuilder.DropColumn(
                name: "AmenazaId",
                table: "EcosistemaMarinos");

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

            migrationBuilder.AddColumn<int>(
                name: "AmenazaId",
                table: "EcosistemaMarinos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaMarinos_AmenazaId",
                table: "EcosistemaMarinos",
                column: "AmenazaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EcosistemaMarinos_Amenaza_AmenazaId",
                table: "EcosistemaMarinos",
                column: "AmenazaId",
                principalTable: "Amenaza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
