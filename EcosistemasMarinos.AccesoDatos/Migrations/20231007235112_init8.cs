using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosistemaMarinos_Pais_Paisnombre_PaiscodigoISO",
                table: "EcosistemaMarinos");

            migrationBuilder.RenameColumn(
                name: "Paisnombre",
                table: "EcosistemaMarinos",
                newName: "paisNombre");

            migrationBuilder.RenameColumn(
                name: "PaiscodigoISO",
                table: "EcosistemaMarinos",
                newName: "paisCodigoISO");

            migrationBuilder.RenameIndex(
                name: "IX_EcosistemaMarinos_Paisnombre_PaiscodigoISO",
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

            migrationBuilder.AddForeignKey(
                name: "FK_EcosistemaMarinos_Pais_paisNombre_paisCodigoISO",
                table: "EcosistemaMarinos",
                columns: new[] { "paisNombre", "paisCodigoISO" },
                principalTable: "Pais",
                principalColumns: new[] { "nombre", "codigoISO" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosistemaMarinos_EstadoConservacion_EstadoConservacionId",
                table: "EcosistemaMarinos");

            migrationBuilder.DropForeignKey(
                name: "FK_EcosistemaMarinos_Pais_paisNombre_paisCodigoISO",
                table: "EcosistemaMarinos");

            migrationBuilder.DropIndex(
                name: "IX_EcosistemaMarinos_EstadoConservacionId",
                table: "EcosistemaMarinos");

            migrationBuilder.DropColumn(
                name: "EstadoConservacionId",
                table: "EcosistemaMarinos");

            migrationBuilder.RenameColumn(
                name: "paisNombre",
                table: "EcosistemaMarinos",
                newName: "Paisnombre");

            migrationBuilder.RenameColumn(
                name: "paisCodigoISO",
                table: "EcosistemaMarinos",
                newName: "PaiscodigoISO");

            migrationBuilder.RenameIndex(
                name: "IX_EcosistemaMarinos_paisNombre_paisCodigoISO",
                table: "EcosistemaMarinos",
                newName: "IX_EcosistemaMarinos_Paisnombre_PaiscodigoISO");

            migrationBuilder.AlterColumn<string>(
                name: "Paisnombre",
                table: "EcosistemaMarinos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "PaiscodigoISO",
                table: "EcosistemaMarinos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddForeignKey(
                name: "FK_EcosistemaMarinos_Pais_Paisnombre_PaiscodigoISO",
                table: "EcosistemaMarinos",
                columns: new[] { "Paisnombre", "PaiscodigoISO" },
                principalTable: "Pais",
                principalColumns: new[] { "nombre", "codigoISO" });
        }
    }
}
