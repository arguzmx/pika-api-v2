using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pika.servicios.organizacion.data.migrations
{
    /// <inheritdoc />
    public partial class PV224 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "org$dominio",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_org$dominio", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "org$unidadorganizacional",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_org$unidadorganizacional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_org$unidadorganizacional_org$dominio_DominioId",
                        column: x => x.DominioId,
                        principalTable: "org$dominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "org$usuariodominio",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_org$usuariodominio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_org$usuariodominio_org$dominio_DominioId",
                        column: x => x.DominioId,
                        principalTable: "org$dominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "org$usuariounidadorganizacional",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioId = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnidadOrganizacionalId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_org$usuariounidadorganizacional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_org$usuariounidadorganizacional_org$dominio_DominioId",
                        column: x => x.DominioId,
                        principalTable: "org$dominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_org$usuariounidadorganizacional_org$unidadorganizacional_Uni~",
                        column: x => x.UnidadOrganizacionalId,
                        principalTable: "org$unidadorganizacional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_org$unidadorganizacional_DominioId",
                table: "org$unidadorganizacional",
                column: "DominioId");

            migrationBuilder.CreateIndex(
                name: "IX_org$usuariodominio_DominioId",
                table: "org$usuariodominio",
                column: "DominioId");

            migrationBuilder.CreateIndex(
                name: "IX_org$usuariounidadorganizacional_DominioId",
                table: "org$usuariounidadorganizacional",
                column: "DominioId");

            migrationBuilder.CreateIndex(
                name: "IX_org$usuariounidadorganizacional_UnidadOrganizacionalId",
                table: "org$usuariounidadorganizacional",
                column: "UnidadOrganizacionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "org$usuariodominio");

            migrationBuilder.DropTable(
                name: "org$usuariounidadorganizacional");

            migrationBuilder.DropTable(
                name: "org$unidadorganizacional");

            migrationBuilder.DropTable(
                name: "org$dominio");
        }
    }
}
