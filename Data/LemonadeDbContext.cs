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

            //------------ Relationship
            modelBuilder.Entity<ClientOrder>().HasMany(co => co.orderDetails)
                .WithOne(co => co.clientOrder)
                .HasForeignKey(od => od.order);





            //----------------
            base.OnModelCreating(modelBuilder);

        }

    }
}