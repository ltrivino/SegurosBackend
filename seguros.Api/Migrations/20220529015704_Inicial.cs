using Microsoft.EntityFrameworkCore.Migrations;

namespace Seguros.Api.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asegurados",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    cedula = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asegurados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Seguros",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    prima = table.Column<double>(nullable: false),
                    suma_asegurada = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguros", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AseguradosSeguros",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aseguradosId = table.Column<int>(nullable: false),
                    segurosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AseguradosSeguros", x => x.id);
                    table.ForeignKey(
                        name: "FK_AseguradosSeguros_Asegurados_aseguradosId",
                        column: x => x.aseguradosId,
                        principalTable: "Asegurados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AseguradosSeguros_Seguros_segurosId",
                        column: x => x.segurosId,
                        principalTable: "Seguros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AseguradosSeguros_aseguradosId",
                table: "AseguradosSeguros",
                column: "aseguradosId");

            migrationBuilder.CreateIndex(
                name: "IX_AseguradosSeguros_segurosId",
                table: "AseguradosSeguros",
                column: "segurosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AseguradosSeguros");

            migrationBuilder.DropTable(
                name: "Asegurados");

            migrationBuilder.DropTable(
                name: "Seguros");
        }
    }
}
