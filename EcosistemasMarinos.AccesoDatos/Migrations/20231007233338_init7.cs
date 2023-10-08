using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosistemaMarinos_EstadoConservacion_EstadoConservacionId",
                table: "EcosistemaMarinos");

            migrationBuilder.DropIndex(
                name: "IX_EcosistemaMarinos_EstadoConservacionId",
                table: "EcosistemaMarinos");

            migrationBuilder.DropColumn(
                name: "EstadoConservacionId",
                table: "EcosistemaMarinos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoConservacionId",
                table: "EcosistemaMarinos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaMarinos_EstadoConservacionId",
                table: "EcosistemaMarinos",
                column: "EstadoConservacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EcosistemaMarinos_EstadoConservacion_EstadoConservacionId",
                table: "EcosistemaMarinos",
                column: "EstadoConservacionId",
                principalTable: "EstadoConservacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
