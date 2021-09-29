using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPet.App.Persistencia.Migrations
{
    public partial class Inicial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mascota_id",
                table: "Citas");

            migrationBuilder.AddColumn<int>(
                name: "mascotaid",
                table: "Citas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_mascotaid",
                table: "Citas",
                column: "mascotaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Mascotas_mascotaid",
                table: "Citas",
                column: "mascotaid",
                principalTable: "Mascotas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Mascotas_mascotaid",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_mascotaid",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "mascotaid",
                table: "Citas");

            migrationBuilder.AddColumn<int>(
                name: "mascota_id",
                table: "Citas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
