using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class amenazasasociadas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenaza_EcosistemaMarinos_EcosistemaMarinoId",
                table: "Amenaza");

            migrationBuilder.DropForeignKey(
                name: "FK_Amenaza_EspecieMarina_EspecieMarinaId",
                table: "Amenaza");

            migrationBuilder.DropForeignKey(
                name: "FK_AmenazasAsociadas_Amenaza_amenazaId",
                table: "AmenazasAsociadas");

            migrationBuilder.DropForeignKey(
                name: "FK_AmenazasAsociadas_EcosistemaMarinos_ecosistemaMarinoId",
                table: "AmenazasAsociadas");

            migrationBuilder.DropForeignKey(
                name: "FK_AmenazasAsociadas_EspecieMarina_especieMarinaId",
                table: "AmenazasAsociadas");

            migrationBuilder.DropIndex(
                name: "IX_AmenazasAsociadas_amenazaId",
                table: "AmenazasAsociadas");

            migrationBuilder.DropIndex(
                name: "IX_Amenaza_EcosistemaMarinoId",
                table: "Amenaza");

            migrationBuilder.DropIndex(
                name: "IX_Amenaza_EspecieMarinaId",
                table: "Amenaza");

            migrationBuilder.DropColumn(
                name: "EcosistemaMarinoId",
                table: "Amenaza");

            migrationBuilder.DropColumn(
                name: "EspecieMarinaId",
                table: "Amenaza");

            migrationBuilder.RenameColumn(
                name: "especieMarinaId",
                table: "AmenazasAsociadas",
                newName: "EspecieMarinaId");

            migrationBuilder.RenameColumn(
                name: "ecosistemaMarinoId",
                table: "AmenazasAsociadas",
                newName: "EcosistemaMarinoId");

            migrationBuilder.RenameColumn(
                name: "amenazaId",
                table: "AmenazasAsociadas",
                newName: "AmenazaId");

            migrationBuilder.RenameIndex(
                name: "IX_AmenazasAsociadas_especieMarinaId",
                table: "AmenazasAsociadas",
                newName: "IX_AmenazasAsociadas_EspecieMarinaId");

            migrationBuilder.RenameIndex(
                name: "IX_AmenazasAsociadas_ecosistemaMarinoId",
                table: "AmenazasAsociadas",
                newName: "IX_AmenazasAsociadas_EcosistemaMarinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AmenazasAsociadas_EcosistemaMarinos_EcosistemaMarinoId",
                table: "AmenazasAsociadas",
                column: "EcosistemaMarinoId",
                principalTable: "EcosistemaMarinos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AmenazasAsociadas_EspecieMarina_EspecieMarinaId",
                table: "AmenazasAsociadas",
                column: "EspecieMarinaId",
                principalTable: "EspecieMarina",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmenazasAsociadas_EcosistemaMarinos_EcosistemaMarinoId",
                table: "AmenazasAsociadas");

            migrationBuilder.DropForeignKey(
                name: "FK_AmenazasAsociadas_EspecieMarina_EspecieMarinaId",
                table: "AmenazasAsociadas");

            migrationBuilder.RenameColumn(
                name: "EspecieMarinaId",
                table: "AmenazasAsociadas",
                newName: "especieMarinaId");

            migrationBuilder.RenameColumn(
                name: "EcosistemaMarinoId",
                table: "AmenazasAsociadas",
                newName: "ecosistemaMarinoId");

            migrationBuilder.RenameColumn(
                name: "AmenazaId",
                table: "AmenazasAsociadas",
                newName: "amenazaId");

            migrationBuilder.RenameIndex(
                name: "IX_AmenazasAsociadas_EspecieMarinaId",
                table: "AmenazasAsociadas",
                newName: "IX_AmenazasAsociadas_especieMarinaId");

            migrationBuilder.RenameIndex(
                name: "IX_AmenazasAsociadas_EcosistemaMarinoId",
                table: "AmenazasAsociadas",
                newName: "IX_AmenazasAsociadas_ecosistemaMarinoId");

            migrationBuilder.AddColumn<int>(
                name: "EcosistemaMarinoId",
                table: "Amenaza",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EspecieMarinaId",
                table: "Amenaza",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AmenazasAsociadas_amenazaId",
                table: "AmenazasAsociadas",
                column: "amenazaId");

            migrationBuilder.CreateIndex(
                name: "IX_Amenaza_EcosistemaMarinoId",
                table: "Amenaza",
                column: "EcosistemaMarinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Amenaza_EspecieMarinaId",
                table: "Amenaza",
                column: "EspecieMarinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenaza_EcosistemaMarinos_EcosistemaMarinoId",
                table: "Amenaza",
                column: "EcosistemaMarinoId",
                principalTable: "EcosistemaMarinos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenaza_EspecieMarina_EspecieMarinaId",
                table: "Amenaza",
                column: "EspecieMarinaId",
                principalTable: "EspecieMarina",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AmenazasAsociadas_Amenaza_amenazaId",
                table: "AmenazasAsociadas",
                column: "amenazaId",
                principalTable: "Amenaza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AmenazasAsociadas_EcosistemaMarinos_ecosistemaMarinoId",
                table: "AmenazasAsociadas",
                column: "ecosistemaMarinoId",
                principalTable: "EcosistemaMarinos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AmenazasAsociadas_EspecieMarina_especieMarinaId",
                table: "AmenazasAsociadas",
                column: "especieMarinaId",
                principalTable: "EspecieMarina",
                principalColumn: "Id");
        }
    }
}
