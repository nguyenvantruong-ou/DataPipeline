using Microsoft.EntityFrameworkCore;

namespace DataPipeline.Models
{
    public class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions<DbAppContext> options) : base (options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbAppContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
