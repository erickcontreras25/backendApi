using Microsoft.EntityFrameworkCore.Migrations;

namespace apiProyecto.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complejo",
                columns: table => new
                {
                    idComplejo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Latitud = table.Column<decimal>(type: "decimal", nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal", nullable: false),
                    CantidadDeCanchas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complejo", x => x.idComplejo);
                });

            migrationBuilder.CreateTable(
                name: "Canchas",
                columns: table => new
                {
                    idCancha = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    EstadoCancha = table.Column<decimal>(type: "decimal", nullable: false),
                    idComplejo = table.Column<int>(type: "int", nullable: false),
                    complejoidComplejo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canchas", x => x.idCancha);
                    table.ForeignKey(
                        name: "FK_Canchas_Complejo_complejoidComplejo",
                        column: x => x.complejoidComplejo,
                        principalTable: "Complejo",
                        principalColumn: "idComplejo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canchas_complejoidComplejo",
                table: "Canchas",
                column: "complejoidComplejo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canchas");

            migrationBuilder.DropTable(
                name: "Complejo");
        }
    }
}
