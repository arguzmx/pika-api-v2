using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pika.servicios.gestiondocumental.data.migrations
{
    /// <inheritdoc />
    public partial class InicialArchivo : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_gd$archivo_TipoArchivoId",
                table: "gd$archivo",
                column: "TipoArchivoId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gd$archivo");

            migrationBuilder.DropTable(
                name: "gd$i18ncatalogos");

            migrationBuilder.DropTable(
                name: "gd$catalogos");
        }
    }
}
