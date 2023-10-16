using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class consultasespecies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "EcosistemaMarinos");

            migrationBuilder.RenameColumn(
                name: "Imagen",
                table: "EspecieMarina",
                newName: "Imagen_Valor");

            migrationBuilder.AddColumn<string>(
                name: "Imagen_Valor",
                table: "EcosistemaMarinos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen_Valor",
                table: "EcosistemaMarinos");

            migrationBuilder.RenameColumn(
                name: "Imagen_Valor",
                table: "EspecieMarina",
                newName: "Imagen");

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "EcosistemaMarinos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
