using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    public partial class fav1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Customers_LovedById",
                table: "CustomerProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Products_FavoritesId",
                table: "CustomerProduct");

            migrationBuilder.RenameColumn(
                name: "LovedById",
                table: "CustomerProduct",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "FavoritesId",
                table: "CustomerProduct",
                newName: "CustomersId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProduct_LovedById",
                table: "CustomerProduct",
                newName: "IX_CustomerProduct_ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Customers_ProductsId",
                table: "CustomerProduct",
                column: "ProductsId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Products_CustomersId",
                table: "CustomerProduct",
                column: "CustomersId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Customers_ProductsId",
                table: "CustomerProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Products_CustomersId",
                table: "CustomerProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "CustomerProduct",
                newName: "LovedById");

            migrationBuilder.RenameColumn(
                name: "CustomersId",
                table: "CustomerProduct",
                newName: "FavoritesId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProduct_ProductsId",
                table: "CustomerProduct",
                newName: "IX_CustomerProduct_LovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Customers_LovedById",
                table: "CustomerProduct",
                column: "LovedById",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Products_FavoritesId",
                table: "CustomerProduct",
                column: "FavoritesId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
