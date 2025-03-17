using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_FishingBee.Migrations
{
    public partial class AddUserTypeToAdmins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("4fae00b8-3b6d-4d27-b8ea-63adf7821fb3"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("6e53f579-a670-418e-84da-f41609b1b194"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("bdac0721-dd45-4c82-9353-0e53c67c9e98"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ecace06-84d9-49e5-a6e4-30556a18082e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de0c189d-960e-44fe-be24-1a1d6a190714"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33857c4e-ae79-48d9-bcf0-d677c5618150"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("f56c28e6-2350-4e1f-9b07-fea667c4be5a"));

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Status" },
                values: new object[] { new Guid("9e2619b2-57d1-486a-a1e2-1cd73cf19206"), null, new DateTime(2025, 3, 17, 13, 49, 29, 995, DateTimeKind.Local).AddTicks(5071), null, null, null, "Electronics", "Active" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "Name", "Status" },
                values: new object[] { new Guid("bc5c6a57-ce9e-4b4c-9461-9f0c11f4398d"), null, new DateTime(2025, 3, 17, 13, 49, 29, 995, DateTimeKind.Local).AddTicks(4816), null, "Apple", "Active" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Status" },
                values: new object[] { new Guid("0a13c176-7fe3-453d-80db-d38d7d83b6b4"), new Guid("9e2619b2-57d1-486a-a1e2-1cd73cf19206"), null, new DateTime(2025, 3, 17, 13, 49, 29, 995, DateTimeKind.Local).AddTicks(5143), new Guid("bc5c6a57-ce9e-4b4c-9461-9f0c11f4398d"), null, null, "Available" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Status" },
                values: new object[] { new Guid("f6d1fcf1-0c8d-4bdb-b444-4dd14a3b3b4d"), new Guid("9e2619b2-57d1-486a-a1e2-1cd73cf19206"), null, new DateTime(2025, 3, 17, 13, 49, 29, 995, DateTimeKind.Local).AddTicks(5141), new Guid("bc5c6a57-ce9e-4b4c-9461-9f0c11f4398d"), null, null, "Available" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("07c83612-7f46-430e-b816-0143d902c9ad"), null, null, null, null, new DateTime(2025, 3, 17, 13, 49, 29, 995, DateTimeKind.Local).AddTicks(5172), null, null, null, "Samsung Galaxy S23 Ultra", 1199.99m, new Guid("f6d1fcf1-0c8d-4bdb-b444-4dd14a3b3b4d"), "In Stock" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("53a99026-72a5-4c1b-a08c-114dae1647e1"), null, null, null, null, new DateTime(2025, 3, 17, 13, 49, 29, 995, DateTimeKind.Local).AddTicks(5174), null, null, null, "Sony Bravia 4K TV", 1499.99m, new Guid("0a13c176-7fe3-453d-80db-d38d7d83b6b4"), "In Stock" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("e8810b81-24d8-48f7-b179-3ed285bb3957"), null, null, null, null, new DateTime(2025, 3, 17, 13, 49, 29, 995, DateTimeKind.Local).AddTicks(5170), null, null, null, "iPhone 15 Pro", 999.99m, new Guid("f6d1fcf1-0c8d-4bdb-b444-4dd14a3b3b4d"), "In Stock" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("07c83612-7f46-430e-b816-0143d902c9ad"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("53a99026-72a5-4c1b-a08c-114dae1647e1"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("e8810b81-24d8-48f7-b179-3ed285bb3957"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a13c176-7fe3-453d-80db-d38d7d83b6b4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f6d1fcf1-0c8d-4bdb-b444-4dd14a3b3b4d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9e2619b2-57d1-486a-a1e2-1cd73cf19206"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("bc5c6a57-ce9e-4b4c-9461-9f0c11f4398d"));

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Admins");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Status" },
                values: new object[] { new Guid("33857c4e-ae79-48d9-bcf0-d677c5618150"), null, new DateTime(2025, 3, 17, 11, 13, 49, 441, DateTimeKind.Local).AddTicks(3675), null, null, null, "Electronics", "Active" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "Name", "Status" },
                values: new object[] { new Guid("f56c28e6-2350-4e1f-9b07-fea667c4be5a"), null, new DateTime(2025, 3, 17, 11, 13, 49, 441, DateTimeKind.Local).AddTicks(3464), null, "Apple", "Active" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Status" },
                values: new object[] { new Guid("8ecace06-84d9-49e5-a6e4-30556a18082e"), new Guid("33857c4e-ae79-48d9-bcf0-d677c5618150"), null, new DateTime(2025, 3, 17, 11, 13, 49, 441, DateTimeKind.Local).AddTicks(3693), new Guid("f56c28e6-2350-4e1f-9b07-fea667c4be5a"), null, null, "Available" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Status" },
                values: new object[] { new Guid("de0c189d-960e-44fe-be24-1a1d6a190714"), new Guid("33857c4e-ae79-48d9-bcf0-d677c5618150"), null, new DateTime(2025, 3, 17, 11, 13, 49, 441, DateTimeKind.Local).AddTicks(3694), new Guid("f56c28e6-2350-4e1f-9b07-fea667c4be5a"), null, null, "Available" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("4fae00b8-3b6d-4d27-b8ea-63adf7821fb3"), null, null, null, null, new DateTime(2025, 3, 17, 11, 13, 49, 441, DateTimeKind.Local).AddTicks(3732), null, null, null, "Sony Bravia 4K TV", 1499.99m, new Guid("de0c189d-960e-44fe-be24-1a1d6a190714"), "In Stock" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("6e53f579-a670-418e-84da-f41609b1b194"), null, null, null, null, new DateTime(2025, 3, 17, 11, 13, 49, 441, DateTimeKind.Local).AddTicks(3717), null, null, null, "Samsung Galaxy S23 Ultra", 1199.99m, new Guid("8ecace06-84d9-49e5-a6e4-30556a18082e"), "In Stock" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("bdac0721-dd45-4c82-9353-0e53c67c9e98"), null, null, null, null, new DateTime(2025, 3, 17, 11, 13, 49, 441, DateTimeKind.Local).AddTicks(3715), null, null, null, "iPhone 15 Pro", 999.99m, new Guid("8ecace06-84d9-49e5-a6e4-30556a18082e"), "In Stock" });
        }
    }
}
