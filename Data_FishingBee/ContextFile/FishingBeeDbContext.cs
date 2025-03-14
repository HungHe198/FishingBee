using Data_FishingBee.Models;
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
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ASMS;Database=FishingBee14.03;Trusted_Connection=True;MultipleActiveResultSets=true");
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
        }
    }
}
