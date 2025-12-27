using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    public partial class Storeadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stores_AdminId",
                table: "Stores");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Admins",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AdminId",
                table: "Stores",
                column: "AdminId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stores_AdminId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Admins");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AdminId",
                table: "Stores",
                column: "AdminId");
        }
    }
}
