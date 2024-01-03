using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopTaz.Persistence.Migrations
{
    public partial class AuditShadowProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDeleted",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Users");
        }
    }
}
