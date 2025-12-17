using Microsoft.EntityFrameworkCore;

namespace WebAppPractiece.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Models.Slider> Sliders { get; set; }
        public DbSet<Models.SliderDetail> SlidersDetails { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.ProductImage> ProductImages { get; set; }
        public DbSet<Models.Category> Categories { get; set; }
    }
}
