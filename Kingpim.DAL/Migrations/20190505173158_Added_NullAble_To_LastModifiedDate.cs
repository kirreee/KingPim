using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kingpim.DAL.Migrations
{
    public partial class Added_NullAble_To_LastModifiedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Attributes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Attributes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Attributes");
        }
    }
}
