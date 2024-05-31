using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pika.servicios.seguridad.data.migrations
{
    /// <inheritdoc />
    public partial class creaciondelosModelosdeSeguridad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "seg$aplicacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(128)", maxLength: 128, nullable: false, collation: "ascii_general_ci"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seg$aplicacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "seg$modulo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(128)", maxLength: 128, nullable: false, collation: "ascii_general_ci"),
                    AplicacionId = table.Column<Guid>(type: "char(128)", nullable: false, collation: "ascii_general_ci"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seg$modulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_seg$modulo_seg$aplicacion_AplicacionId",
                        column: x => x.AplicacionId,
                        principalTable: "seg$aplicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "seg$permiso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(128)", maxLength: 128, nullable: false, collation: "ascii_general_ci"),
                    ModuloId = table.Column<Guid>(type: "char(128)", nullable: false, collation: "ascii_general_ci"),
                    AplicacionId = table.Column<Guid>(type: "char(128)", nullable: false, collation: "ascii_general_ci"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ambito = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seg$permiso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_seg$permiso_seg$aplicacion_AplicacionId",
                        column: x => x.AplicacionId,
                        principalTable: "seg$aplicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seg$permiso_seg$modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "seg$modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "seg$rol",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(128)", maxLength: 128, nullable: false, collation: "ascii_general_ci"),
                    ModuloId = table.Column<Guid>(type: "char(128)", nullable: false, collation: "ascii_general_ci"),
                    AplicacionId = table.Column<Guid>(type: "char(128)", nullable: false, collation: "ascii_general_ci"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Permisos = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Personalizado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seg$rol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_seg$rol_seg$aplicacion_AplicacionId",
                        column: x => x.AplicacionId,
                        principalTable: "seg$aplicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seg$rol_seg$modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "seg$modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_seg$modulo_AplicacionId",
                table: "seg$modulo",
                column: "AplicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_seg$permiso_AplicacionId",
                table: "seg$permiso",
                column: "AplicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_seg$permiso_ModuloId",
                table: "seg$permiso",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_seg$rol_AplicacionId",
                table: "seg$rol",
                column: "AplicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_seg$rol_ModuloId",
                table: "seg$rol",
                column: "ModuloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "seg$permiso");

            migrationBuilder.DropTable(
                name: "seg$rol");

            migrationBuilder.DropTable(
                name: "seg$modulo");

            migrationBuilder.DropTable(
                name: "seg$aplicacion");
        }
    }
}
