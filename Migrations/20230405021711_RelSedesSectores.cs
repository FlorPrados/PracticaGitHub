using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpresaAPI.Migrations
{
    /// <inheritdoc />
    public partial class RelSedesSectores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectorSede",
                columns: table => new
                {
                    SectoresId = table.Column<int>(type: "int", nullable: false),
                    SedesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorSede", x => new { x.SectoresId, x.SedesId });
                    table.ForeignKey(
                        name: "FK_SectorSede_Sectores_SectoresId",
                        column: x => x.SectoresId,
                        principalTable: "Sectores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectorSede_Sedes_SedesId",
                        column: x => x.SedesId,
                        principalTable: "Sedes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectorSede_SedesId",
                table: "SectorSede",
                column: "SedesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectorSede");
        }
    }
}
