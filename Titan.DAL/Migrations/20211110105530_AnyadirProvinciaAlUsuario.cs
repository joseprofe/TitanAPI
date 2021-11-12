using Microsoft.EntityFrameworkCore.Migrations;

namespace Titan.DAL.Migrations
{
    public partial class AnyadirProvinciaAlUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ProvinciaId",
                table: "Usuarios",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Provincias_ProvinciaId",
                table: "Usuarios",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade,
                onUpdate: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Provincias_ProvinciaId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ProvinciaId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Usuarios");
        }
    }
}
