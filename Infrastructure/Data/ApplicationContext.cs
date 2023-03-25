using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<Country> Countries { get; set; }
        public DbSet<Mestar> Mestri { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Natjecaj> Natjecaji { get; set; }
    }
}
