using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopTaz.Persistence.Migrations
{
    public partial class OprationDiscountOnEntitys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 96, DateTimeKind.Local).AddTicks(3432),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 549, DateTimeKind.Local).AddTicks(807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 95, DateTimeKind.Local).AddTicks(9292),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 548, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 94, DateTimeKind.Local).AddTicks(8403),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 548, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.AddColumn<long>(
                name: "AppliedDiscountId",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 95, DateTimeKind.Local).AddTicks(5387),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 548, DateTimeKind.Local).AddTicks(5782));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 94, DateTimeKind.Local).AddTicks(1020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 547, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 93, DateTimeKind.Local).AddTicks(6700),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 547, DateTimeKind.Local).AddTicks(6534));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 92, DateTimeKind.Local).AddTicks(5730),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 546, DateTimeKind.Local).AddTicks(7812));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 93, DateTimeKind.Local).AddTicks(3474),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 547, DateTimeKind.Local).AddTicks(3889));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 93, DateTimeKind.Local).AddTicks(26),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 547, DateTimeKind.Local).AddTicks(1636));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 92, DateTimeKind.Local).AddTicks(1715),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 546, DateTimeKind.Local).AddTicks(5066));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 77, DateTimeKind.Local).AddTicks(9572),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 538, DateTimeKind.Local).AddTicks(1581));

            migrationBuilder.AddColumn<long>(
                name: "AppliedDiscountId",
                table: "Baskets",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountAmount",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 91, DateTimeKind.Local).AddTicks(6817),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 546, DateTimeKind.Local).AddTicks(2436));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppliedDiscountId",
                table: "Orders",
                column: "AppliedDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_AppliedDiscountId",
                table: "Baskets",
                column: "AppliedDiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Discounts_AppliedDiscountId",
                table: "Baskets",
                column: "AppliedDiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Discounts_AppliedDiscountId",
                table: "Orders",
                column: "AppliedDiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Discounts_AppliedDiscountId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Discounts_AppliedDiscountId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AppliedDiscountId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_AppliedDiscountId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "AppliedDiscountId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AppliedDiscountId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Baskets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 549, DateTimeKind.Local).AddTicks(807),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 96, DateTimeKind.Local).AddTicks(3432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 548, DateTimeKind.Local).AddTicks(8383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 95, DateTimeKind.Local).AddTicks(9292));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 548, DateTimeKind.Local).AddTicks(2295),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 94, DateTimeKind.Local).AddTicks(8403));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 548, DateTimeKind.Local).AddTicks(5782),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 95, DateTimeKind.Local).AddTicks(5387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 547, DateTimeKind.Local).AddTicks(9464),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 94, DateTimeKind.Local).AddTicks(1020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 547, DateTimeKind.Local).AddTicks(6534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 93, DateTimeKind.Local).AddTicks(6700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 546, DateTimeKind.Local).AddTicks(7812),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 92, DateTimeKind.Local).AddTicks(5730));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 547, DateTimeKind.Local).AddTicks(3889),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 93, DateTimeKind.Local).AddTicks(3474));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 547, DateTimeKind.Local).AddTicks(1636),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 93, DateTimeKind.Local).AddTicks(26));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 546, DateTimeKind.Local).AddTicks(5066),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 92, DateTimeKind.Local).AddTicks(1715));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 538, DateTimeKind.Local).AddTicks(1581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 77, DateTimeKind.Local).AddTicks(9572));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 17, 20, 42, 546, DateTimeKind.Local).AddTicks(2436),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 18, 29, 6, 91, DateTimeKind.Local).AddTicks(6817));
        }
    }
}
