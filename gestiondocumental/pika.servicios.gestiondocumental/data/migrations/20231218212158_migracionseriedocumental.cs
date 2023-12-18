using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pika.servicios.gestiondocumental.data.migrations
{
    /// <inheritdoc />
    public partial class migracionseriedocumental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activo_CuadroClasificacion_CuadroClasificacionId",
                table: "Activo");

            migrationBuilder.DropForeignKey(
                name: "FK_Activo_gd$archivo_ArchivoActualId",
                table: "Activo");

            migrationBuilder.DropForeignKey(
                name: "FK_Activo_gd$archivo_ArchivoOrigenId",
                table: "Activo");

            migrationBuilder.DropForeignKey(
                name: "FK_gd$seriedocumental_CuadroClasificacion_CuadroClasificacionId",
                table: "gd$seriedocumental");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuadroClasificacion",
                table: "CuadroClasificacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activo",
                table: "Activo");

            migrationBuilder.DropIndex(
                name: "IX_Activo_ArchivoActualId",
                table: "Activo");

            migrationBuilder.DropIndex(
                name: "IX_Activo_ArchivoOrigenId",
                table: "Activo");

            migrationBuilder.RenameTable(
                name: "CuadroClasificacion",
                newName: "gd$cuadroclasificacion");

            migrationBuilder.RenameTable(
                name: "Activo",
                newName: "gd$activo");

            migrationBuilder.RenameIndex(
                name: "IX_Activo_CuadroClasificacionId",
                table: "gd$activo",
                newName: "IX_gd$activo_CuadroClasificacionId");

            migrationBuilder.AlterColumn<string>(
                name: "UOrgId",
                table: "gd$cuadroclasificacion",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "gd$cuadroclasificacion",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DominioId",
                table: "gd$cuadroclasificacion",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ZonaAlmacenId",
                table: "gd$activo",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 128,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "gd$activo",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UnidadOrganizacionalId",
                table: "gd$activo",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UnidadAdministrativaId",
                table: "gd$activo",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UbicacionRack",
                table: "gd$activo",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 200,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UbicacionCaja",
                table: "gd$activo",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "gd$activo",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DominioId",
                table: "gd$activo",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ContenidoId",
                table: "gd$activo",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 128,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoOptico",
                table: "gd$activo",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 500,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoElectronico",
                table: "gd$activo",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 500,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Asunto",
                table: "gd$activo",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 2000,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "AlmacenArchivoId",
                table: "gd$activo",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 128,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gd$cuadroclasificacion",
                table: "gd$cuadroclasificacion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gd$activo",
                table: "gd$activo",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AlmacenArchivo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Clave = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArchivoId = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ubicacion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlmacenArchivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlmacenArchivo_gd$archivo_ArchivoId",
                        column: x => x.ArchivoId,
                        principalTable: "gd$archivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AlmacenArchivo_ArchivoId",
                table: "AlmacenArchivo",
                column: "ArchivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_gd$activo_gd$cuadroclasificacion_CuadroClasificacionId",
                table: "gd$activo",
                column: "CuadroClasificacionId",
                principalTable: "gd$cuadroclasificacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_gd$seriedocumental_gd$cuadroclasificacion_CuadroClasificacio~",
                table: "gd$seriedocumental",
                column: "CuadroClasificacionId",
                principalTable: "gd$cuadroclasificacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gd$activo_gd$cuadroclasificacion_CuadroClasificacionId",
                table: "gd$activo");

            migrationBuilder.DropForeignKey(
                name: "FK_gd$seriedocumental_gd$cuadroclasificacion_CuadroClasificacio~",
                table: "gd$seriedocumental");

            migrationBuilder.DropTable(
                name: "AlmacenArchivo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gd$cuadroclasificacion",
                table: "gd$cuadroclasificacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gd$activo",
                table: "gd$activo");

            migrationBuilder.RenameTable(
                name: "gd$cuadroclasificacion",
                newName: "CuadroClasificacion");

            migrationBuilder.RenameTable(
                name: "gd$activo",
                newName: "Activo");

            migrationBuilder.RenameIndex(
                name: "IX_gd$activo_CuadroClasificacionId",
                table: "Activo",
                newName: "IX_Activo_CuadroClasificacionId");

            migrationBuilder.AlterColumn<string>(
                name: "UOrgId",
                table: "CuadroClasificacion",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "CuadroClasificacion",
                type: "longtext",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DominioId",
                table: "CuadroClasificacion",
                type: "longtext",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ZonaAlmacenId",
                table: "Activo",
                type: "longtext",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Activo",
                type: "longtext",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UnidadOrganizacionalId",
                table: "Activo",
                type: "longtext",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UnidadAdministrativaId",
                table: "Activo",
                type: "longtext",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UbicacionRack",
                table: "Activo",
                type: "longtext",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UbicacionCaja",
                table: "Activo",
                type: "longtext",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Activo",
                type: "longtext",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DominioId",
                table: "Activo",
                type: "longtext",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ContenidoId",
                table: "Activo",
                type: "longtext",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoOptico",
                table: "Activo",
                type: "longtext",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoElectronico",
                table: "Activo",
                type: "longtext",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Asunto",
                table: "Activo",
                type: "longtext",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "AlmacenArchivoId",
                table: "Activo",
                type: "longtext",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuadroClasificacion",
                table: "CuadroClasificacion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activo",
                table: "Activo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Activo_ArchivoActualId",
                table: "Activo",
                column: "ArchivoActualId");

            migrationBuilder.CreateIndex(
                name: "IX_Activo_ArchivoOrigenId",
                table: "Activo",
                column: "ArchivoOrigenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activo_CuadroClasificacion_CuadroClasificacionId",
                table: "Activo",
                column: "CuadroClasificacionId",
                principalTable: "CuadroClasificacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activo_gd$archivo_ArchivoActualId",
                table: "Activo",
                column: "ArchivoActualId",
                principalTable: "gd$archivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activo_gd$archivo_ArchivoOrigenId",
                table: "Activo",
                column: "ArchivoOrigenId",
                principalTable: "gd$archivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_gd$seriedocumental_CuadroClasificacion_CuadroClasificacionId",
                table: "gd$seriedocumental",
                column: "CuadroClasificacionId",
                principalTable: "CuadroClasificacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
