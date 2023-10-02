using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class fixEcosistemaMarino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EspecieMarina_estadoConservacions_EstadoConservacionId",
                table: "EspecieMarina");

            migrationBuilder.DropIndex(
                name: "IX_EspecieMarina_EstadoConservacionId",
                table: "EspecieMarina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EspecieMarina_EstadoConservacionId",
                table: "EspecieMarina",
                column: "EstadoConservacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EspecieMarina_estadoConservacions_EstadoConservacionId",
                table: "EspecieMarina",
                column: "EstadoConservacionId",
                principalTable: "estadoConservacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
