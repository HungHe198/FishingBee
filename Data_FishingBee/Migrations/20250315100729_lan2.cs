using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_FishingBee.Migrations
{
    public partial class lan2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Status" },
                values: new object[] { new Guid("bdd65fb7-1514-4f6d-8933-66247dc23396"), null, new DateTime(2025, 3, 15, 17, 7, 28, 860, DateTimeKind.Local).AddTicks(2519), null, null, null, "Electronics", "Active" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "Name", "Status" },
                values: new object[] { new Guid("fa24e457-1d0b-4b1b-aaa9-3f888d65fadc"), null, new DateTime(2025, 3, 15, 17, 7, 28, 860, DateTimeKind.Local).AddTicks(2329), null, "Apple", "Active" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Status" },
                values: new object[] { new Guid("85f6cbe0-2537-4453-a99d-5fcec49508bd"), new Guid("bdd65fb7-1514-4f6d-8933-66247dc23396"), null, new DateTime(2025, 3, 15, 17, 7, 28, 860, DateTimeKind.Local).AddTicks(2535), new Guid("fa24e457-1d0b-4b1b-aaa9-3f888d65fadc"), null, null, "Available" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Status" },
                values: new object[] { new Guid("c497b4f7-5555-441f-888a-478a90172f11"), new Guid("bdd65fb7-1514-4f6d-8933-66247dc23396"), null, new DateTime(2025, 3, 15, 17, 7, 28, 860, DateTimeKind.Local).AddTicks(2534), new Guid("fa24e457-1d0b-4b1b-aaa9-3f888d65fadc"), null, null, "Available" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("5be2b9d9-9c5f-40bb-bf8c-df7e109fe49f"), null, null, null, null, new DateTime(2025, 3, 15, 17, 7, 28, 860, DateTimeKind.Local).AddTicks(2554), null, null, null, "Sony Bravia 4K TV", 1499.99m, new Guid("85f6cbe0-2537-4453-a99d-5fcec49508bd"), "In Stock" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("606ec0f7-7760-4cfd-b9b3-be505636d03c"), null, null, null, null, new DateTime(2025, 3, 15, 17, 7, 28, 860, DateTimeKind.Local).AddTicks(2551), null, null, null, "iPhone 15 Pro", 999.99m, new Guid("c497b4f7-5555-441f-888a-478a90172f11"), "In Stock" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("aa530ad7-a7f1-4f37-ae75-9884e758a6d0"), null, null, null, null, new DateTime(2025, 3, 15, 17, 7, 28, 860, DateTimeKind.Local).AddTicks(2553), null, null, null, "Samsung Galaxy S23 Ultra", 1199.99m, new Guid("c497b4f7-5555-441f-888a-478a90172f11"), "In Stock" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("5be2b9d9-9c5f-40bb-bf8c-df7e109fe49f"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("606ec0f7-7760-4cfd-b9b3-be505636d03c"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("aa530ad7-a7f1-4f37-ae75-9884e758a6d0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("85f6cbe0-2537-4453-a99d-5fcec49508bd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c497b4f7-5555-441f-888a-478a90172f11"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bdd65fb7-1514-4f6d-8933-66247dc23396"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("fa24e457-1d0b-4b1b-aaa9-3f888d65fadc"));
        }
    }
}
