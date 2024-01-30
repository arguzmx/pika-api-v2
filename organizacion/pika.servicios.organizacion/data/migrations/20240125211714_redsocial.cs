using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pika.servicios.organizacion.data.migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:organizacion/pika.servicios.organizacion/data/migrations/20240130202509_telefono1.cs
    public partial class telefono1 : Migration
========
    public partial class redsocial : Migration
>>>>>>>> fb8c905 (PV2-44_ApiEntidadRedSocialCatalogoTipoArchivo):organizacion/pika.servicios.organizacion/data/migrations/20240125211714_redsocial.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
<<<<<<<< HEAD:organizacion/pika.servicios.organizacion/data/migrations/20240130202509_telefono1.cs
                name: "org$direccionpostal",
========
                name: "org$catalogos",
>>>>>>>> fb8c905 (PV2-44_ApiEntidadRedSocialCatalogoTipoArchivo):organizacion/pika.servicios.organizacion/data/migrations/20240125211714_redsocial.cs
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
<<<<<<<< HEAD:organizacion/pika.servicios.organizacion/data/migrations/20240130202509_telefono1.cs
                    Calle = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NoInterior = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NoExterior = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CP = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pais = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Referencia = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UOrgId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_org$direccionpostal", x => x.Id);
========
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
                    table.PrimaryKey("PK_org$catalogos", x => x.Id);
>>>>>>>> fb8c905 (PV2-44_ApiEntidadRedSocialCatalogoTipoArchivo):organizacion/pika.servicios.organizacion/data/migrations/20240125211714_redsocial.cs
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "org$dominio",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_org$dominio", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "org$puesto",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Clave = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UOrgId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_org$puesto", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
<<<<<<<< HEAD:organizacion/pika.servicios.organizacion/data/migrations/20240130202509_telefono1.cs
                name: "org$telefono",
========
                name: "org$i18ncatalogos",
>>>>>>>> fb8c905 (PV2-44_ApiEntidadRedSocialCatalogoTipoArchivo):organizacion/pika.servicios.organizacion/data/migrations/20240125211714_redsocial.cs
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
<<<<<<<< HEAD:organizacion/pika.servicios.organizacion/data/migrations/20240130202509_telefono1.cs
                    Numero = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Extension = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Horario = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
========
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
                    table.PrimaryKey("PK_org$i18ncatalogos", x => new { x.Id, x.DominioId, x.UnidadOrganizacionalId, x.Idioma });
                    table.ForeignKey(
                        name: "FK_org$i18ncatalogos_org$catalogos_ElementoCatalogoId",
                        column: x => x.ElementoCatalogoId,
                        principalTable: "org$catalogos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "org$redsocial",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoRedSocialId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
>>>>>>>> fb8c905 (PV2-44_ApiEntidadRedSocialCatalogoTipoArchivo):organizacion/pika.servicios.organizacion/data/migrations/20240125211714_redsocial.cs
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UOrgId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
<<<<<<<< HEAD:organizacion/pika.servicios.organizacion/data/migrations/20240130202509_telefono1.cs
                    table.PrimaryKey("PK_org$telefono", x => x.Id);
========
                    table.PrimaryKey("PK_org$redsocial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_org$redsocial_org$catalogos_TipoRedSocialId",
                        column: x => x.TipoRedSocialId,
                        principalTable: "org$catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
>>>>>>>> fb8c905 (PV2-44_ApiEntidadRedSocialCatalogoTipoArchivo):organizacion/pika.servicios.organizacion/data/migrations/20240125211714_redsocial.cs
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "org$unidadorg",
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
                    table.PrimaryKey("PK_org$unidadorg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_org$unidadorg_org$dominio_DominioId",
                        column: x => x.DominioId,
                        principalTable: "org$dominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "org$usuariounidadorg",
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
                    table.PrimaryKey("PK_org$usuariounidadorg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_org$usuariounidadorg_org$dominio_DominioId",
                        column: x => x.DominioId,
                        principalTable: "org$dominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_org$usuariounidadorg_org$unidadorg_UnidadOrganizacionalId",
                        column: x => x.UnidadOrganizacionalId,
                        principalTable: "org$unidadorg",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_org$catalogos_CatalogoId",
                table: "org$catalogos",
                column: "CatalogoId");

            migrationBuilder.CreateIndex(
                name: "IX_org$i18ncatalogos_CatalogoId_Idioma",
                table: "org$i18ncatalogos",
                columns: new[] { "CatalogoId", "Idioma" });

            migrationBuilder.CreateIndex(
                name: "IX_org$i18ncatalogos_ElementoCatalogoId",
                table: "org$i18ncatalogos",
                column: "ElementoCatalogoId");

            migrationBuilder.CreateIndex(
                name: "IX_org$redsocial_TipoRedSocialId",
                table: "org$redsocial",
                column: "TipoRedSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_org$unidadorg_DominioId",
                table: "org$unidadorg",
                column: "DominioId");

            migrationBuilder.CreateIndex(
                name: "IX_org$usuariodominio_DominioId",
                table: "org$usuariodominio",
                column: "DominioId");

            migrationBuilder.CreateIndex(
                name: "IX_org$usuariounidadorg_DominioId",
                table: "org$usuariounidadorg",
                column: "DominioId");

            migrationBuilder.CreateIndex(
                name: "IX_org$usuariounidadorg_UnidadOrganizacionalId",
                table: "org$usuariounidadorg",
                column: "UnidadOrganizacionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
<<<<<<<< HEAD:organizacion/pika.servicios.organizacion/data/migrations/20240130202509_telefono1.cs
                name: "org$direccionpostal");
========
                name: "org$i18ncatalogos");
>>>>>>>> fb8c905 (PV2-44_ApiEntidadRedSocialCatalogoTipoArchivo):organizacion/pika.servicios.organizacion/data/migrations/20240125211714_redsocial.cs

            migrationBuilder.DropTable(
                name: "org$puesto");

            migrationBuilder.DropTable(
<<<<<<<< HEAD:organizacion/pika.servicios.organizacion/data/migrations/20240130202509_telefono1.cs
                name: "org$telefono");
========
                name: "org$redsocial");
>>>>>>>> fb8c905 (PV2-44_ApiEntidadRedSocialCatalogoTipoArchivo):organizacion/pika.servicios.organizacion/data/migrations/20240125211714_redsocial.cs

            migrationBuilder.DropTable(
                name: "org$usuariodominio");

            migrationBuilder.DropTable(
                name: "org$usuariounidadorg");

            migrationBuilder.DropTable(
                name: "org$catalogos");

            migrationBuilder.DropTable(
                name: "org$unidadorg");

            migrationBuilder.DropTable(
                name: "org$dominio");
        }
    }
}
