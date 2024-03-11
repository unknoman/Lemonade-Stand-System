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

        }

        }
}