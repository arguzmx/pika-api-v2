using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pika.servicios.gestiondocumental.data.migrations
{
    public partial class ActivoReferencialArchivos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_gd$activo_ArchivoActualId",
                table: "gd$activo",
                column: "ArchivoActualId");

            migrationBuilder.CreateIndex(
                name: "IX_gd$activo_ArchivoOrigenId",
                table: "gd$activo",
                column: "ArchivoOrigenId");

            migrationBuilder.AddForeignKey(
                name: "FK_gd$activo_gd$archivo_ArchivoActualId",
                table: "gd$activo",
                column: "ArchivoActualId",
                principalTable: "gd$archivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_gd$activo_gd$archivo_ArchivoOrigenId",
                table: "gd$activo",
                column: "ArchivoOrigenId",
                principalTable: "gd$archivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gd$activo_gd$archivo_ArchivoActualId",
                table: "gd$activo");

            migrationBuilder.DropForeignKey(
                name: "FK_gd$activo_gd$archivo_ArchivoOrigenId",
                table: "gd$activo");

            migrationBuilder.DropIndex(
                name: "IX_gd$activo_ArchivoActualId",
                table: "gd$activo");

            migrationBuilder.DropIndex(
                name: "IX_gd$activo_ArchivoOrigenId",
                table: "gd$activo");
        }
    }
}
