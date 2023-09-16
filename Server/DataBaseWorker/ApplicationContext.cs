using DataBaseWorker.Models;
using Microsoft.EntityFrameworkCore;


namespace DataBaseWorker
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated(); 
        }
        internal DbSet<Category> Categories { get; set; } = null!;
        internal DbSet<Product> Products { get; set; } = null!;

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=testDb;Trusted_Connection=True;");
       }

    }
}