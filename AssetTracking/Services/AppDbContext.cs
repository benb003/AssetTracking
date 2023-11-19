using AssetTracking.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetTracking.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Office> Offices { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
              
    }
}
