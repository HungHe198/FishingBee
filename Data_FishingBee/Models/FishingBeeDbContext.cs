using Data_FishingBee.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class FishingBeeDbContext : DbContext
    {
        public FishingBeeDbContext()
        {
            
        }
        public FishingBeeDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Cart_Product> Cart_Products { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<Product_Category> Product_Categories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<DailyRevenue> DailyRevenues { get; set; }
        public DbSet<WeekRevenue> WeekRevenues { get; set; }
        public DbSet<MonthRevenue> MonthRevenues { get; set; }
       
        public DbSet<ProductRevenue> ProductRevenues { get; set; }
        public DbSet<CategoryRevenue> CategoryRevenues { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
       
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
        //public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CustomerActivityLog> UserActivityLogs { get; set; }
        //public DbSet<CustomerSupport> CustomerSupports { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-MUUEIFA;Initial Catalog=FishingBee;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
