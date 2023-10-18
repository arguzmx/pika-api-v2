using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pika.servicios.contenido.data.migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contenido$volumen",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UOrgId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
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
                    table.PrimaryKey("PK_contenido$volumen", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contenido$volumen");
        }
    }
}
