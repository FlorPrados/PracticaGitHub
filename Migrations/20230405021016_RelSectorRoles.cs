using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpresaAPI.Migrations
{
    /// <inheritdoc />
    public partial class RelSectorRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_SectorId",
                table: "Roles",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Sectores_SectorId",
                table: "Roles",
                column: "SectorId",
                principalTable: "Sectores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Sectores_SectorId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_SectorId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Roles");
        }
    }
}
