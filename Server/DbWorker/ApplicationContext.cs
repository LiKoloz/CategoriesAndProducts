using DbWorker.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbWorker
{
    public  class ApplicationContext : DbContext
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
