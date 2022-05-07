using BeyondOne.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BeyondOne.Data
{
    public class BeyondOneDbContext: DbContext
    {
        public BeyondOneDbContext(DbContextOptions options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(@"Server=(LocalDb)\\MSSQLLocalDB;Database=BeyondOneTestDb;Trusted_Connection=True;Integrated Security=True");
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=BeyondOneTestDb;Trusted_Connection=True;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // configure tables

            modelBuilder.Entity<Products>(e =>
            {
                e.HasKey(x => x.Id);
            });
        }

        public DbSet<Products> Products { get; set; }
    }
}
