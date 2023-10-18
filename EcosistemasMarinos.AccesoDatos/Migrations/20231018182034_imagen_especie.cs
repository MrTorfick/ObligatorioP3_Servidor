using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class imagen_especie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Configuracion",
                table: "Configuracion");

            migrationBuilder.DropColumn(
                name: "Imagen_Valor",
                table: "EspecieMarina");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Configuracion",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Configuracion",
                table: "Configuracion",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Auditoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEntidad = table.Column<int>(type: "int", nullable: false),
                    TipoEntidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EspecieMarina_Imagen",
                columns: table => new
                {
                    EspecieMarinaId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecieMarina_Imagen", x => new { x.EspecieMarinaId, x.Id });
                    table.ForeignKey(
                        name: "FK_EspecieMarina_Imagen_EspecieMarina_EspecieMarinaId",
                        column: x => x.EspecieMarinaId,
                        principalTable: "EspecieMarina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configuracion_NombreAtributo",
                table: "Configuracion",
                column: "NombreAtributo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditoria");

            migrationBuilder.DropTable(
                name: "EspecieMarina_Imagen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Configuracion",
                table: "Configuracion");

            migrationBuilder.DropIndex(
                name: "IX_Configuracion_NombreAtributo",
                table: "Configuracion");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Configuracion");

            migrationBuilder.AddColumn<string>(
                name: "Imagen_Valor",
                table: "EspecieMarina",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Configuracion",
                table: "Configuracion",
                column: "NombreAtributo");
        }
    }
}
