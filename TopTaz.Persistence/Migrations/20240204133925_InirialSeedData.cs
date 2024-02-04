using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InirialSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CatalogBrands",
                columns: new[] { "Id", "Brand" },
                values: new object[,]
                {
                    { 1L, "سامسونگ" },
                    { 2L, "شیائومی " },
                    { 3L, "اپل" },
                    { 4L, "هوآوی" },
                    { 5L, "نوکیا " },
                    { 6L, "ال جی" }
                });

            migrationBuilder.InsertData(
                table: "CatalogTypes",
                columns: new[] { "Id", "ParentCatalogTypeId", "Type" },
                values: new object[] { 1L, null, "کالای دیجیتال" });

            migrationBuilder.InsertData(
                table: "CatalogTypes",
                columns: new[] { "Id", "ParentCatalogTypeId", "Type" },
                values: new object[] { 2L, 1L, "لوازم جانبی گوشی" });

            migrationBuilder.InsertData(
                table: "CatalogTypes",
                columns: new[] { "Id", "ParentCatalogTypeId", "Type" },
                values: new object[] { 3L, 2L, "پایه نگهدارنده گوشی" });

            migrationBuilder.InsertData(
                table: "CatalogTypes",
                columns: new[] { "Id", "ParentCatalogTypeId", "Type" },
                values: new object[] { 4L, 2L, "پاور بانک (شارژر همراه)" });

            migrationBuilder.InsertData(
                table: "CatalogTypes",
                columns: new[] { "Id", "ParentCatalogTypeId", "Type" },
                values: new object[] { 5L, 2L, "کیف و کاور گوشی" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CatalogBrands",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "CatalogBrands",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "CatalogBrands",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "CatalogBrands",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "CatalogBrands",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "CatalogBrands",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "CatalogTypes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "CatalogTypes",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "CatalogTypes",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "CatalogTypes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "CatalogTypes",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
