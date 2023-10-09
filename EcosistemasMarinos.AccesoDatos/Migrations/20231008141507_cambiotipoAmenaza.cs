using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class cambiotipoAmenaza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosistemaMarinos_Pais_paisNombre_paisCodigoISO",
                table: "EcosistemaMarinos");

            migrationBuilder.RenameColumn(
                name: "paisNombre",
                table: "EcosistemaMarinos",
                newName: "paisnombre");

            migrationBuilder.RenameColumn(
                name: "paisCodigoISO",
                table: "EcosistemaMarinos",
                newName: "paiscodigoISO");

            migrationBuilder.RenameIndex(
                name: "IX_EcosistemaMarinos_paisNombre_paisCodigoISO",
                table: "EcosistemaMarinos",
                newName: "IX_EcosistemaMarinos_paisnombre_paiscodigoISO");

            migrationBuilder.AlterColumn<string>(
                name: "paisnombre",
                table: "EcosistemaMarinos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "paiscodigoISO",
                table: "EcosistemaMarinos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Amenaza",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 500);

            migrationBuilder.AddForeignKey(
                name: "FK_EcosistemaMarinos_Pais_paisnombre_paiscodigoISO",
                table: "EcosistemaMarinos",
                columns: new[] { "paisnombre", "paiscodigoISO" },
                principalTable: "Pais",
                principalColumns: new[] { "nombre", "codigoISO" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosistemaMarinos_Pais_paisnombre_paiscodigoISO",
                table: "EcosistemaMarinos");

            migrationBuilder.RenameColumn(
                name: "paisnombre",
                table: "EcosistemaMarinos",
                newName: "paisNombre");

            migrationBuilder.RenameColumn(
                name: "paiscodigoISO",
                table: "EcosistemaMarinos",
                newName: "paisCodigoISO");

            migrationBuilder.RenameIndex(
                name: "IX_EcosistemaMarinos_paisnombre_paiscodigoISO",
                table: "EcosistemaMarinos",
                newName: "IX_EcosistemaMarinos_paisNombre_paisCodigoISO");

            migrationBuilder.AlterColumn<string>(
                name: "paisNombre",
                table: "EcosistemaMarinos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "paisCodigoISO",
                table: "EcosistemaMarinos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "Descripcion",
                table: "Amenaza",
                type: "int",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddForeignKey(
                name: "FK_EcosistemaMarinos_Pais_paisNombre_paisCodigoISO",
                table: "EcosistemaMarinos",
                columns: new[] { "paisNombre", "paisCodigoISO" },
                principalTable: "Pais",
                principalColumns: new[] { "nombre", "codigoISO" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
