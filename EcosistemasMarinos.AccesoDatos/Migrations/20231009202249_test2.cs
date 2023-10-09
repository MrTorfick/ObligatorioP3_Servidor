using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "EcosistemaMarinoId",
                table: "Amenaza",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Amenaza_EcosistemaMarinos_EcosistemaMarinoId",
                table: "Amenaza",
                column: "EcosistemaMarinoId",
                principalTable: "EcosistemaMarinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "ecosistemaMarinoId",
                table: "Amenaza",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenaza_EcosistemaMarinos_ecosistemaMarinoId",
                table: "Amenaza",
                column: "ecosistemaMarinoId",
                principalTable: "EcosistemaMarinos",
                principalColumn: "Id");
        }
    }
}
