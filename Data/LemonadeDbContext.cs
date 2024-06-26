﻿using Data.Resources;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class LemonadeDbContext : DbContext
    {


        public LemonadeDbContext(DbContextOptions<LemonadeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.ClientOrder> ClientOrders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Supplier> Suppliers { get; set;  } 

        public DbSet<SuppliesOrder> SuppliesOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //-----Keys 
            modelBuilder.Entity<Models.ClientOrder>().HasKey(co => co.id);
            modelBuilder.Entity<OrderDetail>().HasKey(od => od.id);
            modelBuilder.Entity<Product>().HasKey(p => p.id);
            modelBuilder.Entity<ProductType>().HasKey(p => p.id);
            modelBuilder.Entity<Supplier>().HasKey(s => s.id);
            modelBuilder.Entity<SuppliesOrder>().HasKey(so => so.id);

            //------------ Relationship
            modelBuilder.Entity<Models.ClientOrder>().HasMany(co => co.orderDetails)
                .WithOne(co => co.clientOrder)
                .HasForeignKey(od => od.order);


            modelBuilder.Entity<Product>().HasMany(p => p.orderDetails)
                .WithOne(p => p.oProduct)
                .HasForeignKey(p => p.product);

            modelBuilder.Entity<ProductType>().HasMany(p => p.product)
                .WithOne(p => p.productType)
                .HasForeignKey(p => p.type);

            modelBuilder.Entity<SuppliesOrder>().HasMany(s => s.oDetail)
                .WithOne(s => s.suppliesOrder)
                .HasForeignKey(s => s.supplies);

            modelBuilder.Entity<Supplier>().HasMany(s => s.oSuppliesO)
                .WithOne(s => s.oSupplier)
                .HasForeignKey(s => s.supplier);


            //------AutoIncrement

            modelBuilder.Entity<Product>()
                .Property(p => p.id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProductType>()
               .Property(p => p.id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Models.ClientOrder>()
               .Property(p => p.id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<SuppliesOrder>()
               .Property(p => p.id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Supplier>()
               .Property(p => p.id)
               .ValueGeneratedOnAdd();

            //----------------
            base.OnModelCreating(modelBuilder);

        }

        //--- Convertion
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
    }

}
