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
                    { new Guid("4a9135ed-5996-4039-b193-48224a46f578"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7911), null, null, null, "Phao", "1" },
                    { new Guid("6db8ef9e-bf35-4109-92b7-d954dc09b676"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7916), null, null, null, "Gác cần", "1" },
                    { new Guid("7c0ab97b-8fca-4def-9641-c1eb7b954401"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7914), null, null, null, "Giọ", "1" },
                    { new Guid("8ad4464c-ace7-48c5-baf5-4fe15c243d5a"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7909), null, null, null, "Trục", "1" },
                    { new Guid("8b0d1f15-67b9-47f5-9ced-d45730f48bd4"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7907), null, null, null, "Cần câu đài", "1" },
                    { new Guid("c96caa06-b37c-4bce-b1ab-9617d4cc8b25"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7912), null, null, null, "Thùng câu", "1" },
                    { new Guid("d1f642d0-f86f-4c51-907d-b704af45efb9"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7910), null, null, null, "Thẻo", "1" },
                    { new Guid("fdafc182-8aec-4b11-b364-73409f2e725e"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7915), null, null, null, "Mồi", "1" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "ImageUrl", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("192e276f-c218-4aca-a2b3-b028bcdd9565"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7771), "Thương hiệu đồ câu cá hàng đầu thế giới", null, "Shimano", "1" },
                    { new Guid("3c482e5f-280b-43bf-a892-1ee951e0a54c"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7772), "Chuyên sản xuất mồi câu cá", null, "Rapala", "1" },
                    { new Guid("4844c4d0-bfe0-48db-814d-0a3a3709e496"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7868), "Nhà sản xuất dây câu chất lượng", null, "Sufix", "1" },
                    { new Guid("54d77a39-7027-43f3-b6dd-4d6d4a611aa3"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7869), "Chuyên sản xuất lưỡi câu", null, "Gamakatsu", "1" },
                    { new Guid("631768d1-cd37-447f-bce0-fbbc03f5d543"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7774), "Thương hiệu trục câu nổi tiếng", null, "Abu Garcia", "1" },
                    { new Guid("8a82f859-48af-4280-a438-33aae6d35db8"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7775), "Nhà sản xuất đồ câu chất lượng cao", null, "Okuma", "1" },
                    { new Guid("95b8ef4d-75e4-4003-9849-e67363d24cc9"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7870), "Thương hiệu lưỡi câu nổi tiếng", null, "Mustad", "1" },
                    { new Guid("9adbb974-f118-48c8-911f-a682aa1da0ab"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7773), "Nhà sản xuất mồi và phụ kiện câu cá", null, "Berkley", "1" },
                    { new Guid("e24b6a19-e02a-47ca-a1d4-2be2b823e8b2"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7865), "Chuyên về trục và cần câu biển", null, "Penn", "1" },
                    { new Guid("ed60e32b-b85c-4bea-87a5-70fcf27cbadd"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7761), "Nhà sản xuất cần câu nổi tiếng từ Nhật Bản", null, "Daiwa", "1" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Email", "ModifiedBy", "ModifiedTime", "Password", "PhoneNumber", "Status", "UserType", "Username" },
                values: new object[] { new Guid("46e93eb3-9c28-4d87-a0f2-c934f73baa3a"), null, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "fishingbee2024@gmail.com", null, null, "AQAAAAEAACcQAAAAEO+w+xymiphZOo0689b2mJUacuTEJ3UE/FNan/UfcHxhgkuR6Pop2x0KMp/VeSLorw==", "0123456789", "1", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Descriptions", "FullName", "ModifiedBy", "ModifiedTime", "Permissions", "Status", "UserId", "UserType" },
                values: new object[] { new Guid("91909257-d2c9-49c5-b776-90c5a975f1be"), null, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default Admin", "Super Admin", null, null, "All", "1", new Guid("46e93eb3-9c28-4d87-a0f2-c934f73baa3a"), "Admin" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AttributeName", "AttributeUnit", "CategoryId", "CreatedBy", "CreatedTime", "ManufacturerId", "ModifiedBy", "ModifiedTime", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("02fdb70e-f3d2-45f4-bc33-668a201c5600"), "Chiều dài", "m", new Guid("8b0d1f15-67b9-47f5-9ced-d45730f48bd4"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8379), new Guid("e24b6a19-e02a-47ca-a1d4-2be2b823e8b2"), null, null, "Sản phẩm 17 - Cần câu đài", "1" },
                    { new Guid("0ea7cd28-5319-43c6-a794-9b3443bd6886"), "Kích thước", "cm", new Guid("7c0ab97b-8fca-4def-9641-c1eb7b954401"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8349), new Guid("9adbb974-f118-48c8-911f-a682aa1da0ab"), null, null, "Sản phẩm 14 - Giọ", "1" },
                    { new Guid("22076318-3e87-471c-bf2a-bf8db27ae496"), "Độ bền", "lb", new Guid("d1f642d0-f86f-4c51-907d-b704af45efb9"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8001), new Guid("3c482e5f-280b-43bf-a892-1ee951e0a54c"), null, null, "Sản phẩm 3 - Thẻo", "1" },
                    { new Guid("2df3ac10-4309-400e-a6ca-6a92b681268a"), "Loại mồi", "", new Guid("fdafc182-8aec-4b11-b364-73409f2e725e"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8083), new Guid("e24b6a19-e02a-47ca-a1d4-2be2b823e8b2"), null, null, "Sản phẩm 7 - Mồi", "1" },
                    { new Guid("31438e07-2be9-48c9-981d-68c41b19e9d2"), "Chiều dài", "m", new Guid("8b0d1f15-67b9-47f5-9ced-d45730f48bd4"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7957), new Guid("ed60e32b-b85c-4bea-87a5-70fcf27cbadd"), null, null, "Sản phẩm 1 - Cần câu đài", "1" },
                    { new Guid("33a7bbe5-cbea-46ba-9984-99e9cdbceb5c"), "Dung tích", "lít", new Guid("c96caa06-b37c-4bce-b1ab-9617d4cc8b25"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8055), new Guid("631768d1-cd37-447f-bce0-fbbc03f5d543"), null, null, "Sản phẩm 5 - Thùng câu", "1" },
                    { new Guid("39f89dd1-8dd5-4e84-a212-f7d0e8a819fa"), "Loại mồi", "", new Guid("fdafc182-8aec-4b11-b364-73409f2e725e"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8358), new Guid("631768d1-cd37-447f-bce0-fbbc03f5d543"), null, null, "Sản phẩm 15 - Mồi", "1" },
                    { new Guid("4682476d-cded-4967-b52b-d5660372223a"), "Kích thước", "cm", new Guid("4a9135ed-5996-4039-b193-48224a46f578"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8444), new Guid("95b8ef4d-75e4-4003-9849-e67363d24cc9"), null, null, "Sản phẩm 20 - Phao", "1" },
                    { new Guid("4cac83f3-1cac-4886-88cb-c5007695eb5c"), "Kích thước", "cm", new Guid("7c0ab97b-8fca-4def-9641-c1eb7b954401"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8070), new Guid("8a82f859-48af-4280-a438-33aae6d35db8"), null, null, "Sản phẩm 6 - Giọ", "1" },
                    { new Guid("69beb8a2-795c-4aee-842e-06ca9507dab3"), "Kích thước", "cm", new Guid("4a9135ed-5996-4039-b193-48224a46f578"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8328), new Guid("192e276f-c218-4aca-a2b3-b028bcdd9565"), null, null, "Sản phẩm 12 - Phao", "1" },
                    { new Guid("9e893e2e-fa9b-4286-9bb9-fa158fff56dd"), "Chất liệu", "", new Guid("6db8ef9e-bf35-4109-92b7-d954dc09b676"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8370), new Guid("8a82f859-48af-4280-a438-33aae6d35db8"), null, null, "Sản phẩm 16 - Gác cần", "1" },
                    { new Guid("a2b2831b-b0a0-495a-931e-2ffc1b0d407b"), "Dung tích", "lít", new Guid("c96caa06-b37c-4bce-b1ab-9617d4cc8b25"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8338), new Guid("3c482e5f-280b-43bf-a892-1ee951e0a54c"), null, null, "Sản phẩm 13 - Thùng câu", "1" },
                    { new Guid("bbcce8d1-9cf3-4de2-8a37-8d69bc308034"), "Chiều dài", "m", new Guid("8b0d1f15-67b9-47f5-9ced-d45730f48bd4"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8241), new Guid("54d77a39-7027-43f3-b6dd-4d6d4a611aa3"), null, null, "Sản phẩm 9 - Cần câu đài", "1" },
                    { new Guid("c6ef944b-fcd4-4bbd-a165-0ce012c09f25"), "Tỷ lệ truyền", "", new Guid("8ad4464c-ace7-48c5-baf5-4fe15c243d5a"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7988), new Guid("192e276f-c218-4aca-a2b3-b028bcdd9565"), null, null, "Sản phẩm 2 - Trục", "1" },
                    { new Guid("cc7e3878-a10c-40da-a621-53d2034ad629"), "Kích thước", "cm", new Guid("4a9135ed-5996-4039-b193-48224a46f578"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8015), new Guid("9adbb974-f118-48c8-911f-a682aa1da0ab"), null, null, "Sản phẩm 4 - Phao", "1" },
                    { new Guid("d0256592-aaec-4c9f-a378-93a970f8b4ce"), "Độ bền", "lb", new Guid("d1f642d0-f86f-4c51-907d-b704af45efb9"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8264), new Guid("ed60e32b-b85c-4bea-87a5-70fcf27cbadd"), null, null, "Sản phẩm 11 - Thẻo", "1" },
                    { new Guid("da29e6be-6af1-4b7d-b6e8-eb7aa3b22711"), "Chất liệu", "", new Guid("6db8ef9e-bf35-4109-92b7-d954dc09b676"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8230), new Guid("4844c4d0-bfe0-48db-814d-0a3a3709e496"), null, null, "Sản phẩm 8 - Gác cần", "1" },
                    { new Guid("e36865e7-cee7-48f1-8640-684666aaba8a"), "Độ bền", "lb", new Guid("d1f642d0-f86f-4c51-907d-b704af45efb9"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8432), new Guid("54d77a39-7027-43f3-b6dd-4d6d4a611aa3"), null, null, "Sản phẩm 19 - Thẻo", "1" },
                    { new Guid("e8608b9b-98cb-4fa6-bee7-ddd1d5e7bbce"), "Tỷ lệ truyền", "", new Guid("8ad4464c-ace7-48c5-baf5-4fe15c243d5a"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8421), new Guid("4844c4d0-bfe0-48db-814d-0a3a3709e496"), null, null, "Sản phẩm 18 - Trục", "1" },
                    { new Guid("e9d972a0-97a1-4123-ba04-42ca718a114a"), "Tỷ lệ truyền", "", new Guid("8ad4464c-ace7-48c5-baf5-4fe15c243d5a"), null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8254), new Guid("95b8ef4d-75e4-4003-9849-e67363d24cc9"), null, null, "Sản phẩm 10 - Trục", "1" }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Price", "ProductId", "Status", "Stock" },
                values: new object[,]
                {
                    { new Guid("0c22603b-49b4-4fc6-ab42-3ad7a030641e"), "30", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8011), "Biến thể 3 của Sản phẩm 3 - Thẻo", null, null, 70000m, new Guid("22076318-3e87-471c-bf2a-bf8db27ae496"), "1", 30m },
                    { new Guid("0d0121fa-8b79-4383-9087-e4fc2e28afaf"), "Thép", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8374), "Biến thể 2 của Sản phẩm 16 - Gác cần", null, null, 95000m, new Guid("9e893e2e-fa9b-4286-9bb9-fa158fff56dd"), "1", 28m },
                    { new Guid("1112fc09-d9d1-48d9-ae6d-4e7d9fff7321"), "20", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8319), "Biến thể 2 của Sản phẩm 11 - Thẻo", null, null, 65000m, new Guid("d0256592-aaec-4c9f-a378-93a970f8b4ce"), "1", 45m },
                    { new Guid("12028a00-2d43-4b3c-8daa-6ead00f2acf0"), "Nhôm", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8372), "Biến thể 1 của Sản phẩm 16 - Gác cần", null, null, 85000m, new Guid("9e893e2e-fa9b-4286-9bb9-fa158fff56dd"), "1", 32m },
                    { new Guid("14eaae53-dc9b-49cf-9eeb-dedb0f4a9e1a"), "2.5", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8446), "Biến thể 1 của Sản phẩm 20 - Phao", null, null, 23000m, new Guid("4682476d-cded-4967-b52b-d5660372223a"), "1", 60m },
                    { new Guid("168e5996-c3c4-49da-b1ca-6a84b97b968e"), "7.0:1", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8262), "Biến thể 3 của Sản phẩm 10 - Trục", null, null, 410000m, new Guid("e9d972a0-97a1-4123-ba04-42ca718a114a"), "1", 14m },
                    { new Guid("1781dfa8-9725-4e70-9018-add3e65c6cf1"), "5.2:1", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8257), "Biến thể 1 của Sản phẩm 10 - Trục", null, null, 310000m, new Guid("e9d972a0-97a1-4123-ba04-42ca718a114a"), "1", 22m },
                    { new Guid("22eb3c37-f0cb-4cac-8c06-d773658b4db3"), "Mồi tự nhiên", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8222), "Biến thể 2 của Sản phẩm 7 - Mồi", null, null, 35000m, new Guid("2df3ac10-4309-400e-a6ca-6a92b681268a"), "1", 90m },
                    { new Guid("2555ebd2-b82e-4c9c-bab1-380b68dd0869"), "30", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8323), "Biến thể 3 của Sản phẩm 11 - Thẻo", null, null, 75000m, new Guid("d0256592-aaec-4c9f-a378-93a970f8b4ce"), "1", 35m },
                    { new Guid("27c24ac6-04fb-4e4b-adac-6ebdfef24cca"), "Thép", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8234), "Biến thể 2 của Sản phẩm 8 - Gác cần", null, null, 90000m, new Guid("da29e6be-6af1-4b7d-b6e8-eb7aa3b22711"), "1", 30m },
                    { new Guid("2b27c123-e727-492a-a48f-1e9f4caff926"), "10", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8435), "Biến thể 1 của Sản phẩm 19 - Thẻo", null, null, 60000m, new Guid("e36865e7-cee7-48f1-8640-684666aaba8a"), "1", 50m },
                    { new Guid("35a0b6a1-14f2-49cf-9b58-b2a3113b3900"), "3.0", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8020), "Biến thể 2 của Sản phẩm 4 - Phao", null, null, 25000m, new Guid("cc7e3878-a10c-40da-a621-53d2034ad629"), "1", 50m },
                    { new Guid("387dc0ee-fd6b-401f-8252-07ddf32c44c7"), "7.0:1", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8429), "Biến thể 3 của Sản phẩm 18 - Trục", null, null, 420000m, new Guid("e8608b9b-98cb-4fa6-bee7-ddd1d5e7bbce"), "1", 12m },
                    { new Guid("3943f55b-8072-4338-a110-5d25c814ab11"), "10", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8266), "Biến thể 1 của Sản phẩm 11 - Thẻo", null, null, 55000m, new Guid("d0256592-aaec-4c9f-a378-93a970f8b4ce"), "1", 55m },
                    { new Guid("394acc0e-2b2c-420a-b6e8-3dcff1edd905"), "30", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8340), "Biến thể 1 của Sản phẩm 13 - Thùng câu", null, null, 510000m, new Guid("a2b2831b-b0a0-495a-931e-2ffc1b0d407b"), "1", 12m },
                    { new Guid("3c3520ef-8fdc-4ed0-9a7c-5bde0afa7fef"), "50", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8346), "Biến thể 3 của Sản phẩm 13 - Thùng câu", null, null, 710000m, new Guid("a2b2831b-b0a0-495a-931e-2ffc1b0d407b"), "1", 8m },
                    { new Guid("410312bf-809a-47aa-b6e9-ab7df37ae24c"), "6.2:1", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8260), "Biến thể 2 của Sản phẩm 10 - Trục", null, null, 360000m, new Guid("e9d972a0-97a1-4123-ba04-42ca718a114a"), "1", 18m },
                    { new Guid("45271892-f3fc-4f85-83c0-80e351a45609"), "40", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8342), "Biến thể 2 của Sản phẩm 13 - Thùng câu", null, null, 610000m, new Guid("a2b2831b-b0a0-495a-931e-2ffc1b0d407b"), "1", 10m },
                    { new Guid("4965259c-4ddd-47ab-8de6-fc906e72141a"), "70", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8079), "Biến thể 3 của Sản phẩm 6 - Giọ", null, null, 140000m, new Guid("4cac83f3-1cac-4886-88cb-c5007695eb5c"), "1", 20m },
                    { new Guid("4c4980ba-6f09-4b55-9874-f8dfa276643d"), "20", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8005), "Biến thể 2 của Sản phẩm 3 - Thẻo", null, null, 60000m, new Guid("22076318-3e87-471c-bf2a-bf8db27ae496"), "1", 40m },
                    { new Guid("4c5a362c-0c09-4bf0-83aa-6db1d296603c"), "Mồi tổng hợp", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8365), "Biến thể 3 của Sản phẩm 15 - Mồi", null, null, 42000m, new Guid("39f89dd1-8dd5-4e84-a212-f7d0e8a819fa"), "1", 75m },
                    { new Guid("4f0f9c9c-30d2-4a1f-80c1-682e923a695c"), "6.2:1", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8427), "Biến thể 2 của Sản phẩm 18 - Trục", null, null, 370000m, new Guid("e8608b9b-98cb-4fa6-bee7-ddd1d5e7bbce"), "1", 16m },
                    { new Guid("4fd4f4bc-62b0-4f20-8fcb-d8cef923ffb4"), "3.0", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8333), "Biến thể 2 của Sản phẩm 12 - Phao", null, null, 27000m, new Guid("69beb8a2-795c-4aee-842e-06ca9507dab3"), "1", 55m },
                    { new Guid("53e65416-8c59-4a7a-a3f0-948c19d5d2d4"), "4.5", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8385), "Biến thể 2 của Sản phẩm 17 - Cần câu đài", null, null, 220000m, new Guid("02fdb70e-f3d2-45f4-bc33-668a201c5600"), "1", 12m },
                    { new Guid("55549a61-2e89-4ce9-b974-fbff839615cf"), "Carbon", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8239), "Biến thể 3 của Sản phẩm 8 - Gác cần", null, null, 100000m, new Guid("da29e6be-6af1-4b7d-b6e8-eb7aa3b22711"), "1", 25m },
                    { new Guid("55f6da8a-4c33-4c78-9251-8fb7a2510d0c"), "5.4", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8418), "Biến thể 3 của Sản phẩm 17 - Cần câu đài", null, null, 270000m, new Guid("02fdb70e-f3d2-45f4-bc33-668a201c5600"), "1", 10m },
                    { new Guid("56334688-b604-4ab0-a461-7982cb91ebf9"), "3.6", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7965), "Biến thể 1 của Sản phẩm 1 - Cần câu đài", null, null, 150000m, new Guid("31438e07-2be9-48c9-981d-68c41b19e9d2"), "1", 20m },
                    { new Guid("5676af76-4875-4cf0-89ff-7924cde8fbfe"), "5.2:1", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7991), "Biến thể 1 của Sản phẩm 2 - Trục", null, null, 300000m, new Guid("c6ef944b-fcd4-4bbd-a165-0ce012c09f25"), "1", 25m },
                    { new Guid("6877d051-31ee-4d5d-884c-71a69f17a3fc"), "70", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8355), "Biến thể 3 của Sản phẩm 14 - Giọ", null, null, 150000m, new Guid("0ea7cd28-5319-43c6-a794-9b3443bd6886"), "1", 18m },
                    { new Guid("6cd37228-cbf0-4c97-92e9-540734fdd7ac"), "4.5", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8247), "Biến thể 2 của Sản phẩm 9 - Cần câu đài", null, null, 210000m, new Guid("bbcce8d1-9cf3-4de2-8a37-8d69bc308034"), "1", 14m },
                    { new Guid("8c3bd5dc-4f9d-475e-8803-3c9d2ed821aa"), "7.0:1", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7996), "Biến thể 3 của Sản phẩm 2 - Trục", null, null, 400000m, new Guid("c6ef944b-fcd4-4bbd-a165-0ce012c09f25"), "1", 15m },
                    { new Guid("8d5f2803-75a5-4051-8191-4cdd931bc98a"), "6.2:1", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7993), "Biến thể 2 của Sản phẩm 2 - Trục", null, null, 350000m, new Guid("c6ef944b-fcd4-4bbd-a165-0ce012c09f25"), "1", 20m },
                    { new Guid("8fb16279-2734-4bd4-8c74-80f557e3d06d"), "3.5", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8335), "Biến thể 3 của Sản phẩm 12 - Phao", null, null, 32000m, new Guid("69beb8a2-795c-4aee-842e-06ca9507dab3"), "1", 45m },
                    { new Guid("934d221f-613d-466b-819a-1748de7001de"), "50", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8067), "Biến thể 3 của Sản phẩm 5 - Thùng câu", null, null, 700000m, new Guid("33a7bbe5-cbea-46ba-9984-99e9cdbceb5c"), "1", 6m },
                    { new Guid("94d42825-a143-44cf-984d-ae650cb87335"), "60", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8075), "Biến thể 2 của Sản phẩm 6 - Giọ", null, null, 120000m, new Guid("4cac83f3-1cac-4886-88cb-c5007695eb5c"), "1", 25m },
                    { new Guid("9cfb5acb-5547-41c7-88a0-77d7cc84f0a5"), "60", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8353), "Biến thể 2 của Sản phẩm 14 - Giọ", null, null, 130000m, new Guid("0ea7cd28-5319-43c6-a794-9b3443bd6886"), "1", 22m },
                    { new Guid("9f49fadc-6003-42c6-9859-60058776dbb9"), "Mồi giả", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8220), "Biến thể 1 của Sản phẩm 7 - Mồi", null, null, 30000m, new Guid("2df3ac10-4309-400e-a6ca-6a92b681268a"), "1", 100m },
                    { new Guid("a5493552-e871-4d24-85c6-eccca4fb5b31"), "50", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8072), "Biến thể 1 của Sản phẩm 6 - Giọ", null, null, 100000m, new Guid("4cac83f3-1cac-4886-88cb-c5007695eb5c"), "1", 30m },
                    { new Guid("a5b1de64-f0f0-418e-bc10-da47d8bacc8a"), "10", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8003), "Biến thể 1 của Sản phẩm 3 - Thẻo", null, null, 50000m, new Guid("22076318-3e87-471c-bf2a-bf8db27ae496"), "1", 50m },
                    { new Guid("a64f9c54-63f9-4230-82eb-3d40dcce4971"), "3.0", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8448), "Biến thể 2 của Sản phẩm 20 - Phao", null, null, 28000m, new Guid("4682476d-cded-4967-b52b-d5660372223a"), "1", 50m },
                    { new Guid("ab716a65-380f-4964-abaa-e2f0597b8a9e"), "30", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8059), "Biến thể 1 của Sản phẩm 5 - Thùng câu", null, null, 500000m, new Guid("33a7bbe5-cbea-46ba-9984-99e9cdbceb5c"), "1", 10m },
                    { new Guid("ae0c4b5c-6797-4889-be7c-154c8238162d"), "20", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8437), "Biến thể 2 của Sản phẩm 19 - Thẻo", null, null, 70000m, new Guid("e36865e7-cee7-48f1-8640-684666aaba8a"), "1", 40m }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "AttributeValue", "CreatedBy", "CreatedTime", "Description", "ModifiedBy", "ModifiedTime", "Price", "ProductId", "Status", "Stock" },
                values: new object[,]
                {
                    { new Guid("b0611d88-9162-446e-9211-a7eb4f0a3fb6"), "Mồi tổng hợp", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8227), "Biến thể 3 của Sản phẩm 7 - Mồi", null, null, 40000m, new Guid("2df3ac10-4309-400e-a6ca-6a92b681268a"), "1", 80m },
                    { new Guid("b1f97053-923e-451c-9116-0be21f1bf89c"), "40", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8062), "Biến thể 2 của Sản phẩm 5 - Thùng câu", null, null, 600000m, new Guid("33a7bbe5-cbea-46ba-9984-99e9cdbceb5c"), "1", 8m },
                    { new Guid("b21aa2fb-2004-4720-913d-7b96c1dda3d6"), "5.4", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7975), "Biến thể 3 của Sản phẩm 1 - Cần câu đài", null, null, 250000m, new Guid("31438e07-2be9-48c9-981d-68c41b19e9d2"), "1", 10m },
                    { new Guid("b47a733e-c39c-47d8-b660-8cfaaebfe951"), "Mồi tự nhiên", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8361), "Biến thể 2 của Sản phẩm 15 - Mồi", null, null, 37000m, new Guid("39f89dd1-8dd5-4e84-a212-f7d0e8a819fa"), "1", 85m },
                    { new Guid("ba1a779b-eb0b-4db4-a619-68df6a3f03d4"), "3.6", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8383), "Biến thể 1 của Sản phẩm 17 - Cần câu đài", null, null, 170000m, new Guid("02fdb70e-f3d2-45f4-bc33-668a201c5600"), "1", 16m },
                    { new Guid("bbf660a2-05d9-4024-b497-e70004f0fe70"), "2.5", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8017), "Biến thể 1 của Sản phẩm 4 - Phao", null, null, 20000m, new Guid("cc7e3878-a10c-40da-a621-53d2034ad629"), "1", 60m },
                    { new Guid("cfd54765-5c74-49a9-830c-397697f72070"), "3.6", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8245), "Biến thể 1 của Sản phẩm 9 - Cần câu đài", null, null, 160000m, new Guid("bbcce8d1-9cf3-4de2-8a37-8d69bc308034"), "1", 18m },
                    { new Guid("d191a4de-6b33-481f-9dc5-8154ca32d0b0"), "4.5", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(7970), "Biến thể 2 của Sản phẩm 1 - Cần câu đài", null, null, 200000m, new Guid("31438e07-2be9-48c9-981d-68c41b19e9d2"), "1", 15m },
                    { new Guid("e0ed6390-488f-49b4-9af8-3b9107866975"), "5.2:1", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8423), "Biến thể 1 của Sản phẩm 18 - Trục", null, null, 320000m, new Guid("e8608b9b-98cb-4fa6-bee7-ddd1d5e7bbce"), "1", 20m },
                    { new Guid("e1bb975b-b7b7-4960-90f7-793e952075f2"), "50", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8351), "Biến thể 1 của Sản phẩm 14 - Giọ", null, null, 110000m, new Guid("0ea7cd28-5319-43c6-a794-9b3443bd6886"), "1", 28m },
                    { new Guid("e5f4a414-23b1-4c5a-ac29-76c7cd8e8fb3"), "Carbon", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8376), "Biến thể 3 của Sản phẩm 16 - Gác cần", null, null, 105000m, new Guid("9e893e2e-fa9b-4286-9bb9-fa158fff56dd"), "1", 22m },
                    { new Guid("e71443a9-5113-4f21-a090-f658a54f0eff"), "3.5", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8450), "Biến thể 3 của Sản phẩm 20 - Phao", null, null, 33000m, new Guid("4682476d-cded-4967-b52b-d5660372223a"), "1", 40m },
                    { new Guid("e72b92b4-c255-47f6-9abc-b3ca8e81461b"), "3.5", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8052), "Biến thể 3 của Sản phẩm 4 - Phao", null, null, 30000m, new Guid("cc7e3878-a10c-40da-a621-53d2034ad629"), "1", 40m },
                    { new Guid("e778c386-2a86-4154-b855-e8df3278fe5f"), "Nhôm", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8232), "Biến thể 1 của Sản phẩm 8 - Gác cần", null, null, 80000m, new Guid("da29e6be-6af1-4b7d-b6e8-eb7aa3b22711"), "1", 35m },
                    { new Guid("f782dcdb-14eb-49fe-968a-4229480c9dd9"), "2.5", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8330), "Biến thể 1 của Sản phẩm 12 - Phao", null, null, 22000m, new Guid("69beb8a2-795c-4aee-842e-06ca9507dab3"), "1", 65m },
                    { new Guid("f836a19e-fe54-47d3-a1e7-9e37a07d29ac"), "30", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8441), "Biến thể 3 của Sản phẩm 19 - Thẻo", null, null, 80000m, new Guid("e36865e7-cee7-48f1-8640-684666aaba8a"), "1", 30m },
                    { new Guid("f91936c0-6d02-4a5f-92b3-5eaa7909e82d"), "Mồi giả", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8360), "Biến thể 1 của Sản phẩm 15 - Mồi", null, null, 32000m, new Guid("39f89dd1-8dd5-4e84-a212-f7d0e8a819fa"), "1", 95m },
                    { new Guid("ffe35dcf-1fe4-4bda-944c-b0e30b152d1d"), "5.4", null, new DateTime(2025, 5, 24, 20, 50, 6, 940, DateTimeKind.Local).AddTicks(8251), "Biến thể 3 của Sản phẩm 9 - Cần câu đài", null, null, 260000m, new Guid("bbcce8d1-9cf3-4de2-8a37-8d69bc308034"), "1", 12m }
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
