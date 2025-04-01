using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_FishingBee.Migrations
{
    public partial class lan1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinOfTotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOfDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productViewModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productViewModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permissions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoyaltyPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttributeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttributeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerActivityLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAutoLogout = table.Column<bool>(type: "bit", nullable: false),
                    SessionDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerActivityLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerActivityLogs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSupports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerFeedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatingForSupport = table.Column<int>(type: "int", nullable: true),
                    AdminId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSupports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSupports_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSupports_Admins_AdminId1",
                        column: x => x.AdminId1,
                        principalTable: "Admins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerSupports_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CouponId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bills_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bills_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    AttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventories_ProductDetails_Id",
                        column: x => x.Id,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cart_PDs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_PDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_PDs_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_PDs_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillDetails_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillDetails_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportHistories_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportHistories_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("2f3ce9b9-0e57-4851-bc10-7bfb894b853e"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8253), null, null, null, "Mồi", "Active" },
                    { new Guid("45bca4f4-02ec-45d8-9e6d-fdead849afae"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8246), null, null, null, "Trục", "Active" },
                    { new Guid("529c14f7-ec2d-495e-9515-b8e04879242c"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8251), null, null, null, "Phao", "Active" },
                    { new Guid("6c345b78-a69f-4d8d-bcdd-4e9ad5e483be"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8250), null, null, null, "Thẻo", "Active" },
                    { new Guid("724e463d-1349-4d89-b3ef-385a446064c1"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8252), null, null, null, "Thùng câu", "Active" },
                    { new Guid("c1d09cf9-2c60-4a72-9b5a-c493ddbb18f9"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8254), null, null, null, "Gác cần", "Active" },
                    { new Guid("e072cbe8-8788-4881-843c-2b6f269e471d"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8244), null, null, null, "Cần câu đài", "Active" },
                    { new Guid("ef5cbaf8-0a7c-4656-9b5d-186089823bb9"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8252), null, null, null, "Giọ", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "ImageUrl", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("101df509-8457-4c78-96c2-4c1c7ae3fd3a"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8218), null, null, "Barfilon", "Active" },
                    { new Guid("13add589-04e4-423f-8805-5bfc146a3bcf"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8229), null, null, "Gamma Seiko", "Active" },
                    { new Guid("6ac50de8-befc-4ba3-9a47-fd88054124d0"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8229), null, null, "Guide", "Active" },
                    { new Guid("af3d0f5c-cc4d-437e-b861-37dbc26e20b4"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8228), null, null, "Handing", "Active" },
                    { new Guid("d0c60cb0-d798-458c-8979-494e1904391c"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8227), null, null, "Rice Fishing", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Email", "ModifiedBy", "ModifiedTime", "Password", "PhoneNumber", "Status", "UserType", "Username" },
                values: new object[] { new Guid("c18004fc-49a3-44a9-bad1-cd96de3942e4"), null, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "fishingbee2024@gmail.com", null, null, "AQAAAAEAACcQAAAAEEvrIcLFoZX5BJcCYQc7OxSc0EuphY9z5NuTlzGdZP4T3jXh3b40lE50edxA+/JuwA==", "0123456789", "Active", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Descriptions", "FullName", "ModifiedBy", "ModifiedTime", "Permissions", "Status", "UserId", "UserType" },
                values: new object[] { new Guid("ad082bce-4610-4d34-9b08-a40d721aa104"), null, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default Admin", "Super Admin", null, null, "All", "Active", new Guid("c18004fc-49a3-44a9-bad1-cd96de3942e4"), "Admin" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("003e4340-c720-41ad-942c-29476f0c2333"), new Guid("e072cbe8-8788-4881-843c-2b6f269e471d"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8267), new Guid("101df509-8457-4c78-96c2-4c1c7ae3fd3a"), null, null, "Gamma Seiko Bạch Kim", "Available" },
                    { new Guid("74ce8e8f-752b-45b0-befb-a46b99ddc918"), new Guid("e072cbe8-8788-4881-843c-2b6f269e471d"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8270), new Guid("101df509-8457-4c78-96c2-4c1c7ae3fd3a"), null, null, "Guide Thánh Hỏa Lệnh", "Available" },
                    { new Guid("9e06bb82-30e5-47b3-aabc-5b9ad646425f"), new Guid("e072cbe8-8788-4881-843c-2b6f269e471d"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8266), new Guid("101df509-8457-4c78-96c2-4c1c7ae3fd3a"), null, null, "Barfilon Vân Trung Nguyệt", "Available" },
                    { new Guid("ac695a2c-fb43-4111-90f6-bc4ab0e3a1b7"), new Guid("e072cbe8-8788-4881-843c-2b6f269e471d"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8268), new Guid("101df509-8457-4c78-96c2-4c1c7ae3fd3a"), null, null, "Handing Thiết Sa", "Available" },
                    { new Guid("b4e34449-342f-4cc6-8dfb-152ef0350204"), new Guid("e072cbe8-8788-4881-843c-2b6f269e471d"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8272), new Guid("101df509-8457-4c78-96c2-4c1c7ae3fd3a"), null, null, "Rice V5 Silver Carp", "Available" },
                    { new Guid("cde0688f-059b-4c5f-8713-f38c104a0c7e"), new Guid("e072cbe8-8788-4881-843c-2b6f269e471d"), null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8269), new Guid("101df509-8457-4c78-96c2-4c1c7ae3fd3a"), null, null, "Guide Lục Mạch Thần Kiếm", "Available" }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Price", "ProductId", "Status", "Stock" },
                values: new object[,]
                {
                    { new Guid("238b6550-04e6-4cd0-a52c-31c2ec1e1aaf"), null, null, null, null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8291), null, null, null, 2.300m, new Guid("9e06bb82-30e5-47b3-aabc-5b9ad646425f"), "In Stock", 0m },
                    { new Guid("3826812f-1c59-41f6-aace-1d547826d2d3"), null, null, null, null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8292), null, null, null, 1.123m, new Guid("003e4340-c720-41ad-942c-29476f0c2333"), "In Stock", 0m },
                    { new Guid("a2825697-85d4-4e4e-9804-08c2d34de3fc"), null, null, null, null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8289), null, null, null, 1.599m, new Guid("9e06bb82-30e5-47b3-aabc-5b9ad646425f"), "In Stock", 0m },
                    { new Guid("a3a180f3-5c04-4872-8658-0c0b9e81f724"), null, null, null, null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8295), null, null, null, 2.300m, new Guid("9e06bb82-30e5-47b3-aabc-5b9ad646425f"), "In Stock", 0m },
                    { new Guid("aeeabaa1-0a39-4365-af2d-d5f6d60d9424"), null, null, null, null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8297), null, null, null, 1.123m, new Guid("003e4340-c720-41ad-942c-29476f0c2333"), "In Stock", 0m },
                    { new Guid("dd962470-9f1d-4ded-8d73-b328eb3fc3ac"), null, null, null, null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8298), null, null, null, 2.300m, new Guid("9e06bb82-30e5-47b3-aabc-5b9ad646425f"), "In Stock", 0m },
                    { new Guid("e1aadb93-f798-471d-bac4-4fccf45916d0"), null, null, null, null, new DateTime(2025, 4, 1, 20, 4, 25, 64, DateTimeKind.Local).AddTicks(8299), null, null, null, 1.123m, new Guid("003e4340-c720-41ad-942c-29476f0c2333"), "In Stock", 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_BillId",
                table: "BillDetails",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_ProductDetailId",
                table: "BillDetails",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_AdminId",
                table: "Bills",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CouponId",
                table: "Bills",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CustomerId",
                table: "Bills",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_EmployeeId",
                table: "Bills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_PDs_CartId",
                table: "Cart_PDs",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_PDs_ProductDetailId",
                table: "Cart_PDs",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerActivityLogs_CustomerId",
                table: "CustomerActivityLogs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupports_AdminId",
                table: "CustomerSupports",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupports_AdminId1",
                table: "CustomerSupports",
                column: "AdminId1");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupports_CustomerId",
                table: "CustomerSupports",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportHistories_InventoryId",
                table: "ImportHistories",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportHistories_SupplierId",
                table: "ImportHistories",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryId",
                table: "Inventories",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_SupplierId",
                table: "Inventories",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_EmployeeId",
                table: "Notifications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDetails");

            migrationBuilder.DropTable(
                name: "Cart_PDs");

            migrationBuilder.DropTable(
                name: "CustomerActivityLogs");

            migrationBuilder.DropTable(
                name: "CustomerSupports");

            migrationBuilder.DropTable(
                name: "ImportHistories");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "productViewModels");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
