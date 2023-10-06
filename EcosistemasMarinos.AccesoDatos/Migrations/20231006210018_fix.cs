using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosistemaMarinos_estadoConservacions_EstadoConservacionId",
                table: "EcosistemaMarinos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_estadoConservacions",
                table: "estadoConservacions");

            migrationBuilder.RenameTable(
                name: "estadoConservacions",
                newName: "EstadoConservacion");

            migrationBuilder.RenameIndex(
                name: "IX_estadoConservacions_Nombre",
                table: "EstadoConservacion",
                newName: "IX_EstadoConservacion_Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadoConservacion",
                table: "EstadoConservacion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EcosistemaMarinos_EstadoConservacion_EstadoConservacionId",
                table: "EcosistemaMarinos",
                column: "EstadoConservacionId",
                principalTable: "EstadoConservacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosistemaMarinos_EstadoConservacion_EstadoConservacionId",
                table: "EcosistemaMarinos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadoConservacion",
                table: "EstadoConservacion");

            migrationBuilder.RenameTable(
                name: "EstadoConservacion",
                newName: "estadoConservacions");

            migrationBuilder.RenameIndex(
                name: "IX_EstadoConservacion_Nombre",
                table: "estadoConservacions",
                newName: "IX_estadoConservacions_Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_estadoConservacions",
                table: "estadoConservacions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EcosistemaMarinos_estadoConservacions_EstadoConservacionId",
                table: "EcosistemaMarinos",
                column: "EstadoConservacionId",
                principalTable: "estadoConservacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
