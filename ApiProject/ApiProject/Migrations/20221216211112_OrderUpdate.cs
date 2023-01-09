using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProject.Migrations
{
    /// <inheritdoc />
    public partial class OrderUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Buyerid",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Buyerid",
                table: "Orders",
                column: "Buyerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Buyers_Buyerid",
                table: "Orders",
                column: "Buyerid",
                principalTable: "Buyers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Buyers_Buyerid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Buyerid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Buyerid",
                table: "Orders");
        }
    }
}
