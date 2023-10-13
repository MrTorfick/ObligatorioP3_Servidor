﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _EcosistemasMarinos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class cambiosmanytomany3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Especies_Habitan");

            migrationBuilder.DropTable(
                name: "Especies_PodrianHabitar");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "EcosistemaMarinos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "EspeciesHabitab",
                columns: table => new
                {
                    EcosistemaMarinoId = table.Column<int>(type: "int", nullable: false),
                    EspecieMarinaId = table.Column<int>(type: "int", nullable: false),
                    Habita = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspeciesHabitab", x => new { x.EcosistemaMarinoId, x.EspecieMarinaId });
                    table.ForeignKey(
                        name: "FK_EspeciesHabitab_EcosistemaMarinos_EcosistemaMarinoId",
                        column: x => x.EcosistemaMarinoId,
                        principalTable: "EcosistemaMarinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspeciesHabitab_EspecieMarina_EspecieMarinaId",
                        column: x => x.EspecieMarinaId,
                        principalTable: "EspecieMarina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EspeciesHabitab_EspecieMarinaId",
                table: "EspeciesHabitab",
                column: "EspecieMarinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EspeciesHabitab");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "EcosistemaMarinos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Especies_Habitan",
                columns: table => new
                {
                    EcosistemaMarinosVivenId = table.Column<int>(type: "int", nullable: false),
                    EspeciesHabitanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies_Habitan", x => new { x.EcosistemaMarinosVivenId, x.EspeciesHabitanId });
                    table.ForeignKey(
                        name: "FK_Especies_Habitan_EcosistemaMarinos_EcosistemaMarinosVivenId",
                        column: x => x.EcosistemaMarinosVivenId,
                        principalTable: "EcosistemaMarinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Especies_Habitan_EspecieMarina_EspeciesHabitanId",
                        column: x => x.EspeciesHabitanId,
                        principalTable: "EspecieMarina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Especies_PodrianHabitar",
                columns: table => new
                {
                    EcosistemasMarinosVidaPosibleId = table.Column<int>(type: "int", nullable: false),
                    EspeciesPodrianHabitarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies_PodrianHabitar", x => new { x.EcosistemasMarinosVidaPosibleId, x.EspeciesPodrianHabitarId });
                    table.ForeignKey(
                        name: "FK_Especies_PodrianHabitar_EcosistemaMarinos_EcosistemasMarinosVidaPosibleId",
                        column: x => x.EcosistemasMarinosVidaPosibleId,
                        principalTable: "EcosistemaMarinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Especies_PodrianHabitar_EspecieMarina_EspeciesPodrianHabitarId",
                        column: x => x.EspeciesPodrianHabitarId,
                        principalTable: "EspecieMarina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Especies_Habitan_EspeciesHabitanId",
                table: "Especies_Habitan",
                column: "EspeciesHabitanId");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_PodrianHabitar_EspeciesPodrianHabitarId",
                table: "Especies_PodrianHabitar",
                column: "EspeciesPodrianHabitarId");
        }
    }
}
