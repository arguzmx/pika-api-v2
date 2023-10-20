using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pika.servicios.contenido.data.migrations
{
    public partial class tablaPermisoyAsignacionPermiso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contenido$permiso",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Leer = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Escribir = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Crear = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Eliminar = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contenido$permiso", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contenido$repositorio",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UOrgId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VolumenId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contenido$repositorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contenido$repositorio_contenido$volumen_VolumenId",
                        column: x => x.VolumenId,
                        principalTable: "contenido$volumen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contenido$asignacionpermiso",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RolId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PermisoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contenido$asignacionpermiso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contenido$asignacionpermiso_contenido$permiso_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "contenido$permiso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contenido$carpeta",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RepositorioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreadorId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarpetaPadreId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsRaiz = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PermisoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contenido$carpeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contenido$carpeta_contenido$permiso_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "contenido$permiso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contenido$carpeta_contenido$repositorio_RepositorioId",
                        column: x => x.RepositorioId,
                        principalTable: "contenido$repositorio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contenido$contenido",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RepositorioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreadorId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ConteoAnexos = table.Column<int>(type: "int", nullable: false),
                    TamanoBytes = table.Column<long>(type: "bigint", nullable: false),
                    VolumenId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarpetaId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoElemento = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdExterno = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PermisoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contenido$contenido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contenido$contenido_contenido$carpeta_CarpetaId",
                        column: x => x.CarpetaId,
                        principalTable: "contenido$carpeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contenido$contenido_contenido$permiso_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "contenido$permiso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contenido$contenido_contenido$repositorio_RepositorioId",
                        column: x => x.RepositorioId,
                        principalTable: "contenido$repositorio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contenido$contenido_contenido$volumen_VolumenId",
                        column: x => x.VolumenId,
                        principalTable: "contenido$volumen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_contenido$asignacionpermiso_PermisoId",
                table: "contenido$asignacionpermiso",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_contenido$carpeta_PermisoId",
                table: "contenido$carpeta",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_contenido$carpeta_RepositorioId",
                table: "contenido$carpeta",
                column: "RepositorioId");

            migrationBuilder.CreateIndex(
                name: "IX_contenido$contenido_CarpetaId",
                table: "contenido$contenido",
                column: "CarpetaId");

            migrationBuilder.CreateIndex(
                name: "IX_contenido$contenido_PermisoId",
                table: "contenido$contenido",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_contenido$contenido_RepositorioId",
                table: "contenido$contenido",
                column: "RepositorioId");

            migrationBuilder.CreateIndex(
                name: "IX_contenido$contenido_VolumenId",
                table: "contenido$contenido",
                column: "VolumenId");

            migrationBuilder.CreateIndex(
                name: "IX_contenido$repositorio_VolumenId",
                table: "contenido$repositorio",
                column: "VolumenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contenido$asignacionpermiso");

            migrationBuilder.DropTable(
                name: "contenido$contenido");

            migrationBuilder.DropTable(
                name: "contenido$carpeta");

            migrationBuilder.DropTable(
                name: "contenido$permiso");

            migrationBuilder.DropTable(
                name: "contenido$repositorio");
        }
    }
}
