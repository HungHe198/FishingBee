using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_FishingBee.Migrations
{
    public partial class lan2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("7153900c-9d9a-40ed-8675-6abc830ea330"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2e8e1abb-58e9-43fe-9209-0ff8cc86fc31"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6034d9c2-6ec4-4666-8fdf-b22e8307bc72"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("618ea35d-f64d-4c9b-af9e-f96ec90264a3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7361e2b8-5335-4ff2-8046-d73d36fa1fcb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b698af9d-2733-4227-9e70-ddfa0f5f1ee2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0ad7cdd-685b-4060-aba2-a192cbf6040a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d2e2480a-0c37-4ac6-bb80-ed59c3937627"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("723da5ff-9805-4177-94a8-0968ecd3c441"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("7a7cdbad-1090-44e8-bd7c-3920d29b0663"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("89522100-2f59-4e26-8714-c875c786d86e"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("d640a42c-2956-47fa-843d-cfedda4568ab"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("136a4a33-8606-464d-a2b0-c418ae638914"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("4cc3cf8d-b879-4b50-b44f-c6bbb6fcb516"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("b33171dc-0242-4370-82d2-ea8542553143"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("df0abd76-edfc-4910-8618-5c234567195c"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("ee261384-301d-44ea-90ad-56db4fdbfa72"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("ee2d0718-fff1-482a-8b1c-8ca263598348"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("fde1b92d-13a6-4180-8109-1e1144deb675"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d11619a-7d66-4722-b200-032922659d43"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ae21064-c6be-440b-abc1-ff7d8b460d7f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ef83a96e-9482-4fdf-986e-8ae6e10fb73c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fb7c6b9c-e691-4b29-a518-6abc5ae79457"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("417cde7e-25ab-4a51-bb90-d25486b93787"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4ce5697-f207-4e11-9117-e924f3fac007"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("72ebcc12-c5e7-493a-841c-dade0c6f15ab"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ff21bed1-901d-4004-aea2-b2b04a63e5e4"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("ab1b3c9c-15f9-4b22-b428-84273d931e64"));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Cart_PDs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("14611056-2fc9-4dfb-933a-d0d596b629d9"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3540), null, null, null, "Phao", "Active" },
                    { new Guid("21c027db-28e5-40ce-a4bb-40e485875eca"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3542), null, null, null, "Giọ", "Active" },
                    { new Guid("333152b9-dd65-420f-9076-73a2163dd92b"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3542), null, null, null, "Mồi", "Active" },
                    { new Guid("482f77f1-4436-4f47-8c15-bbed4ff8edea"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3543), null, null, null, "Gác cần", "Active" },
                    { new Guid("54f00eec-83be-4bef-95fe-a8109e3d11b1"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3538), null, null, null, "Cần câu đài", "Active" },
                    { new Guid("6b5fc724-75b0-4fd4-9b66-4fea3bad35a1"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3539), null, null, null, "Trục", "Active" },
                    { new Guid("8d786feb-25e8-42de-b232-4ad7f2a41d77"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3539), null, null, null, "Thẻo", "Active" },
                    { new Guid("d8acf222-51bf-48c3-8af1-1de4f3f1960d"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3541), null, null, null, "Thùng câu", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("5ea02b62-b021-41e8-8c65-5fbf4c0a1c87"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3483), null, "Guide", "Active" },
                    { new Guid("733d7a40-3878-4f19-abdf-a4bf38c75318"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3519), null, "Gamma Seiko", "Active" },
                    { new Guid("88e9e93a-e3e5-4027-8c5f-d4d536722b1f"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3471), null, "Barfilon", "Active" },
                    { new Guid("a37bbdff-8319-42b4-968a-bc753475bd3d"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3483), null, "Handing", "Active" },
                    { new Guid("a5da89c3-9463-4637-a4de-4f0c1a7c510d"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3482), null, "Rice Fishing", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Email", "ModifiedBy", "ModifiedTime", "Password", "PhoneNumber", "Status", "UserType", "Username" },
                values: new object[] { new Guid("79335e71-e72e-4c9d-af59-686fbb5876ef"), null, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "fishingbee2024@gmail.com", null, null, "AQAAAAEAACcQAAAAEIo7U2pgZWqEikVfGclnHrLF87afkcdzKVEXRNKQ5Azh3orI05RzsEIENJhBc7sTSA==", "0123456789", "Active", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Descriptions", "FullName", "ModifiedBy", "ModifiedTime", "Permissions", "Status", "UserId", "UserType" },
                values: new object[] { new Guid("c2a7a1a2-d21f-4966-9e73-a278c45c0c1f"), null, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default Admin", "Super Admin", null, null, "All", "Active", new Guid("79335e71-e72e-4c9d-af59-686fbb5876ef"), "Admin" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("1b458e43-9bb5-4e68-bca8-06b06165f848"), new Guid("54f00eec-83be-4bef-95fe-a8109e3d11b1"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3565), new Guid("88e9e93a-e3e5-4027-8c5f-d4d536722b1f"), null, null, "Handing Thiết Sa", "Available" },
                    { new Guid("2da61340-cc86-4ade-8e6c-7c37df0fe7f7"), new Guid("54f00eec-83be-4bef-95fe-a8109e3d11b1"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3566), new Guid("88e9e93a-e3e5-4027-8c5f-d4d536722b1f"), null, null, "Guide Lục Mạch Thần Kiếm", "Available" },
                    { new Guid("6b58b9c5-00dd-4f79-9985-becfb5031668"), new Guid("54f00eec-83be-4bef-95fe-a8109e3d11b1"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3562), new Guid("88e9e93a-e3e5-4027-8c5f-d4d536722b1f"), null, null, "Barfilon Vân Trung Nguyệt", "Available" },
                    { new Guid("838aae1d-b239-4e5e-af91-e562fcaeea3b"), new Guid("54f00eec-83be-4bef-95fe-a8109e3d11b1"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3567), new Guid("88e9e93a-e3e5-4027-8c5f-d4d536722b1f"), null, null, "Guide Thánh Hỏa Lệnh", "Available" },
                    { new Guid("b689b079-52e0-4ee4-9bbb-06acefe40fd1"), new Guid("54f00eec-83be-4bef-95fe-a8109e3d11b1"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3563), new Guid("88e9e93a-e3e5-4027-8c5f-d4d536722b1f"), null, null, "Gamma Seiko Bạch Kim", "Available" },
                    { new Guid("de0bcf62-aab5-4aa0-85e9-2f3046365dde"), new Guid("54f00eec-83be-4bef-95fe-a8109e3d11b1"), null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3568), new Guid("88e9e93a-e3e5-4027-8c5f-d4d536722b1f"), null, null, "Rice V5 Silver Carp", "Available" }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Price", "ProductId", "Status", "Stock" },
                values: new object[,]
                {
                    { new Guid("0dc4e3ee-dc66-44da-b444-3f919a0ec1a9"), null, null, null, null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3594), null, null, null, 1.123m, new Guid("b689b079-52e0-4ee4-9bbb-06acefe40fd1"), "In Stock", 0m },
                    { new Guid("390387c9-aeca-4cf0-b005-fbd3b7486d52"), null, null, null, null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3586), null, null, null, 1.599m, new Guid("6b58b9c5-00dd-4f79-9985-becfb5031668"), "In Stock", 0m },
                    { new Guid("64da273e-5216-4603-99b7-cfcf159584b5"), null, null, null, null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3590), null, null, null, 2.300m, new Guid("6b58b9c5-00dd-4f79-9985-becfb5031668"), "In Stock", 0m },
                    { new Guid("8dd68256-e973-4805-9b86-831bd7242d0a"), null, null, null, null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3589), null, null, null, 1.123m, new Guid("b689b079-52e0-4ee4-9bbb-06acefe40fd1"), "In Stock", 0m },
                    { new Guid("ce810ee9-440f-4ab7-9c08-55a93e26c8b8"), null, null, null, null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3591), null, null, null, 1.123m, new Guid("b689b079-52e0-4ee4-9bbb-06acefe40fd1"), "In Stock", 0m },
                    { new Guid("cf14e663-68e1-4d50-a628-8dc6f2a236b6"), null, null, null, null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3592), null, null, null, 2.300m, new Guid("6b58b9c5-00dd-4f79-9985-becfb5031668"), "In Stock", 0m },
                    { new Guid("dd6299cd-fc54-4210-a45e-fbf151fe00b3"), null, null, null, null, new DateTime(2025, 3, 20, 3, 36, 1, 705, DateTimeKind.Local).AddTicks(3588), null, null, null, 2.300m, new Guid("6b58b9c5-00dd-4f79-9985-becfb5031668"), "In Stock", 0m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("c2a7a1a2-d21f-4966-9e73-a278c45c0c1f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("14611056-2fc9-4dfb-933a-d0d596b629d9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("21c027db-28e5-40ce-a4bb-40e485875eca"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("333152b9-dd65-420f-9076-73a2163dd92b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("482f77f1-4436-4f47-8c15-bbed4ff8edea"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6b5fc724-75b0-4fd4-9b66-4fea3bad35a1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8d786feb-25e8-42de-b232-4ad7f2a41d77"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d8acf222-51bf-48c3-8af1-1de4f3f1960d"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("5ea02b62-b021-41e8-8c65-5fbf4c0a1c87"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("733d7a40-3878-4f19-abdf-a4bf38c75318"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("a37bbdff-8319-42b4-968a-bc753475bd3d"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("a5da89c3-9463-4637-a4de-4f0c1a7c510d"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("0dc4e3ee-dc66-44da-b444-3f919a0ec1a9"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("390387c9-aeca-4cf0-b005-fbd3b7486d52"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("64da273e-5216-4603-99b7-cfcf159584b5"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("8dd68256-e973-4805-9b86-831bd7242d0a"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("ce810ee9-440f-4ab7-9c08-55a93e26c8b8"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("cf14e663-68e1-4d50-a628-8dc6f2a236b6"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: new Guid("dd6299cd-fc54-4210-a45e-fbf151fe00b3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1b458e43-9bb5-4e68-bca8-06b06165f848"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2da61340-cc86-4ade-8e6c-7c37df0fe7f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("838aae1d-b239-4e5e-af91-e562fcaeea3b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de0bcf62-aab5-4aa0-85e9-2f3046365dde"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6b58b9c5-00dd-4f79-9985-becfb5031668"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b689b079-52e0-4ee4-9bbb-06acefe40fd1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("79335e71-e72e-4c9d-af59-686fbb5876ef"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("54f00eec-83be-4bef-95fe-a8109e3d11b1"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("88e9e93a-e3e5-4027-8c5f-d4d536722b1f"));

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Cart_PDs");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("2e8e1abb-58e9-43fe-9209-0ff8cc86fc31"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3623), null, null, null, "Mồi", "Active" },
                    { new Guid("6034d9c2-6ec4-4666-8fdf-b22e8307bc72"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3618), null, null, null, "Trục", "Active" },
                    { new Guid("618ea35d-f64d-4c9b-af9e-f96ec90264a3"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3620), null, null, null, "Phao", "Active" },
                    { new Guid("7361e2b8-5335-4ff2-8046-d73d36fa1fcb"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3619), null, null, null, "Thẻo", "Active" },
                    { new Guid("b698af9d-2733-4227-9e70-ddfa0f5f1ee2"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3623), null, null, null, "Gác cần", "Active" },
                    { new Guid("c0ad7cdd-685b-4060-aba2-a192cbf6040a"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3621), null, null, null, "Giọ", "Active" },
                    { new Guid("d2e2480a-0c37-4ac6-bb80-ed59c3937627"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3621), null, null, null, "Thùng câu", "Active" },
                    { new Guid("ff21bed1-901d-4004-aea2-b2b04a63e5e4"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3617), null, null, null, "Cần câu đài", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("723da5ff-9805-4177-94a8-0968ecd3c441"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3598), null, "Gamma Seiko", "Active" },
                    { new Guid("7a7cdbad-1090-44e8-bd7c-3920d29b0663"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3597), null, "Guide", "Active" },
                    { new Guid("89522100-2f59-4e26-8714-c875c786d86e"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3595), null, "Rice Fishing", "Active" },
                    { new Guid("ab1b3c9c-15f9-4b22-b428-84273d931e64"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3587), null, "Barfilon", "Active" },
                    { new Guid("d640a42c-2956-47fa-843d-cfedda4568ab"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3596), null, "Handing", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Email", "ModifiedBy", "ModifiedTime", "Password", "PhoneNumber", "Status", "UserType", "Username" },
                values: new object[] { new Guid("72ebcc12-c5e7-493a-841c-dade0c6f15ab"), null, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "fishingbee2024@gmail.com", null, null, "AQAAAAEAACcQAAAAEHAp6+HlGJ3ZeCdhqyskVZiMLg+7sK07iOWO442qHpExVnp0MIDKeWsSHBRiiajT0Q==", "0123456789", "Active", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Descriptions", "FullName", "ModifiedBy", "ModifiedTime", "Permissions", "Status", "UserId", "UserType" },
                values: new object[] { new Guid("7153900c-9d9a-40ed-8675-6abc830ea330"), null, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default Admin", "Super Admin", null, null, "All", "Active", new Guid("72ebcc12-c5e7-493a-841c-dade0c6f15ab"), "Admin" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("417cde7e-25ab-4a51-bb90-d25486b93787"), new Guid("ff21bed1-901d-4004-aea2-b2b04a63e5e4"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3640), new Guid("ab1b3c9c-15f9-4b22-b428-84273d931e64"), null, null, "Gamma Seiko Bạch Kim", "Available" },
                    { new Guid("4d11619a-7d66-4722-b200-032922659d43"), new Guid("ff21bed1-901d-4004-aea2-b2b04a63e5e4"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3641), new Guid("ab1b3c9c-15f9-4b22-b428-84273d931e64"), null, null, "Guide Lục Mạch Thần Kiếm", "Available" },
                    { new Guid("8ae21064-c6be-440b-abc1-ff7d8b460d7f"), new Guid("ff21bed1-901d-4004-aea2-b2b04a63e5e4"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3641), new Guid("ab1b3c9c-15f9-4b22-b428-84273d931e64"), null, null, "Handing Thiết Sa", "Available" },
                    { new Guid("d4ce5697-f207-4e11-9117-e924f3fac007"), new Guid("ff21bed1-901d-4004-aea2-b2b04a63e5e4"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3638), new Guid("ab1b3c9c-15f9-4b22-b428-84273d931e64"), null, null, "Barfilon Vân Trung Nguyệt", "Available" },
                    { new Guid("ef83a96e-9482-4fdf-986e-8ae6e10fb73c"), new Guid("ff21bed1-901d-4004-aea2-b2b04a63e5e4"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3643), new Guid("ab1b3c9c-15f9-4b22-b428-84273d931e64"), null, null, "Rice V5 Silver Carp", "Available" },
                    { new Guid("fb7c6b9c-e691-4b29-a518-6abc5ae79457"), new Guid("ff21bed1-901d-4004-aea2-b2b04a63e5e4"), null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3642), new Guid("ab1b3c9c-15f9-4b22-b428-84273d931e64"), null, null, "Guide Thánh Hỏa Lệnh", "Available" }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Price", "ProductId", "Status", "Stock" },
                values: new object[,]
                {
                    { new Guid("136a4a33-8606-464d-a2b0-c418ae638914"), null, null, null, null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3667), null, null, null, 1.599m, new Guid("d4ce5697-f207-4e11-9117-e924f3fac007"), "In Stock", 0m },
                    { new Guid("4cc3cf8d-b879-4b50-b44f-c6bbb6fcb516"), null, null, null, null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3669), null, null, null, 2.300m, new Guid("d4ce5697-f207-4e11-9117-e924f3fac007"), "In Stock", 0m },
                    { new Guid("b33171dc-0242-4370-82d2-ea8542553143"), null, null, null, null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3674), null, null, null, 1.123m, new Guid("417cde7e-25ab-4a51-bb90-d25486b93787"), "In Stock", 0m },
                    { new Guid("df0abd76-edfc-4910-8618-5c234567195c"), null, null, null, null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3671), null, null, null, 1.123m, new Guid("417cde7e-25ab-4a51-bb90-d25486b93787"), "In Stock", 0m },
                    { new Guid("ee261384-301d-44ea-90ad-56db4fdbfa72"), null, null, null, null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3673), null, null, null, 2.300m, new Guid("d4ce5697-f207-4e11-9117-e924f3fac007"), "In Stock", 0m },
                    { new Guid("ee2d0718-fff1-482a-8b1c-8ca263598348"), null, null, null, null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3675), null, null, null, 2.300m, new Guid("d4ce5697-f207-4e11-9117-e924f3fac007"), "In Stock", 0m },
                    { new Guid("fde1b92d-13a6-4180-8109-1e1144deb675"), null, null, null, null, new DateTime(2025, 3, 20, 2, 52, 17, 869, DateTimeKind.Local).AddTicks(3676), null, null, null, 1.123m, new Guid("417cde7e-25ab-4a51-bb90-d25486b93787"), "In Stock", 0m }
                });
        }
    }
}
