using Microsoft.EntityFrameworkCore.Migrations;

namespace Kingpim.DAL.Migrations
{
    public partial class Added_SystemAttributeModel_And_To_ProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SystemAttributeId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SystemAttributeId",
                table: "Products",
                column: "SystemAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SystemAttributes_SystemAttributeId",
                table: "Products",
                column: "SystemAttributeId",
                principalTable: "SystemAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SystemAttributes_SystemAttributeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SystemAttributeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SystemAttributeId",
                table: "Products");
        }
    }
}
