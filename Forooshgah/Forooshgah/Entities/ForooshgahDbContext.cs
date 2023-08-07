using Microsoft.EntityFrameworkCore;

namespace Forooshgah.Entities
{
    public class ForooshgahDbContext : DbContext
    {
        public ForooshgahDbContext(DbContextOptions<ForooshgahDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
