using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosistemaMarinos_Amenaza_IdAmenaza",
                table: "EcosistemaMarinos");

            migrationBuilder.RenameColumn(
                name: "IdAmenaza",
                table: "EcosistemaMarinos",
                newName: "AmenazaId");

            migrationBuilder.RenameIndex(
                name: "IX_EcosistemaMarinos_IdAmenaza",
                table: "EcosistemaMarinos",
                newName: "IX_EcosistemaMarinos_AmenazaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EcosistemaMarinos_Amenaza_AmenazaId",
                table: "EcosistemaMarinos",
                column: "AmenazaId",
                principalTable: "Amenaza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosistemaMarinos_Amenaza_AmenazaId",
                table: "EcosistemaMarinos");

            migrationBuilder.RenameColumn(
                name: "AmenazaId",
                table: "EcosistemaMarinos",
                newName: "IdAmenaza");

            migrationBuilder.RenameIndex(
                name: "IX_EcosistemaMarinos_AmenazaId",
                table: "EcosistemaMarinos",
                newName: "IX_EcosistemaMarinos_IdAmenaza");

            migrationBuilder.AddForeignKey(
                name: "FK_EcosistemaMarinos_Amenaza_IdAmenaza",
                table: "EcosistemaMarinos",
                column: "IdAmenaza",
                principalTable: "Amenaza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
