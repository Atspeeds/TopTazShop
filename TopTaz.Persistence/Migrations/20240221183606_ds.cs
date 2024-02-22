using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 21, 22, 6, 4, 962, DateTimeKind.Local).AddTicks(6068));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "CatalogTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "CatalogTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "CatalogTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 21, 22, 6, 4, 961, DateTimeKind.Local).AddTicks(947));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "CatalogItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 21, 22, 6, 4, 962, DateTimeKind.Local).AddTicks(637));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "CatalogItemImage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 21, 22, 6, 4, 961, DateTimeKind.Local).AddTicks(6755));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "CatalogItemFeature",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 21, 22, 6, 4, 960, DateTimeKind.Local).AddTicks(8003));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "CatalogBrands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "CatalogBrands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "CatalogBrands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 21, 22, 6, 4, 936, DateTimeKind.Local).AddTicks(239));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Baskets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Baskets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Baskets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 21, 22, 6, 4, 960, DateTimeKind.Local).AddTicks(3481));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "BasketItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "CatalogTypes");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "CatalogTypes");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "CatalogTypes");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "CatalogTypes");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "CatalogItemImage");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "CatalogItemImage");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "CatalogItemImage");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "CatalogItemImage");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "CatalogItemFeature");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "CatalogItemFeature");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "CatalogItemFeature");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "CatalogItemFeature");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "CatalogBrands");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "CatalogBrands");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "CatalogBrands");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "CatalogBrands");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "BasketItems");
        }
    }
}
