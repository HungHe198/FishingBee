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
                name: "CartItemViewModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItemViewModels", x => x.Id);
                });

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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttributeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttributeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
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
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
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
                    { new Guid("1d0a5c47-925a-4ef7-abb5-2775379876e5"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3586), null, null, null, "Trục", "1" },
                    { new Guid("359813a3-83ef-474c-9d85-5983a0fea813"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3588), null, null, null, "Thùng câu", "1" },
                    { new Guid("44c39f6d-65cc-4f0f-b1dc-5916886aebec"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3587), null, null, null, "Thẻo", "1" },
                    { new Guid("4ca63409-f2a8-4571-aa50-1fdbfdaa4169"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3592), null, null, null, "Gác cần", "1" },
                    { new Guid("50cf21c2-6bbc-4edd-b1ae-ff9cd2b5c640"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3584), null, null, null, "Cần câu đài", "1" },
                    { new Guid("6177a049-5217-4006-bdb0-c9609c99ebfe"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3590), null, null, null, "Mồi", "1" },
                    { new Guid("88e6e248-dac8-4a71-b6d7-57a646cf95e4"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3589), null, null, null, "Giọ", "1" },
                    { new Guid("ef1f65ad-b713-407b-9091-c2c18100242d"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3587), null, null, null, "Phao", "1" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "ImageUrl", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("37810cb7-097d-458f-ab21-0b1fdc1e24c9"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3545), "Chuyên sản xuất mồi câu cá", null, "Rapala", "1" },
                    { new Guid("40bda0a9-5446-4b74-97fa-112b024ef882"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3544), "Thương hiệu đồ câu cá hàng đầu thế giới", null, "Shimano", "1" },
                    { new Guid("4e0b6bd9-1556-42b4-8a94-57311888bf40"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3532), "Nhà sản xuất cần câu nổi tiếng từ Nhật Bản", null, "Daiwa", "1" },
                    { new Guid("7515168a-bb2d-4a3e-a784-5fe320670fb6"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3548), "Nhà sản xuất đồ câu chất lượng cao", null, "Okuma", "1" },
                    { new Guid("ad08042d-940a-4a8c-9632-9531d6b79b97"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3551), "Chuyên sản xuất lưỡi câu", null, "Gamakatsu", "1" },
                    { new Guid("ae4f5137-a7d1-4e49-b6d8-26918b49cc92"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3551), "Thương hiệu lưỡi câu nổi tiếng", null, "Mustad", "1" },
                    { new Guid("bcdef1bd-8d7f-43bd-8c92-6c0f0ee8d103"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3549), "Chuyên về trục và cần câu biển", null, "Penn", "1" },
                    { new Guid("d9939265-b197-4912-b7af-26aa8959b4de"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3550), "Nhà sản xuất dây câu chất lượng", null, "Sufix", "1" },
                    { new Guid("de5cfecb-5794-4d78-8828-22cbfcc3f4a8"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3547), "Thương hiệu trục câu nổi tiếng", null, "Abu Garcia", "1" },
                    { new Guid("dffc33c8-8032-4521-96b3-f1473a0fb910"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3546), "Nhà sản xuất mồi và phụ kiện câu cá", null, "Berkley", "1" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Email", "ModifiedBy", "ModifiedTime", "Password", "PhoneNumber", "Status", "UserType", "Username" },
                values: new object[] { new Guid("674367af-6d92-42ea-b35d-4637347839c5"), null, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "fishingbee2024@gmail.com", null, null, "AQAAAAEAACcQAAAAEL9IgiIQTdAGw/yHRLdbhIeCHUumdBTcK3fArvjDdF1jBigsOIZylQsBlP+PXZ/jiQ==", "0123456789", "1", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Descriptions", "FullName", "ModifiedBy", "ModifiedTime", "Permissions", "Status", "UserId", "UserType" },
                values: new object[] { new Guid("9fb5fb72-961b-404b-8391-76d41ac6bf61"), null, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default Admin", "Super Admin", null, null, "All", "1", new Guid("674367af-6d92-42ea-b35d-4637347839c5"), "Admin" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("05d2bd13-8521-4035-bfb8-338763616e04"), "Tỷ lệ truyền", "", new Guid("1d0a5c47-925a-4ef7-abb5-2775379876e5"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3752), new Guid("ae4f5137-a7d1-4e49-b6d8-26918b49cc92"), null, null, "Sản phẩm 10 - Trục", "1" },
                    { new Guid("0b141f6d-bbb0-48d9-beb0-72e63047ba3b"), "Loại mồi", "", new Guid("6177a049-5217-4006-bdb0-c9609c99ebfe"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3814), new Guid("de5cfecb-5794-4d78-8828-22cbfcc3f4a8"), null, null, "Sản phẩm 15 - Mồi", "1" },
                    { new Guid("0c4c9457-1e69-445a-986d-fe1f30e0969f"), "Kích thước", "cm", new Guid("ef1f65ad-b713-407b-9091-c2c18100242d"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3873), new Guid("ae4f5137-a7d1-4e49-b6d8-26918b49cc92"), null, null, "Sản phẩm 20 - Phao", "1" },
                    { new Guid("13737c51-c345-4f5b-bbba-c77f83769a37"), "Kích thước", "cm", new Guid("ef1f65ad-b713-407b-9091-c2c18100242d"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3791), new Guid("40bda0a9-5446-4b74-97fa-112b024ef882"), null, null, "Sản phẩm 12 - Phao", "1" },
                    { new Guid("2063aca9-cde4-4919-a8db-2e2886ed1615"), "Tỷ lệ truyền", "", new Guid("1d0a5c47-925a-4ef7-abb5-2775379876e5"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3643), new Guid("40bda0a9-5446-4b74-97fa-112b024ef882"), null, null, "Sản phẩm 2 - Trục", "1" },
                    { new Guid("340bae4a-825e-4225-9efd-a76be28484b7"), "Loại mồi", "", new Guid("6177a049-5217-4006-bdb0-c9609c99ebfe"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3729), new Guid("bcdef1bd-8d7f-43bd-8c92-6c0f0ee8d103"), null, null, "Sản phẩm 7 - Mồi", "1" },
                    { new Guid("41fcf891-ea1e-45f8-a29f-023e3001e8e6"), "Chiều dài", "m", new Guid("50cf21c2-6bbc-4edd-b1ae-ff9cd2b5c640"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3828), new Guid("bcdef1bd-8d7f-43bd-8c92-6c0f0ee8d103"), null, null, "Sản phẩm 17 - Cần câu đài", "1" },
                    { new Guid("55833496-8dad-471c-bfc8-400c69d77c50"), "Chất liệu", "", new Guid("4ca63409-f2a8-4571-aa50-1fdbfdaa4169"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3737), new Guid("d9939265-b197-4912-b7af-26aa8959b4de"), null, null, "Sản phẩm 8 - Gác cần", "1" },
                    { new Guid("590db8c3-cc86-412a-8137-53acae19a4ee"), "Dung tích", "lít", new Guid("359813a3-83ef-474c-9d85-5983a0fea813"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3713), new Guid("de5cfecb-5794-4d78-8828-22cbfcc3f4a8"), null, null, "Sản phẩm 5 - Thùng câu", "1" },
                    { new Guid("5c6778f2-a040-4af9-b348-2444928c255b"), "Tỷ lệ truyền", "", new Guid("1d0a5c47-925a-4ef7-abb5-2775379876e5"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3860), new Guid("d9939265-b197-4912-b7af-26aa8959b4de"), null, null, "Sản phẩm 18 - Trục", "1" },
                    { new Guid("5ebd6b86-f18c-4ff1-8f00-de9fa00c3c81"), "Dung tích", "lít", new Guid("359813a3-83ef-474c-9d85-5983a0fea813"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3799), new Guid("37810cb7-097d-458f-ab21-0b1fdc1e24c9"), null, null, "Sản phẩm 13 - Thùng câu", "1" },
                    { new Guid("77912245-2de7-471e-bdaf-018ad9f0f846"), "Chiều dài", "m", new Guid("50cf21c2-6bbc-4edd-b1ae-ff9cd2b5c640"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3619), new Guid("4e0b6bd9-1556-42b4-8a94-57311888bf40"), null, null, "Sản phẩm 1 - Cần câu đài", "1" },
                    { new Guid("8f35d0e1-260d-4667-bc7b-c93c728a180b"), "Chiều dài", "m", new Guid("50cf21c2-6bbc-4edd-b1ae-ff9cd2b5c640"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3745), new Guid("ad08042d-940a-4a8c-9632-9531d6b79b97"), null, null, "Sản phẩm 9 - Cần câu đài", "1" },
                    { new Guid("a5a84b81-f914-46e8-b9dc-3a9ac69853eb"), "Kích thước", "cm", new Guid("88e6e248-dac8-4a71-b6d7-57a646cf95e4"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3721), new Guid("7515168a-bb2d-4a3e-a784-5fe320670fb6"), null, null, "Sản phẩm 6 - Giọ", "1" },
                    { new Guid("af6c847e-e4e1-447a-90df-c9acc6235bbb"), "Chất liệu", "", new Guid("4ca63409-f2a8-4571-aa50-1fdbfdaa4169"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3821), new Guid("7515168a-bb2d-4a3e-a784-5fe320670fb6"), null, null, "Sản phẩm 16 - Gác cần", "1" },
                    { new Guid("b0acab70-6b39-4b2a-a359-3c91fb099d01"), "Kích thước", "cm", new Guid("88e6e248-dac8-4a71-b6d7-57a646cf95e4"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3806), new Guid("dffc33c8-8032-4521-96b3-f1473a0fb910"), null, null, "Sản phẩm 14 - Giọ", "1" },
                    { new Guid("b9ee5c58-0884-449a-8eb8-f85b18ada50a"), "Độ bền", "lb", new Guid("44c39f6d-65cc-4f0f-b1dc-5916886aebec"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3653), new Guid("37810cb7-097d-458f-ab21-0b1fdc1e24c9"), null, null, "Sản phẩm 3 - Thẻo", "1" },
                    { new Guid("c01bdc82-42c3-4ebf-be46-67658c631632"), "Độ bền", "lb", new Guid("44c39f6d-65cc-4f0f-b1dc-5916886aebec"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3868), new Guid("ad08042d-940a-4a8c-9632-9531d6b79b97"), null, null, "Sản phẩm 19 - Thẻo", "1" },
                    { new Guid("c26fab98-9bea-4303-a6e1-f70f7f871fee"), "Kích thước", "cm", new Guid("ef1f65ad-b713-407b-9091-c2c18100242d"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3705), new Guid("dffc33c8-8032-4521-96b3-f1473a0fb910"), null, null, "Sản phẩm 4 - Phao", "1" },
                    { new Guid("faa14773-a87d-4928-9805-ffe043ffd734"), "Độ bền", "lb", new Guid("44c39f6d-65cc-4f0f-b1dc-5916886aebec"), null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3783), new Guid("4e0b6bd9-1556-42b4-8a94-57311888bf40"), null, null, "Sản phẩm 11 - Thẻo", "1" }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Price", "ProductId", "Status", "Stock" },
                values: new object[,]
                {
                    { new Guid("071e6cbe-4a67-43f5-9f94-662008fa4275"), "Mồi tự nhiên", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3818), "Biến thể 2 của Sản phẩm 15 - Mồi", null, null, 37000m, new Guid("0b141f6d-bbb0-48d9-beb0-72e63047ba3b"), "1", 85 },
                    { new Guid("07a0dc92-e51b-4c3e-8547-83ea6ef7f40a"), "3.5", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3711), "Biến thể 3 của Sản phẩm 4 - Phao", null, null, 30000m, new Guid("c26fab98-9bea-4303-a6e1-f70f7f871fee"), "1", 40 },
                    { new Guid("0b157f8f-a1b4-4a13-83a9-f3235cc28ea4"), "10", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3654), "Biến thể 1 của Sản phẩm 3 - Thẻo", null, null, 50000m, new Guid("b9ee5c58-0884-449a-8eb8-f85b18ada50a"), "1", 50 },
                    { new Guid("1565e2dd-ee67-4665-81bd-65520fbdc291"), "20", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3787), "Biến thể 2 của Sản phẩm 11 - Thẻo", null, null, 65000m, new Guid("faa14773-a87d-4928-9805-ffe043ffd734"), "1", 45 },
                    { new Guid("18646d14-319d-49bb-8701-276b56ea3bc3"), "2.5", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3708), "Biến thể 1 của Sản phẩm 4 - Phao", null, null, 20000m, new Guid("c26fab98-9bea-4303-a6e1-f70f7f871fee"), "1", 60 },
                    { new Guid("203d71c4-bb91-420e-b7c5-f27c85d2e3e9"), "3.0", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3795), "Biến thể 2 của Sản phẩm 12 - Phao", null, null, 27000m, new Guid("13737c51-c345-4f5b-bbba-c77f83769a37"), "1", 55 },
                    { new Guid("2378d418-ff61-4d44-9b00-dbd9b15d694b"), "2.5", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3876), "Biến thể 1 của Sản phẩm 20 - Phao", null, null, 23000m, new Guid("0c4c9457-1e69-445a-986d-fe1f30e0969f"), "1", 60 },
                    { new Guid("240a5f6a-4416-40e6-84c6-93bfac67b62d"), "3.5", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3797), "Biến thể 3 của Sản phẩm 12 - Phao", null, null, 32000m, new Guid("13737c51-c345-4f5b-bbba-c77f83769a37"), "1", 45 },
                    { new Guid("27ab3e87-1658-40f8-b82e-4c6620389117"), "70", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3813), "Biến thể 3 của Sản phẩm 14 - Giọ", null, null, 150000m, new Guid("b0acab70-6b39-4b2a-a359-3c91fb099d01"), "1", 18 },
                    { new Guid("3885ea88-bfb9-45e2-89ad-12da1c1adb37"), "Mồi tổng hợp", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3736), "Biến thể 3 của Sản phẩm 7 - Mồi", null, null, 40000m, new Guid("340bae4a-825e-4225-9efd-a76be28484b7"), "1", 80 },
                    { new Guid("427146ba-daa7-4cbf-8bc9-c4e8d99b9987"), "7.0:1", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3866), "Biến thể 3 của Sản phẩm 18 - Trục", null, null, 420000m, new Guid("5c6778f2-a040-4af9-b348-2444928c255b"), "1", 12 },
                    { new Guid("4f67af0d-0c0b-45e4-91f3-0ed8eddc4fca"), "30", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3872), "Biến thể 3 của Sản phẩm 19 - Thẻo", null, null, 80000m, new Guid("c01bdc82-42c3-4ebf-be46-67658c631632"), "1", 30 },
                    { new Guid("52149f90-0afc-4124-acf9-fec6d2796aa2"), "30", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3801), "Biến thể 1 của Sản phẩm 13 - Thùng câu", null, null, 510000m, new Guid("5ebd6b86-f18c-4ff1-8f00-de9fa00c3c81"), "1", 12 },
                    { new Guid("52e67a7b-785d-4f47-acb6-bc500c5330ff"), "2.5", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3794), "Biến thể 1 của Sản phẩm 12 - Phao", null, null, 22000m, new Guid("13737c51-c345-4f5b-bbba-c77f83769a37"), "1", 65 },
                    { new Guid("54f4e706-adda-45e6-bd0b-22006d12144f"), "60", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3810), "Biến thể 2 của Sản phẩm 14 - Giọ", null, null, 130000m, new Guid("b0acab70-6b39-4b2a-a359-3c91fb099d01"), "1", 22 },
                    { new Guid("5658ef33-0723-41e1-8018-ae7951789748"), "5.4", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3858), "Biến thể 3 của Sản phẩm 17 - Cần câu đài", null, null, 270000m, new Guid("41fcf891-ea1e-45f8-a29f-023e3001e8e6"), "1", 10 },
                    { new Guid("5663bc40-4c4f-4271-9a90-3a123cf82e74"), "Nhôm", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3823), "Biến thể 1 của Sản phẩm 16 - Gác cần", null, null, 85000m, new Guid("af6c847e-e4e1-447a-90df-c9acc6235bbb"), "1", 32 },
                    { new Guid("59d8ccd4-aac7-47fa-9de6-d9ee9b4b9a1a"), "10", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3785), "Biến thể 1 của Sản phẩm 11 - Thẻo", null, null, 55000m, new Guid("faa14773-a87d-4928-9805-ffe043ffd734"), "1", 55 },
                    { new Guid("5e278e2d-e5a6-4785-8dc8-51f2f3c346be"), "Mồi tổng hợp", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3819), "Biến thể 3 của Sản phẩm 15 - Mồi", null, null, 42000m, new Guid("0b141f6d-bbb0-48d9-beb0-72e63047ba3b"), "1", 75 },
                    { new Guid("6240c634-d3b5-44cb-afb0-2bac585878e4"), "Thép", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3741), "Biến thể 2 của Sản phẩm 8 - Gác cần", null, null, 90000m, new Guid("55833496-8dad-471c-bfc8-400c69d77c50"), "1", 30 },
                    { new Guid("6e1c147b-f200-4ff9-8d66-b6a3a0981602"), "Nhôm", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3740), "Biến thể 1 của Sản phẩm 8 - Gác cần", null, null, 80000m, new Guid("55833496-8dad-471c-bfc8-400c69d77c50"), "1", 35 },
                    { new Guid("6e5f835f-6e26-48af-a760-5bc79abd0819"), "7.0:1", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3782), "Biến thể 3 của Sản phẩm 10 - Trục", null, null, 410000m, new Guid("05d2bd13-8521-4035-bfb8-338763616e04"), "1", 14 },
                    { new Guid("70e8ef21-ab21-4889-97ad-b80e3bb7c533"), "3.0", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3710), "Biến thể 2 của Sản phẩm 4 - Phao", null, null, 25000m, new Guid("c26fab98-9bea-4303-a6e1-f70f7f871fee"), "1", 50 },
                    { new Guid("7aa4a3c3-0171-40e0-beab-c86d75c064f6"), "50", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3724), "Biến thể 1 của Sản phẩm 6 - Giọ", null, null, 100000m, new Guid("a5a84b81-f914-46e8-b9dc-3a9ac69853eb"), "1", 30 },
                    { new Guid("7da9e27e-3c1e-4653-821f-93bd3560c7c1"), "Mồi giả", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3816), "Biến thể 1 của Sản phẩm 15 - Mồi", null, null, 32000m, new Guid("0b141f6d-bbb0-48d9-beb0-72e63047ba3b"), "1", 95 },
                    { new Guid("7eaff5ec-968f-49df-9bc3-43a1ce637aea"), "6.2:1", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3649), "Biến thể 2 của Sản phẩm 2 - Trục", null, null, 350000m, new Guid("2063aca9-cde4-4919-a8db-2e2886ed1615"), "1", 20 },
                    { new Guid("8bb8acba-ee23-4995-b9c0-6b6b603ccb4c"), "Carbon", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3826), "Biến thể 3 của Sản phẩm 16 - Gác cần", null, null, 105000m, new Guid("af6c847e-e4e1-447a-90df-c9acc6235bbb"), "1", 22 },
                    { new Guid("8ea8887f-04d7-4083-aa7f-2675d05dbb5b"), "5.2:1", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3754), "Biến thể 1 của Sản phẩm 10 - Trục", null, null, 310000m, new Guid("05d2bd13-8521-4035-bfb8-338763616e04"), "1", 22 },
                    { new Guid("920de269-ea82-4b5f-b0fc-50dba3889bbb"), "30", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3660), "Biến thể 3 của Sản phẩm 3 - Thẻo", null, null, 70000m, new Guid("b9ee5c58-0884-449a-8eb8-f85b18ada50a"), "1", 30 },
                    { new Guid("962eac73-745e-470c-8afb-5819d539f614"), "Mồi giả", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3731), "Biến thể 1 của Sản phẩm 7 - Mồi", null, null, 30000m, new Guid("340bae4a-825e-4225-9efd-a76be28484b7"), "1", 100 },
                    { new Guid("9a39a043-8375-4d41-9590-2b15dec278ab"), "3.5", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3879), "Biến thể 3 của Sản phẩm 20 - Phao", null, null, 33000m, new Guid("0c4c9457-1e69-445a-986d-fe1f30e0969f"), "1", 40 },
                    { new Guid("a77f269b-c748-4995-9a58-4254683c6324"), "4.5", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3633), "Biến thể 2 của Sản phẩm 1 - Cần câu đài", null, null, 200000m, new Guid("77912245-2de7-471e-bdaf-018ad9f0f846"), "1", 15 },
                    { new Guid("ac67bc03-084b-4cb6-a012-091d2260a287"), "70", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3726), "Biến thể 3 của Sản phẩm 6 - Giọ", null, null, 140000m, new Guid("a5a84b81-f914-46e8-b9dc-3a9ac69853eb"), "1", 20 },
                    { new Guid("acf7088c-3721-4b81-9772-21f06805e1c8"), "6.2:1", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3865), "Biến thể 2 của Sản phẩm 18 - Trục", null, null, 370000m, new Guid("5c6778f2-a040-4af9-b348-2444928c255b"), "1", 16 },
                    { new Guid("adc56c02-bc1b-4b48-8e88-8a1cad691349"), "Carbon", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3743), "Biến thể 3 của Sản phẩm 8 - Gác cần", null, null, 100000m, new Guid("55833496-8dad-471c-bfc8-400c69d77c50"), "1", 25 },
                    { new Guid("afab228d-db72-42d7-bc56-36b362ffeaf0"), "20", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3870), "Biến thể 2 của Sản phẩm 19 - Thẻo", null, null, 70000m, new Guid("c01bdc82-42c3-4ebf-be46-67658c631632"), "1", 40 },
                    { new Guid("b247ffc7-5113-41f9-b6f6-5f0177b8db04"), "4.5", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3857), "Biến thể 2 của Sản phẩm 17 - Cần câu đài", null, null, 220000m, new Guid("41fcf891-ea1e-45f8-a29f-023e3001e8e6"), "1", 12 },
                    { new Guid("b698f39e-ce60-46b4-ba35-bd64e243556c"), "3.0", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3877), "Biến thể 2 của Sản phẩm 20 - Phao", null, null, 28000m, new Guid("0c4c9457-1e69-445a-986d-fe1f30e0969f"), "1", 50 },
                    { new Guid("b8130841-74a4-447b-819e-76913e7b34be"), "3.6", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3629), "Biến thể 1 của Sản phẩm 1 - Cần câu đài", null, null, 150000m, new Guid("77912245-2de7-471e-bdaf-018ad9f0f846"), "1", 20 },
                    { new Guid("bb04a2c1-8a76-47e1-aa1d-52dbf953d308"), "3.6", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3855), "Biến thể 1 của Sản phẩm 17 - Cần câu đài", null, null, 170000m, new Guid("41fcf891-ea1e-45f8-a29f-023e3001e8e6"), "1", 16 },
                    { new Guid("bb7e8078-4ff5-463b-95ae-e85e0d7794ab"), "60", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3725), "Biến thể 2 của Sản phẩm 6 - Giọ", null, null, 120000m, new Guid("a5a84b81-f914-46e8-b9dc-3a9ac69853eb"), "1", 25 },
                    { new Guid("bc28d6c2-59f6-4ecd-a27f-f113943ff1f4"), "40", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3717), "Biến thể 2 của Sản phẩm 5 - Thùng câu", null, null, 600000m, new Guid("590db8c3-cc86-412a-8137-53acae19a4ee"), "1", 8 }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Price", "ProductId", "Status", "Stock" },
                values: new object[,]
                {
                    { new Guid("bf773f50-07d2-4891-83fc-6d3d504c84ea"), "40", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3803), "Biến thể 2 của Sản phẩm 13 - Thùng câu", null, null, 610000m, new Guid("5ebd6b86-f18c-4ff1-8f00-de9fa00c3c81"), "1", 10 },
                    { new Guid("c08210b2-dc77-4526-a061-6f79384bd478"), "30", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3716), "Biến thể 1 của Sản phẩm 5 - Thùng câu", null, null, 500000m, new Guid("590db8c3-cc86-412a-8137-53acae19a4ee"), "1", 10 },
                    { new Guid("c276bd85-2fcc-4cfd-a4a1-896e5204dc06"), "10", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3869), "Biến thể 1 của Sản phẩm 19 - Thẻo", null, null, 60000m, new Guid("c01bdc82-42c3-4ebf-be46-67658c631632"), "1", 50 },
                    { new Guid("cdcd72fa-e672-4be5-84fd-7cd138c92481"), "20", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3658), "Biến thể 2 của Sản phẩm 3 - Thẻo", null, null, 60000m, new Guid("b9ee5c58-0884-449a-8eb8-f85b18ada50a"), "1", 40 },
                    { new Guid("d097057a-9329-4435-bfa6-f67aface897a"), "Mồi tự nhiên", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3732), "Biến thể 2 của Sản phẩm 7 - Mồi", null, null, 35000m, new Guid("340bae4a-825e-4225-9efd-a76be28484b7"), "1", 90 },
                    { new Guid("d24c4c78-886a-4fd1-8e76-de046ae3c6f8"), "Thép", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3825), "Biến thể 2 của Sản phẩm 16 - Gác cần", null, null, 95000m, new Guid("af6c847e-e4e1-447a-90df-c9acc6235bbb"), "1", 28 },
                    { new Guid("d84bf9fc-6b4e-4dc5-8e2e-6da41167ca95"), "5.4", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3634), "Biến thể 3 của Sản phẩm 1 - Cần câu đài", null, null, 250000m, new Guid("77912245-2de7-471e-bdaf-018ad9f0f846"), "1", 10 },
                    { new Guid("d9bec677-e371-4e3d-9d2a-6f1366bb67bf"), "5.2:1", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3647), "Biến thể 1 của Sản phẩm 2 - Trục", null, null, 300000m, new Guid("2063aca9-cde4-4919-a8db-2e2886ed1615"), "1", 25 },
                    { new Guid("da50230a-5ec8-4bd0-b404-0cd6a016199f"), "5.4", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3750), "Biến thể 3 của Sản phẩm 9 - Cần câu đài", null, null, 260000m, new Guid("8f35d0e1-260d-4667-bc7b-c93c728a180b"), "1", 12 },
                    { new Guid("dd2c36cd-8c09-48a0-9f7c-1a543948bb49"), "4.5", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3749), "Biến thể 2 của Sản phẩm 9 - Cần câu đài", null, null, 210000m, new Guid("8f35d0e1-260d-4667-bc7b-c93c728a180b"), "1", 14 },
                    { new Guid("de09ef18-b701-4789-a47d-adb945b2f3d0"), "6.2:1", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3780), "Biến thể 2 của Sản phẩm 10 - Trục", null, null, 360000m, new Guid("05d2bd13-8521-4035-bfb8-338763616e04"), "1", 18 },
                    { new Guid("df6cffe9-10de-48c2-b578-21ce8792e237"), "3.6", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3747), "Biến thể 1 của Sản phẩm 9 - Cần câu đài", null, null, 160000m, new Guid("8f35d0e1-260d-4667-bc7b-c93c728a180b"), "1", 18 },
                    { new Guid("e347cb86-9880-4f38-ae57-483f60a45205"), "7.0:1", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3650), "Biến thể 3 của Sản phẩm 2 - Trục", null, null, 400000m, new Guid("2063aca9-cde4-4919-a8db-2e2886ed1615"), "1", 15 },
                    { new Guid("e97e86e1-d583-4222-8355-cc241ae560b9"), "50", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3804), "Biến thể 3 của Sản phẩm 13 - Thùng câu", null, null, 710000m, new Guid("5ebd6b86-f18c-4ff1-8f00-de9fa00c3c81"), "1", 8 },
                    { new Guid("ea07fff7-b097-45c6-a9ff-448043888722"), "50", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3809), "Biến thể 1 của Sản phẩm 14 - Giọ", null, null, 110000m, new Guid("b0acab70-6b39-4b2a-a359-3c91fb099d01"), "1", 28 },
                    { new Guid("f3cf143a-3db0-4b7e-8d9c-cec1e511ca04"), "30", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3788), "Biến thể 3 của Sản phẩm 11 - Thẻo", null, null, 75000m, new Guid("faa14773-a87d-4928-9805-ffe043ffd734"), "1", 35 },
                    { new Guid("fb0f65f0-4ab5-4128-a0ce-a8ceb722167d"), "5.2:1", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3863), "Biến thể 1 của Sản phẩm 18 - Trục", null, null, 320000m, new Guid("5c6778f2-a040-4af9-b348-2444928c255b"), "1", 20 },
                    { new Guid("fd96e039-feed-40cd-a70b-22f57e7c912a"), "50", null, new DateTime(2025, 5, 30, 7, 0, 56, 508, DateTimeKind.Local).AddTicks(3719), "Biến thể 3 của Sản phẩm 5 - Thùng câu", null, null, 700000m, new Guid("590db8c3-cc86-412a-8137-53acae19a4ee"), "1", 6 }
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
                name: "CartItemViewModels");

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
