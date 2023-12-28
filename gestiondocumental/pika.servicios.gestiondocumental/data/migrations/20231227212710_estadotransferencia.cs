using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pika.servicios.gestiondocumental.data.migrations
{
    /// <inheritdoc />
    public partial class estadotransferencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gd$transferencias",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Folio = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArchivoOrigenId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArchivoDestinoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CuadroClasificacionId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerieDocumentalId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RangoDias = table.Column<int>(type: "int", nullable: true),
                    CantidadActivos = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EstadoTransferenciaId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gd$transferencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gd$transferencias_gd$archivo_ArchivoDestinoId",
                        column: x => x.ArchivoDestinoId,
                        principalTable: "gd$archivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gd$transferencias_gd$archivo_ArchivoOrigenId",
                        column: x => x.ArchivoOrigenId,
                        principalTable: "gd$archivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gd$transferencias_gd$catalogos_EstadoTransferenciaId",
                        column: x => x.EstadoTransferenciaId,
                        principalTable: "gd$catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gd$transferencias_gd$cuadroclasificacion_CuadroClasificacion~",
                        column: x => x.CuadroClasificacionId,
                        principalTable: "gd$cuadroclasificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gd$transferencias_gd$seriedocumental_SerieDocumentalId",
                        column: x => x.SerieDocumentalId,
                        principalTable: "gd$seriedocumental",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_gd$transferencias_ArchivoDestinoId",
                table: "gd$transferencias",
                column: "ArchivoDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$transferencias_ArchivoOrigenId",
                table: "gd$transferencias",
                column: "ArchivoOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$transferencias_CuadroClasificacionId",
                table: "gd$transferencias",
                column: "CuadroClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$transferencias_EstadoTransferenciaId",
                table: "gd$transferencias",
                column: "EstadoTransferenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$transferencias_SerieDocumentalId",
                table: "gd$transferencias",
                column: "SerieDocumentalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gd$transferencias");
        }
    }
}
