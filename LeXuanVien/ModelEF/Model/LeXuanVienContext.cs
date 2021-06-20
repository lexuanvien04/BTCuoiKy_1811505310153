using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelEF.Model
{
    public partial class LeXuanVienContext : DbContext
    {
        public LeXuanVienContext()
            : base("name=LeXuanVienContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryID)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerID)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.CustomerID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.CategoryID)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.UserID)
                .IsUnicode(false);
        }
    }
}
