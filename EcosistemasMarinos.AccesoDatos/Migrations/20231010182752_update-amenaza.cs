using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class updateamenaza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EspecieMarinaId",
                table: "Amenaza",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amenaza_EspecieMarinaId",
                table: "Amenaza",
                column: "EspecieMarinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenaza_EspecieMarina_EspecieMarinaId",
                table: "Amenaza",
                column: "EspecieMarinaId",
                principalTable: "EspecieMarina",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenaza_EspecieMarina_EspecieMarinaId",
                table: "Amenaza");

            migrationBuilder.DropIndex(
                name: "IX_Amenaza_EspecieMarinaId",
                table: "Amenaza");

            migrationBuilder.DropColumn(
                name: "EspecieMarinaId",
                table: "Amenaza");
        }
    }
}
