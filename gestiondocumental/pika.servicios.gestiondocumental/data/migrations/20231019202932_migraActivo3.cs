using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pika.servicios.gestiondocumental.data.migrations
{
    public partial class migraActivo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContenidoId",
                table: "gd$activo",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "gd$activo",
                keyColumn: "ContenidoId",
                keyValue: null,
                column: "ContenidoId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ContenidoId",
                table: "gd$activo",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
