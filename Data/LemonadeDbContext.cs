using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class LemonadeDbContext : DbContext
    {

        public DbSet<ClientOrder> ClientOrders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //-----Keys 
            modelBuilder.Entity<ClientOrder>().HasKey(co => co.id);
            modelBuilder.Entity<OrderDetail>().HasKey(od => od.id);

            //------------ Relationship
            modelBuilder.Entity<ClientOrder>().HasMany(co => co.OrderDetails)
                .WithOne(co => co.clientOrder)
                .HasForeignKey(co => co.id);

            //----------------
            base.OnModelCreating(modelBuilder);

        }

    }
}