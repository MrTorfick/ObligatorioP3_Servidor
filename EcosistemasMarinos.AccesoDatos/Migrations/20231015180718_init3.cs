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
            migrationBuilder.DropColumn(
                name: "Prueba2",
                table: "EspecieMarina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prueba2",
                table: "EspecieMarina",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
