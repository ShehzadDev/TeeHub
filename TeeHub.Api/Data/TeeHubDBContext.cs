using Microsoft.EntityFrameworkCore;
using TeeHub.Api.Models.Domain;

namespace TeeHub.Api.Data
{
    public class TeeHubDBContext:DbContext
    {
        public TeeHubDBContext(DbContextOptions dbContextOptions):base (dbContextOptions)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Design> Designs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
