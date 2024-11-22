using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopECommerce.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderLaptopToDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLaptop_Laptops_LaptopId",
                table: "OrderLaptop");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLaptop_Orders_OrderId",
                table: "OrderLaptop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLaptop",
                table: "OrderLaptop");

            migrationBuilder.RenameTable(
                name: "OrderLaptop",
                newName: "OrderLaptops");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLaptop_OrderId",
                table: "OrderLaptops",
                newName: "IX_OrderLaptops_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLaptop_LaptopId",
                table: "OrderLaptops",
                newName: "IX_OrderLaptops_LaptopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLaptops",
                table: "OrderLaptops",
                column: "OrderLaptopId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLaptops_Laptops_LaptopId",
                table: "OrderLaptops",
                column: "LaptopId",
                principalTable: "Laptops",
                principalColumn: "LaptopId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLaptops_Orders_OrderId",
                table: "OrderLaptops",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLaptops_Laptops_LaptopId",
                table: "OrderLaptops");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLaptops_Orders_OrderId",
                table: "OrderLaptops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLaptops",
                table: "OrderLaptops");

            migrationBuilder.RenameTable(
                name: "OrderLaptops",
                newName: "OrderLaptop");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLaptops_OrderId",
                table: "OrderLaptop",
                newName: "IX_OrderLaptop_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLaptops_LaptopId",
                table: "OrderLaptop",
                newName: "IX_OrderLaptop_LaptopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLaptop",
                table: "OrderLaptop",
                column: "OrderLaptopId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLaptop_Laptops_LaptopId",
                table: "OrderLaptop",
                column: "LaptopId",
                principalTable: "Laptops",
                principalColumn: "LaptopId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLaptop_Orders_OrderId",
                table: "OrderLaptop",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
