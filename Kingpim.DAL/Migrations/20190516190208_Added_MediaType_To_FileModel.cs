using Microsoft.EntityFrameworkCore.Migrations;

namespace Kingpim.DAL.Migrations
{
    public partial class Added_MediaType_To_FileModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltText",
                table: "Files",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaType",
                table: "Files",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltText",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "MediaType",
                table: "Files");
        }
    }
}
