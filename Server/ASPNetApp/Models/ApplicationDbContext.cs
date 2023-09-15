/*

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ASPNetApp.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        internal DbSet<Category> Categories { get; set; } = null!;
        internal DbSet<Product> Products { get; set; } = null!;
    }
}
*/