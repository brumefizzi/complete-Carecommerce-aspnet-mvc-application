using CarSalesApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarSalesApp.Data
{
    public class CarSalesAppContext : IdentityDbContext<ApplicationUser>
    {
        public CarSalesAppContext(DbContextOptions<CarSalesAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car_Salesman>().HasKey(cs => new { cs.CarId, cs.SalesmanId });

            modelBuilder.Entity<Car_Salesman>()
                .HasOne(m => m.Car)
                .WithMany(cs => cs.CarSalesmen)
                .HasForeignKey(m => m.CarId);

            modelBuilder.Entity<Car_Salesman>()
                .HasOne(m => m.Salesman)
                .WithMany(cs => cs.CarSalesmen)
                .HasForeignKey(m => m.SalesmanId)
                .OnDelete(DeleteBehavior.Restrict);
                //.OnUpdate(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Car_Salesman> CarSalesmen { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


    }
}
