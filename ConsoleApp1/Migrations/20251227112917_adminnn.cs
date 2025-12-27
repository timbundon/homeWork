using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    public partial class adminnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stores_AdminId",
                table: "Stores");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AdminId",
                table: "Stores",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_StoreId",
                table: "Admins",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Stores_StoreId",
                table: "Admins",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Stores_StoreId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Stores_AdminId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Admins_StoreId",
                table: "Admins");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AdminId",
                table: "Stores",
                column: "AdminId",
                unique: true);
        }
    }
}
