using Data_FishingBee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.ContextFile
{
    public class FishingBeeDbContext : DbContext
    {
        public FishingBeeDbContext()
        {

        }

        public FishingBeeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Cart_PD> Cart_PDs { get; set; }
        public DbSet<CartItemViewModel> CartItemViewModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerActivityLog> CustomerActivityLogs { get; set; }
        public DbSet<CustomerSupport> CustomerSupports { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ImportHistory> ImportHistories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductViewModel> productViewModels { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=PHẠM-TIẾN-DŨNG;Database=FishingBee;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Inventory>()
            .HasOne(i => i.ProductDetail)
            .WithOne(p => p.Inventory)
            .HasForeignKey<Inventory>(i => i.Id);

            modelBuilder.Entity<CustomerSupport>(entity =>
            {
                entity.HasKey(cs => cs.Id);

                entity.HasOne(cs => cs.Admin)
                    .WithMany() // Không cần danh sách ngược nếu không dùng
                    .HasForeignKey(cs => cs.AdminId)
                    .OnDelete(DeleteBehavior.Cascade); // Chỉ giữ CASCADE ở một chỗ

                entity.HasOne(cs => cs.Customer)
                    .WithMany(c => c.CustomerSupports) // Nếu Customer có danh sách CustomerSupports
                    .HasForeignKey(cs => cs.CustomerId)
                    .OnDelete(DeleteBehavior.NoAction); // Đổi thành NoAction để tránh lỗi

                entity.Property(cs => cs.Subject)
                    .IsRequired();

                entity.Property(cs => cs.Description)
                    .IsRequired();
            });

            Guid adminId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            // Hash password
            var hasher = new PasswordHasher<User>();
            // Seed User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId,
                    Username = "admin",
                    Email = "fishingbee2024@gmail.com",
                    Password = hasher.HashPassword(null, "Admin@123"), // Hash password
                    PhoneNumber = "0123456789",
                    UserType = "Admin",
                    Status = "1",
                    CreatedTime = new DateTime(2025, 3, 20),
                    CreatedBy = null
                }
            );

            // Seed Admin
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = adminId,
                    UserId = userId,
                    FullName = "Super Admin",
                    Permissions = "All",
                    Status = "1",
                    Descriptions = "Default Admin",
                    UserType = "Admin",
                    CreatedTime = new DateTime(2025, 3, 20),
                    CreatedBy = null
                }
            );


            // Seed Manufacturers
            var manufacturer1Id = Guid.NewGuid();
            var manufacturer2Id = Guid.NewGuid();
            var manufacturer3Id = Guid.NewGuid();
            var manufacturer4Id = Guid.NewGuid();
            var manufacturer5Id = Guid.NewGuid();
            var manufacturer6Id = Guid.NewGuid();
            var manufacturer7Id = Guid.NewGuid();
            var manufacturer8Id = Guid.NewGuid();
            var manufacturer9Id = Guid.NewGuid();
            var manufacturer10Id = Guid.NewGuid();

            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = manufacturer1Id, Name = "Daiwa", Status = "1", CreatedTime = DateTime.Now, Description = "Nhà sản xuất cần câu nổi tiếng từ Nhật Bản" },
                new Manufacturer { Id = manufacturer2Id, Name = "Shimano", Status = "1", CreatedTime = DateTime.Now, Description = "Thương hiệu đồ câu cá hàng đầu thế giới" },
                new Manufacturer { Id = manufacturer3Id, Name = "Rapala", Status = "1", CreatedTime = DateTime.Now, Description = "Chuyên sản xuất mồi câu cá" },
                new Manufacturer { Id = manufacturer4Id, Name = "Berkley", Status = "1", CreatedTime = DateTime.Now, Description = "Nhà sản xuất mồi và phụ kiện câu cá" },
                new Manufacturer { Id = manufacturer5Id, Name = "Abu Garcia", Status = "1", CreatedTime = DateTime.Now, Description = "Thương hiệu trục câu nổi tiếng" },
                new Manufacturer { Id = manufacturer6Id, Name = "Okuma", Status = "1", CreatedTime = DateTime.Now, Description = "Nhà sản xuất đồ câu chất lượng cao" },
                new Manufacturer { Id = manufacturer7Id, Name = "Penn", Status = "1", CreatedTime = DateTime.Now, Description = "Chuyên về trục và cần câu biển" },
                new Manufacturer { Id = manufacturer8Id, Name = "Sufix", Status = "1", CreatedTime = DateTime.Now, Description = "Nhà sản xuất dây câu chất lượng" },
                new Manufacturer { Id = manufacturer9Id, Name = "Gamakatsu", Status = "1", CreatedTime = DateTime.Now, Description = "Chuyên sản xuất lưỡi câu" },
                new Manufacturer { Id = manufacturer10Id, Name = "Mustad", Status = "1", CreatedTime = DateTime.Now, Description = "Thương hiệu lưỡi câu nổi tiếng" }
            );

            // Seed Categories
            var idCate1 = Guid.NewGuid();
            var idCate2 = Guid.NewGuid();
            var idCate3 = Guid.NewGuid();
            var idCate4 = Guid.NewGuid();
            var idCate5 = Guid.NewGuid();
            var idCate6 = Guid.NewGuid();
            var idCate7 = Guid.NewGuid();
            var idCate8 = Guid.NewGuid();

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = idCate1, Name = "Cần câu đài", Status = "1", CreatedTime = DateTime.Now },
                new Category { Id = idCate2, Name = "Trục", Status = "1", CreatedTime = DateTime.Now },
                new Category { Id = idCate3, Name = "Thẻo", Status = "1", CreatedTime = DateTime.Now },
                new Category { Id = idCate4, Name = "Phao", Status = "1", CreatedTime = DateTime.Now },
                new Category { Id = idCate5, Name = "Thùng câu", Status = "1", CreatedTime = DateTime.Now },
                new Category { Id = idCate6, Name = "Giọ", Status = "1", CreatedTime = DateTime.Now },
                new Category { Id = idCate7, Name = "Mồi", Status = "1", CreatedTime = DateTime.Now },
                new Category { Id = idCate8, Name = "Gác cần", Status = "1", CreatedTime = DateTime.Now }
            );

            // Seed Products and ProductDetails
            var products = new List<Product>();
            var productDetails = new List<ProductDetail>();
            var categoryIds = new[] { idCate1, idCate2, idCate3, idCate4, idCate5, idCate6, idCate7, idCate8 };
            var manufacturerIds = new[] { manufacturer1Id, manufacturer2Id, manufacturer3Id, manufacturer4Id, manufacturer5Id,
                                          manufacturer6Id, manufacturer7Id, manufacturer8Id, manufacturer9Id, manufacturer10Id };
            var random = new Random();

            // Product 1
            var product1Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product1Id,
                CategoryId = idCate1,
                ManufacturerId = manufacturer1Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 1 - Cần câu đài",
                AttributeName = "Chiều dài",
                AttributeUnit = "m"
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product1Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 1 - Cần câu đài", AttributeValue = "3.6", Price = 150000m, Stock = 20 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product1Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 1 - Cần câu đài", AttributeValue = "4.5", Price = 200000m, Stock = 15 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product1Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 1 - Cần câu đài", AttributeValue = "5.4", Price = 250000m, Stock = 10 }
            });

            // Product 2
            var product2Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product2Id,
                CategoryId = idCate2,
                ManufacturerId = manufacturer2Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 2 - Trục",
                AttributeName = "Tỷ lệ truyền",
                AttributeUnit = ""
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product2Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 2 - Trục", AttributeValue = "5.2:1", Price = 300000m, Stock = 25 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product2Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 2 - Trục", AttributeValue = "6.2:1", Price = 350000m, Stock = 20 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product2Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 2 - Trục", AttributeValue = "7.0:1", Price = 400000m, Stock = 15 }
            });

            // Product 3
            var product3Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product3Id,
                CategoryId = idCate3,
                ManufacturerId = manufacturer3Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 3 - Thẻo",
                AttributeName = "Độ bền",
                AttributeUnit = "lb"
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product3Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 3 - Thẻo", AttributeValue = "10", Price = 50000m, Stock = 50 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product3Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 3 - Thẻo", AttributeValue = "20", Price = 60000m, Stock = 40 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product3Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 3 - Thẻo", AttributeValue = "30", Price = 70000m, Stock = 30 }
            });

            // Product 4
            var product4Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product4Id,
                CategoryId = idCate4,
                ManufacturerId = manufacturer4Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 4 - Phao",
                AttributeName = "Kích thước",
                AttributeUnit = "cm"
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product4Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 4 - Phao", AttributeValue = "2.5", Price = 20000m, Stock = 60 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product4Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 4 - Phao", AttributeValue = "3.0", Price = 25000m, Stock = 50 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product4Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 4 - Phao", AttributeValue = "3.5", Price = 30000m, Stock = 40 }
            });

            // Product 5
            var product5Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product5Id,
                CategoryId = idCate5,
                ManufacturerId = manufacturer5Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 5 - Thùng câu",
                AttributeName = "Dung tích",
                AttributeUnit = "lít"
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product5Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 5 - Thùng câu", AttributeValue = "30", Price = 500000m, Stock = 10 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product5Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 5 - Thùng câu", AttributeValue = "40", Price = 600000m, Stock = 8 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product5Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 5 - Thùng câu", AttributeValue = "50", Price = 700000m, Stock = 6 }
            });

            // Product 6
            var product6Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product6Id,
                CategoryId = idCate6,
                ManufacturerId = manufacturer6Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 6 - Giọ",
                AttributeName = "Kích thước",
                AttributeUnit = "cm"
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product6Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 6 - Giọ", AttributeValue = "50", Price = 100000m, Stock = 30 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product6Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 6 - Giọ", AttributeValue = "60", Price = 120000m, Stock = 25 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product6Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 6 - Giọ", AttributeValue = "70", Price = 140000m, Stock = 20 }
            });

            // Product 7
            var product7Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product7Id,
                CategoryId = idCate7,
                ManufacturerId = manufacturer7Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 7 - Mồi",
                AttributeName = "Loại mồi",
                AttributeUnit = ""
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product7Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 7 - Mồi", AttributeValue = "Mồi giả", Price = 30000m, Stock = 100 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product7Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 7 - Mồi", AttributeValue = "Mồi tự nhiên", Price = 35000m, Stock = 90 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product7Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 7 - Mồi", AttributeValue = "Mồi tổng hợp", Price = 40000m, Stock = 80 }
            });

            // Product 8
            var product8Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product8Id,
                CategoryId = idCate8,
                ManufacturerId = manufacturer8Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 8 - Gác cần",
                AttributeName = "Chất liệu",
                AttributeUnit = ""
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product8Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 8 - Gác cần", AttributeValue = "Nhôm", Price = 80000m, Stock = 35 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product8Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 8 - Gác cần", AttributeValue = "Thép", Price = 90000m, Stock = 30 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product8Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 8 - Gác cần", AttributeValue = "Carbon", Price = 100000m, Stock = 25 }
            });

            // Product 9
            var product9Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product9Id,
                CategoryId = idCate1,
                ManufacturerId = manufacturer9Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 9 - Cần câu đài",
                AttributeName = "Chiều dài",
                AttributeUnit = "m"
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product9Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 9 - Cần câu đài", AttributeValue = "3.6", Price = 160000m, Stock = 18 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product9Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 9 - Cần câu đài", AttributeValue = "4.5", Price = 210000m, Stock = 14 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product9Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 9 - Cần câu đài", AttributeValue = "5.4", Price = 260000m, Stock = 12 }
            });

            // Product 10
            var product10Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product10Id,
                CategoryId = idCate2,
                ManufacturerId = manufacturer10Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 10 - Trục",
                AttributeName = "Tỷ lệ truyền",
                AttributeUnit = ""
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product10Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 10 - Trục", AttributeValue = "5.2:1", Price = 310000m, Stock = 22 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product10Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 10 - Trục", AttributeValue = "6.2:1", Price = 360000m, Stock = 18 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product10Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 10 - Trục", AttributeValue = "7.0:1", Price = 410000m, Stock = 14 }
            });

            // Product 11
            var product11Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product11Id,
                CategoryId = idCate3,
                ManufacturerId = manufacturer1Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 11 - Thẻo",
                AttributeName = "Độ bền",
                AttributeUnit = "lb"
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product11Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 11 - Thẻo", AttributeValue = "10", Price = 55000m, Stock = 55 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product11Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 11 - Thẻo", AttributeValue = "20", Price = 65000m, Stock = 45 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product11Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 11 - Thẻo", AttributeValue = "30", Price = 75000m, Stock = 35 }
            });

            // Product 12
            var product12Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product12Id,
                CategoryId = idCate4,
                ManufacturerId = manufacturer2Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 12 - Phao",
                AttributeName = "Kích thước",
                AttributeUnit = "cm"
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product12Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 12 - Phao", AttributeValue = "2.5", Price = 22000m, Stock = 65 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product12Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 12 - Phao", AttributeValue = "3.0", Price = 27000m, Stock = 55 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product12Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 12 - Phao", AttributeValue = "3.5", Price = 32000m, Stock = 45 }
            });

            // Product 13
            var product13Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product13Id,
                CategoryId = idCate5,
                ManufacturerId = manufacturer3Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 13 - Thùng câu",
                AttributeName = "Dung tích",
                AttributeUnit = "lít"
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product13Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 13 - Thùng câu", AttributeValue = "30", Price = 510000m, Stock = 12 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product13Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 13 - Thùng câu", AttributeValue = "40", Price = 610000m, Stock = 10 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product13Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 13 - Thùng câu", AttributeValue = "50", Price = 710000m, Stock = 8 }
            });

            // Product 14
            var product14Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product14Id,
                CategoryId = idCate6,
                ManufacturerId = manufacturer4Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 14 - Giọ",
                AttributeName = "Kích thước",
                AttributeUnit = "cm"
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product14Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 14 - Giọ", AttributeValue = "50", Price = 110000m, Stock = 28 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product14Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 14 - Giọ", AttributeValue = "60", Price = 130000m, Stock = 22 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product14Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 14 - Giọ", AttributeValue = "70", Price = 150000m, Stock = 18 }
            });

            // Product 15
            var product15Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product15Id,
                CategoryId = idCate7,
                ManufacturerId = manufacturer5Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 15 - Mồi",
                AttributeName = "Loại mồi",
                AttributeUnit = ""
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product15Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 15 - Mồi", AttributeValue = "Mồi giả", Price = 32000m, Stock = 95 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product15Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 15 - Mồi", AttributeValue = "Mồi tự nhiên", Price = 37000m, Stock = 85 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product15Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 15 - Mồi", AttributeValue = "Mồi tổng hợp", Price = 42000m, Stock = 75 }
            });

            // Product 16
            var product16Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product16Id,
                CategoryId = idCate8,
                ManufacturerId = manufacturer6Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 16 - Gác cần",
                AttributeName = "Chất liệu",
                AttributeUnit = ""
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product16Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 16 - Gác cần", AttributeValue = "Nhôm", Price = 85000m, Stock = 32 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product16Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 16 - Gác cần", AttributeValue = "Thép", Price = 95000m, Stock = 28 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product16Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 16 - Gác cần", AttributeValue = "Carbon", Price = 105000m, Stock = 22 }
            });

            // Product 17
            var product17Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product17Id,
                CategoryId = idCate1,
                ManufacturerId = manufacturer7Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 17 - Cần câu đài",
                AttributeName = "Chiều dài",
                AttributeUnit = "m"
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product17Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 17 - Cần câu đài", AttributeValue = "3.6", Price = 170000m, Stock = 16 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product17Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 17 - Cần câu đài", AttributeValue = "4.5", Price = 220000m, Stock = 12 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product17Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 17 - Cần câu đài", AttributeValue = "5.4", Price = 270000m, Stock = 10 }
            });

            // Product 18
            var product18Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product18Id,
                CategoryId = idCate2,
                ManufacturerId = manufacturer8Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 18 - Trục",
                AttributeName = "Tỷ lệ truyền",
                AttributeUnit = ""
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product18Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 18 - Trục", AttributeValue = "5.2:1", Price = 320000m, Stock = 20 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product18Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 18 - Trục", AttributeValue = "6.2:1", Price = 370000m, Stock = 16 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product18Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 18 - Trục", AttributeValue = "7.0:1", Price = 420000m, Stock = 12 }
            });

            // Product 19
            var product19Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product19Id,
                CategoryId = idCate3,
                ManufacturerId = manufacturer9Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 19 - Thẻo",
                AttributeName = "Độ bền",
                AttributeUnit = "lb"
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product19Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 19 - Thẻo", AttributeValue = "10", Price = 60000m, Stock = 50 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product19Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 19 - Thẻo", AttributeValue = "20", Price = 70000m, Stock = 40 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product19Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 19 - Thẻo", AttributeValue = "30", Price = 80000m, Stock = 30 }
            });

            // Product 20
            var product20Id = Guid.NewGuid();
            products.Add(new Product
            {
                Id = product20Id,
                CategoryId = idCate4,
                ManufacturerId = manufacturer10Id,
                Status = "1",
                CreatedTime = DateTime.Now,
                Name = "Sản phẩm 20 - Phao",
                AttributeName = "Kích thước",
                AttributeUnit = "cm"
            });
            productDetails.AddRange(new[]
            {
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product20Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 1 của Sản phẩm 20 - Phao", AttributeValue = "2.5", Price = 23000m, Stock = 60 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product20Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 2 của Sản phẩm 20 - Phao", AttributeValue = "3.0", Price = 28000m, Stock = 50 },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = product20Id, Status = "1", CreatedTime = DateTime.Now, Description = "Biến thể 3 của Sản phẩm 20 - Phao", AttributeValue = "3.5", Price = 33000m, Stock = 40 }
            });

            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<ProductDetail>().HasData(productDetails);


        }

    }
}
