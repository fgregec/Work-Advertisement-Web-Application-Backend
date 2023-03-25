using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MestarContext : DbContext
    {
        public MestarContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<BaseUser> Users { get; set; }
    }
}
