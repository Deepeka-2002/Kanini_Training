using Microsoft.EntityFrameworkCore;

namespace SampOnetoManyAPI.Models
{
    public class ProCatContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }

        public ProCatContext(DbContextOptions<ProCatContext> options) : base(options) 
        { 

        }
    }
}
