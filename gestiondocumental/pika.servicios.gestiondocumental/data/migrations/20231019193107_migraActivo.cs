using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pika.servicios.gestiondocumental.data.migrations
{
    public partial class migraActivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gd$activo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CuadroClasificacionId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerieDocumentalId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArchivoOrigenId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArchivoActualId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoArchivoActualId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnidadAdministrativaId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdentificadorInterno = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaApertura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Asunto = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoOptico = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoElectronico = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsElectronico = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Reservado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Confidencial = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UbicacionCaja = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UbicacionRack = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnPrestamo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EnTransferencia = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ampliado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaRetencionAT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaRetencionAC = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AlmacenArchivoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZonaAlmacenId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContenedorAlmacenId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnidadOrganizacionalId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TieneContenido = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ContenidoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gd$activo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gd$activo_gd$archivo_ArchivoActualId",
                        column: x => x.ArchivoActualId,
                        principalTable: "gd$archivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_gd$activo_gd$archivo_ArchivoOrigenId",
                        column: x => x.ArchivoOrigenId,
                        principalTable: "gd$archivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_gd$activo_ArchivoActualId",
                table: "gd$activo",
                column: "ArchivoActualId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$activo_ArchivoOrigenId",
                table: "gd$activo",
                column: "ArchivoOrigenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gd$activo");
        }
    }
}
