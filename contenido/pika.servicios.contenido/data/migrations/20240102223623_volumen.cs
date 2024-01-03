using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pika.servicios.contenido.data.migrations
{
    /// <inheritdoc />
    public partial class volumen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cont$catalogos",
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
                    table.PrimaryKey("PK_cont$catalogos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cont$i18ncatalogos",
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
                    table.PrimaryKey("PK_cont$i18ncatalogos", x => new { x.Id, x.DominioId, x.UnidadOrganizacionalId, x.Idioma });
                    table.ForeignKey(
                        name: "FK_cont$i18ncatalogos_cont$catalogos_ElementoCatalogoId",
                        column: x => x.ElementoCatalogoId,
                        principalTable: "cont$catalogos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cont$volumen",
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
                    TipoGestorESId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TamanoMaximo = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EscrituraHabilitada = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ConsecutivoVolumen = table.Column<long>(type: "bigint", nullable: false),
                    CanidadPartes = table.Column<long>(type: "bigint", nullable: false),
                    CanidadElementos = table.Column<long>(type: "bigint", nullable: false),
                    Tamano = table.Column<long>(type: "bigint", nullable: false),
                    ConfiguracionValida = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cont$volumen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cont$volumen_cont$catalogos_TipoGestorESId",
                        column: x => x.TipoGestorESId,
                        principalTable: "cont$catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_cont$catalogos_CatalogoId",
                table: "cont$catalogos",
                column: "CatalogoId");

            migrationBuilder.CreateIndex(
                name: "IX_cont$i18ncatalogos_CatalogoId_Idioma",
                table: "cont$i18ncatalogos",
                columns: new[] { "CatalogoId", "Idioma" });

            migrationBuilder.CreateIndex(
                name: "IX_cont$i18ncatalogos_ElementoCatalogoId",
                table: "cont$i18ncatalogos",
                column: "ElementoCatalogoId");

            migrationBuilder.CreateIndex(
                name: "IX_cont$volumen_TipoGestorESId",
                table: "cont$volumen",
                column: "TipoGestorESId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cont$i18ncatalogos");

            migrationBuilder.DropTable(
                name: "cont$volumen");

            migrationBuilder.DropTable(
                name: "cont$catalogos");
        }
    }
}
