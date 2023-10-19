using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ultima_migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosistemaMarino_Pais_PaisId",
                table: "EcosistemaMarino");

            migrationBuilder.AlterColumn<int>(
                name: "PaisId",
                table: "EcosistemaMarino",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EcosistemaMarino_Pais_PaisId",
                table: "EcosistemaMarino",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "PaisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosistemaMarino_Pais_PaisId",
                table: "EcosistemaMarino");

            migrationBuilder.AlterColumn<int>(
                name: "PaisId",
                table: "EcosistemaMarino",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EcosistemaMarino_Pais_PaisId",
                table: "EcosistemaMarino",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "PaisId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
