using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_FishingBee.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("08cd05ae-e8ab-40a9-aeb4-a8104b984777"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("5d12b5ac-ca43-42ff-9233-1d8ab9f91dfc"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("5ebc808f-c931-418e-b14a-261767c30d9b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a6d2215-6248-4be2-ba14-bf952e6d16fd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7e19e53c-0742-4c73-bdde-53f447057193"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ae56a447-3ea9-47c4-aa70-75f769dd93d6"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("e597d363-8d6b-4135-994b-abd0bcfe434b"));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Status" },
                values: new object[] { new Guid("e728cf11-e042-48bc-a7be-59ae8393287e"), null, new DateTime(2025, 3, 18, 9, 24, 38, 405, DateTimeKind.Local).AddTicks(4232), null, null, null, "Electronics", "Active" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "Name", "Status" },
                values: new object[] { new Guid("da8545cb-1cf9-48eb-b854-b7df11e61073"), null, new DateTime(2025, 3, 18, 9, 24, 38, 405, DateTimeKind.Local).AddTicks(3931), null, "Apple", "Active" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Status" },
                values: new object[] { new Guid("5670bac6-45e8-4bf3-9aeb-d8fd474a6616"), new Guid("e728cf11-e042-48bc-a7be-59ae8393287e"), null, new DateTime(2025, 3, 18, 9, 24, 38, 405, DateTimeKind.Local).AddTicks(4260), new Guid("da8545cb-1cf9-48eb-b854-b7df11e61073"), null, null, "Available" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Status" },
                values: new object[] { new Guid("aca6ba91-6ec0-4493-aced-b3e388de9a5f"), new Guid("e728cf11-e042-48bc-a7be-59ae8393287e"), null, new DateTime(2025, 3, 18, 9, 24, 38, 405, DateTimeKind.Local).AddTicks(4259), new Guid("da8545cb-1cf9-48eb-b854-b7df11e61073"), null, null, "Available" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("719027ce-d3d7-47ca-8e9d-fe1e2aed2107"), null, null, null, null, new DateTime(2025, 3, 18, 9, 24, 38, 405, DateTimeKind.Local).AddTicks(4282), null, null, null, "Samsung Galaxy S23 Ultra", 1199.99m, new Guid("aca6ba91-6ec0-4493-aced-b3e388de9a5f"), "In Stock" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("a269a1b8-fbc6-4b58-984d-824fea4afb5d"), null, null, null, null, new DateTime(2025, 3, 18, 9, 24, 38, 405, DateTimeKind.Local).AddTicks(4280), null, null, null, "iPhone 15 Pro", 999.99m, new Guid("aca6ba91-6ec0-4493-aced-b3e388de9a5f"), "In Stock" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("cbefb3f1-cf2f-4174-b789-12030eee1251"), null, null, null, null, new DateTime(2025, 3, 18, 9, 24, 38, 405, DateTimeKind.Local).AddTicks(4284), null, null, null, "Sony Bravia 4K TV", 1499.99m, new Guid("5670bac6-45e8-4bf3-9aeb-d8fd474a6616"), "In Stock" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("719027ce-d3d7-47ca-8e9d-fe1e2aed2107"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("a269a1b8-fbc6-4b58-984d-824fea4afb5d"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("cbefb3f1-cf2f-4174-b789-12030eee1251"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5670bac6-45e8-4bf3-9aeb-d8fd474a6616"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aca6ba91-6ec0-4493-aced-b3e388de9a5f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e728cf11-e042-48bc-a7be-59ae8393287e"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("da8545cb-1cf9-48eb-b854-b7df11e61073"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Admins");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Status" },
                values: new object[] { new Guid("ae56a447-3ea9-47c4-aa70-75f769dd93d6"), null, new DateTime(2025, 3, 17, 15, 38, 12, 100, DateTimeKind.Local).AddTicks(2664), null, null, null, "Electronics", "Active" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "Name", "Status" },
                values: new object[] { new Guid("e597d363-8d6b-4135-994b-abd0bcfe434b"), null, new DateTime(2025, 3, 17, 15, 38, 12, 100, DateTimeKind.Local).AddTicks(2489), null, "Apple", "Active" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Status" },
                values: new object[] { new Guid("0a6d2215-6248-4be2-ba14-bf952e6d16fd"), new Guid("ae56a447-3ea9-47c4-aa70-75f769dd93d6"), null, new DateTime(2025, 3, 17, 15, 38, 12, 100, DateTimeKind.Local).AddTicks(2685), new Guid("e597d363-8d6b-4135-994b-abd0bcfe434b"), null, null, "Available" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Status" },
                values: new object[] { new Guid("7e19e53c-0742-4c73-bdde-53f447057193"), new Guid("ae56a447-3ea9-47c4-aa70-75f769dd93d6"), null, new DateTime(2025, 3, 17, 15, 38, 12, 100, DateTimeKind.Local).AddTicks(2687), new Guid("e597d363-8d6b-4135-994b-abd0bcfe434b"), null, null, "Available" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("08cd05ae-e8ab-40a9-aeb4-a8104b984777"), null, null, null, null, new DateTime(2025, 3, 17, 15, 38, 12, 100, DateTimeKind.Local).AddTicks(2710), null, null, null, "iPhone 15 Pro", 999.99m, new Guid("0a6d2215-6248-4be2-ba14-bf952e6d16fd"), "In Stock" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("5d12b5ac-ca43-42ff-9233-1d8ab9f91dfc"), null, null, null, null, new DateTime(2025, 3, 17, 15, 38, 12, 100, DateTimeKind.Local).AddTicks(2715), null, null, null, "Sony Bravia 4K TV", 1499.99m, new Guid("7e19e53c-0742-4c73-bdde-53f447057193"), "In Stock" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Price", "ProductId", "Status" },
                values: new object[] { new Guid("5ebc808f-c931-418e-b14a-261767c30d9b"), null, null, null, null, new DateTime(2025, 3, 17, 15, 38, 12, 100, DateTimeKind.Local).AddTicks(2713), null, null, null, "Samsung Galaxy S23 Ultra", 1199.99m, new Guid("0a6d2215-6248-4be2-ba14-bf952e6d16fd"), "In Stock" });
        }
    }
}
