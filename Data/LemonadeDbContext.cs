using Data.Resources;
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

        public DbSet<ClientOrder> ClientOrders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //-----Keys 
            modelBuilder.Entity<ClientOrder>().HasKey(co => co.id);
            modelBuilder.Entity<OrderDetail>().HasKey(od => od.id);
            modelBuilder.Entity<Product>().HasKey(p => p.id);
            modelBuilder.Entity<ProductType>().HasKey(p => p.id);
            modelBuilder.Entity<Supplier>().HasKey(s => s.id);
            modelBuilder.Entity<SuppliesOrder>().HasKey(so => so.id);

            //------------ Relationship
            modelBuilder.Entity<ClientOrder>().HasMany(co => co.orderDetails)
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



 
       
            //----------------
            base.OnModelCreating(modelBuilder);

        }


        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
    }

}
