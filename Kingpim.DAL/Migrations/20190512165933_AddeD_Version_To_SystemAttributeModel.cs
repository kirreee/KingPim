using Microsoft.EntityFrameworkCore.Migrations;

namespace Kingpim.DAL.Migrations
{
    public partial class AddeD_Version_To_SystemAttributeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VersioNumber",
                table: "SystemAttributes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "SystemAttributes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "SystemAttributes");

            migrationBuilder.AlterColumn<int>(
                name: "VersioNumber",
                table: "SystemAttributes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
