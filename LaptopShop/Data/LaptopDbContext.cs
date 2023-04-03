using LaptopShop.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.Data
{
    public class LaptopDbContext : DbContext
    {
        public LaptopDbContext(DbContextOptions<LaptopDbContext> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<LaptopCategory> LaptopCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
