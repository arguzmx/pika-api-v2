using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pika.servicios.gestiondocumental.data.migrations
{
    /// <inheritdoc />
    public partial class addRelArchivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_gd_$activo_SerieDocumental_Id",
                table: "gd$activo",
                column: "SerieDocumentalId");

            migrationBuilder.CreateIndex(
                name: "IX_gd_$activo_TipoArchivoActual_Id",
                table: "gd$activo",
                column: "TipoArchivoActualId");

            migrationBuilder.CreateIndex(
                name: "IX_gd_$activo_UnidadAdministrativa_Id",
                table: "gd$activo",
                column: "UnidadAdministrativaId");

            migrationBuilder.AddForeignKey(
                name: "FK_gd_$activo_gd$archivo_Archivo_Actual_Id",
                table: "gd$activo",
                column: "ArchivoActualId",
                principalTable: "gd$archivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_gd$activo_gd_$archivo_Archivo_Origen_Id",
                table: "gd$activo",
                column: "ArchivoOrigenId",
                principalTable: "gd$archivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);   
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gd$activo_gd_$archivo_Archivo_Actual_Id",
                table: "gd$activo");

            migrationBuilder.DropForeignKey(
                name: "FK_gd$activo_gd_$archivo_Archivo_Origen_Id",
                table: "gd$activo");

            migrationBuilder.DropForeignKey(
                name: "FK_gd$activo_gd_$catalogos_Tipo_Archivo_Actual_Id",
                table: "gd$activo");

            migrationBuilder.DropForeignKey(
                name: "FK_gd$activo_gd_$seriedocumental_Serie_Documental_Id",
                table: "gd$activo");

            migrationBuilder.DropForeignKey(
                name: "FK_gd$activo_gd_$unidad_Administrativa_Unidad_Administrativa_Id",
                table: "gd$activo");

         

         
        }
    }
}
