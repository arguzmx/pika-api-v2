using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pika.servicios.gestiondocumental.data.migrations
{
    /// <inheritdoc />
    public partial class posicionalmacencajaalmacen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gd$catalogos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Idioma = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Texto = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnidadOrganizacionalId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CatalogoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discriminator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gd$catalogos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gd$cuadroclasificacion",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UOrgId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gd$cuadroclasificacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gd$archivo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UOrgId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoArchivoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gd$archivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gd$archivo_gd$catalogos_TipoArchivoId",
                        column: x => x.TipoArchivoId,
                        principalTable: "gd$catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gd$i18ncatalogos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Idioma = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnidadOrganizacionalId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Texto = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CatalogoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discriminator = table.Column<int>(type: "int", nullable: false),
                    ElementoCatalogoId = table.Column<string>(type: "varchar(128)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gd$i18ncatalogos", x => new { x.Id, x.DominioId, x.UnidadOrganizacionalId, x.Idioma });
                    table.ForeignKey(
                        name: "FK_gd$i18ncatalogos_gd$catalogos_ElementoCatalogoId",
                        column: x => x.ElementoCatalogoId,
                        principalTable: "gd$catalogos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                    IdentificadorInterno = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaApertura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Asunto = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoOptico = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoElectronico = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsElectronico = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Reservado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Confidencial = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UbicacionCaja = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UbicacionRack = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnPrestamo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EnTransferencia = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ampliado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaRetencionAT = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FechaRetencionAC = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AlmacenArchivoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZonaAlmacenId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContenedorAlmacenId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnidadOrganizacionalId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiasTransferir = table.Column<int>(type: "int", nullable: true),
                    TieneContenido = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ContenidoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gd$activo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gd$activo_gd$cuadroclasificacion_CuadroClasificacionId",
                        column: x => x.CuadroClasificacionId,
                        principalTable: "gd$cuadroclasificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gd$seriedocumental",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CuadroClasificacionId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Clave = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Raiz = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SeriePadreId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MesesArchivoTramite = table.Column<int>(type: "int", nullable: false),
                    MesesArchivoConcentracion = table.Column<int>(type: "int", nullable: false),
                    MesesArchivoHistorico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gd$seriedocumental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gd$seriedocumental_gd$cuadroclasificacion_CuadroClasificacio~",
                        column: x => x.CuadroClasificacionId,
                        principalTable: "gd$cuadroclasificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_gd$seriedocumental_gd$seriedocumental_SeriePadreId",
                        column: x => x.SeriePadreId,
                        principalTable: "gd$seriedocumental",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gd$almacenarchivo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Clave = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArchivoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ubicacion = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gd$almacenarchivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gd$almacenarchivo_gd$archivo_ArchivoId",
                        column: x => x.ArchivoId,
                        principalTable: "gd$archivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gd$zonaalmacen",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArchivoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AlmacenArchivoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gd$zonaalmacen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gd$zonaalmacen_gd$almacenarchivo_AlmacenArchivoId",
                        column: x => x.AlmacenArchivoId,
                        principalTable: "gd$almacenarchivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gd$zonaalmacen_gd$archivo_ArchivoId",
                        column: x => x.ArchivoId,
                        principalTable: "gd$archivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gd$posicionalmacen",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Indice = table.Column<int>(type: "int", nullable: false),
                    Localizacion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoBarras = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoElectronico = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ocupacion = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IncrementoContenedor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ArchivoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AlmacenArchivoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZonaAlmacenId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gd$posicionalmacen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gd$posicionalmacen_gd$almacenarchivo_AlmacenArchivoId",
                        column: x => x.AlmacenArchivoId,
                        principalTable: "gd$almacenarchivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gd$posicionalmacen_gd$archivo_ArchivoId",
                        column: x => x.ArchivoId,
                        principalTable: "gd$archivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gd$posicionalmacen_gd$zonaalmacen_ZonaAlmacenId",
                        column: x => x.ZonaAlmacenId,
                        principalTable: "gd$zonaalmacen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gd$cajaalmacen",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoBarras = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoElectronico = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ocupacion = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    AlmacenArchivoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZonaAlmacenId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PosicionAlmacenId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArchivoId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gd$cajaalmacen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gd$cajaalmacen_gd$almacenarchivo_AlmacenArchivoId",
                        column: x => x.AlmacenArchivoId,
                        principalTable: "gd$almacenarchivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gd$cajaalmacen_gd$archivo_ArchivoId",
                        column: x => x.ArchivoId,
                        principalTable: "gd$archivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gd$cajaalmacen_gd$posicionalmacen_PosicionAlmacenId",
                        column: x => x.PosicionAlmacenId,
                        principalTable: "gd$posicionalmacen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gd$cajaalmacen_gd$zonaalmacen_ZonaAlmacenId",
                        column: x => x.ZonaAlmacenId,
                        principalTable: "gd$zonaalmacen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_gd$activo_CuadroClasificacionId",
                table: "gd$activo",
                column: "CuadroClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$almacenarchivo_ArchivoId",
                table: "gd$almacenarchivo",
                column: "ArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$archivo_TipoArchivoId",
                table: "gd$archivo",
                column: "TipoArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$cajaalmacen_AlmacenArchivoId",
                table: "gd$cajaalmacen",
                column: "AlmacenArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$cajaalmacen_ArchivoId",
                table: "gd$cajaalmacen",
                column: "ArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$cajaalmacen_PosicionAlmacenId",
                table: "gd$cajaalmacen",
                column: "PosicionAlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$cajaalmacen_ZonaAlmacenId",
                table: "gd$cajaalmacen",
                column: "ZonaAlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$catalogos_CatalogoId",
                table: "gd$catalogos",
                column: "CatalogoId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$i18ncatalogos_CatalogoId_Idioma",
                table: "gd$i18ncatalogos",
                columns: new[] { "CatalogoId", "Idioma" });

            migrationBuilder.CreateIndex(
                name: "IX_gd$i18ncatalogos_ElementoCatalogoId",
                table: "gd$i18ncatalogos",
                column: "ElementoCatalogoId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$posicionalmacen_AlmacenArchivoId",
                table: "gd$posicionalmacen",
                column: "AlmacenArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$posicionalmacen_ArchivoId",
                table: "gd$posicionalmacen",
                column: "ArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$posicionalmacen_ZonaAlmacenId",
                table: "gd$posicionalmacen",
                column: "ZonaAlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$seriedocumental_CuadroClasificacionId",
                table: "gd$seriedocumental",
                column: "CuadroClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$seriedocumental_SeriePadreId",
                table: "gd$seriedocumental",
                column: "SeriePadreId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$zonaalmacen_AlmacenArchivoId",
                table: "gd$zonaalmacen",
                column: "AlmacenArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$zonaalmacen_ArchivoId",
                table: "gd$zonaalmacen",
                column: "ArchivoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gd$activo");

            migrationBuilder.DropTable(
                name: "gd$cajaalmacen");

            migrationBuilder.DropTable(
                name: "gd$i18ncatalogos");

            migrationBuilder.DropTable(
                name: "gd$seriedocumental");

            migrationBuilder.DropTable(
                name: "gd$posicionalmacen");

            migrationBuilder.DropTable(
                name: "gd$cuadroclasificacion");

            migrationBuilder.DropTable(
                name: "gd$zonaalmacen");

            migrationBuilder.DropTable(
                name: "gd$almacenarchivo");

            migrationBuilder.DropTable(
                name: "gd$archivo");

            migrationBuilder.DropTable(
                name: "gd$catalogos");
        }
    }
}
