﻿using Data_FishingBee.Models;
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
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<User> Users { get; set; }
		protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
		{
			base.ConfigureConventions(configurationBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-MUUEIFA;Database=FishingBee;Trusted_Connection=True;MultipleActiveResultSets=true");
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

			var idManu = Guid.NewGuid();
            var idManu1 = Guid.NewGuid();
            var idManu2 = Guid.NewGuid();
            var idManu3 = Guid.NewGuid();
            var idManu4 = Guid.NewGuid();
            var idCate1 = Guid.NewGuid();
            var idCate2 = Guid.NewGuid();
            var idCate3 = Guid.NewGuid();
            var idCate4 = Guid.NewGuid();
            var idCate5 = Guid.NewGuid();
            var idCate6 = Guid.NewGuid();
            var idCate7 = Guid.NewGuid();
            var idCate8 = Guid.NewGuid();
            var idSP1 = Guid.NewGuid();
			var idSP2 = Guid.NewGuid();
            var idSP3 = Guid.NewGuid();
            var idSP4 = Guid.NewGuid();
            var idSP5 = Guid.NewGuid();
            var idSP6 = Guid.NewGuid();

            modelBuilder.Entity<Manufacturer>().HasData(
				new Manufacturer { Id = idManu, Name = "Barfilon", Status = "Active", CreatedTime = DateTime.Now },
                new Manufacturer { Id = idManu1, Name = "Rice Fishing", Status = "Active", CreatedTime = DateTime.Now },
                new Manufacturer { Id = idManu2, Name = "Handing", Status = "Active", CreatedTime = DateTime.Now },
                new Manufacturer { Id = idManu3, Name = "Guide", Status = "Active", CreatedTime = DateTime.Now },
                new Manufacturer { Id = idManu4, Name = "Gamma Seiko", Status = "Active", CreatedTime = DateTime.Now }
            ); // Đóng HasData() ✅

			modelBuilder.Entity<Category>().HasData(
				new Category { Id = idCate1, Name = "Cần câu đài", Status = "Active", CreatedTime = DateTime.Now },
                new Category { Id = idCate2, Name = "Trục", Status = "Active", CreatedTime = DateTime.Now },
                new Category { Id = idCate3, Name = "Thẻo", Status = "Active", CreatedTime = DateTime.Now },
                new Category { Id = idCate4, Name = "Phao", Status = "Active", CreatedTime = DateTime.Now },
                new Category { Id = idCate5, Name = "Thùng câu", Status = "Active", CreatedTime = DateTime.Now },
                new Category { Id = idCate6, Name = "Giọ", Status = "Active", CreatedTime = DateTime.Now },
                new Category { Id = idCate7, Name = "Mồi", Status = "Active", CreatedTime = DateTime.Now },
                new Category { Id = idCate8, Name = "Gác cần", Status = "Active", CreatedTime = DateTime.Now }
            ); // Đóng HasData() ✅

			modelBuilder.Entity<Product>().HasData(
				new Product { Id = idSP1, CategoryId = idCate1, ManufacturerId = idManu, Status = "Available", CreatedTime = DateTime.Now },
				new Product { Id = idSP2, CategoryId = idCate1, ManufacturerId = idManu, Status = "Available", CreatedTime = DateTime.Now },
                new Product { Id = idSP3, CategoryId = idCate1, ManufacturerId = idManu, Status = "Available", CreatedTime = DateTime.Now },
                new Product { Id = idSP4, CategoryId = idCate1, ManufacturerId = idManu, Status = "Available", CreatedTime = DateTime.Now },
                new Product { Id = idSP5, CategoryId = idCate1, ManufacturerId = idManu, Status = "Available", CreatedTime = DateTime.Now },
                new Product { Id = idSP6, CategoryId = idCate1, ManufacturerId = idManu, Status = "Available", CreatedTime = DateTime.Now }
            ); // Đóng HasData() ✅

			modelBuilder.Entity<ProductDetail>().HasData(
				new ProductDetail { Id = Guid.NewGuid(), ProductId = idSP1, Name = "Barfilon Vân Trung Nguyệt", Price = 1.599m, Status = "In Stock", CreatedTime = DateTime.Now },
				new ProductDetail { Id = Guid.NewGuid(), ProductId = idSP1, Name = "Guide Thánh Hỏa Lệnh", Price = 2.300m, Status = "In Stock", CreatedTime = DateTime.Now },
				new ProductDetail { Id = Guid.NewGuid(), ProductId = idSP2, Name = "Gamma Seiko Bạch Kim", Price = 1.123m, Status = "In Stock", CreatedTime = DateTime.Now },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = idSP1, Name = "Barfilon Long Ngư Thủy", Price = 2.300m, Status = "In Stock", CreatedTime = DateTime.Now },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = idSP2, Name = "Handing Thiết Sa", Price = 1.123m, Status = "In Stock", CreatedTime = DateTime.Now },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = idSP1, Name = "Rice V5 Silver Carp", Price = 2.300m, Status = "In Stock", CreatedTime = DateTime.Now },
                new ProductDetail { Id = Guid.NewGuid(), ProductId = idSP2, Name = "Guide Lục Mạch Thần Kiếm", Price = 1.123m, Status = "In Stock", CreatedTime = DateTime.Now }
            ); // Đóng HasData() ✅

		}
	}
}
