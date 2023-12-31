﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
            modelBuilder.Entity<ChatRoom>(entity =>
            {
                entity.HasKey(e => e.RoomName);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Mestar> Mestri { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Natjecaj> Natjecaji { get; set; }        
        public DbSet<Category> Categories { get; set; }
        public DbSet<MestarCategory> MestarCategories{ get; set; }
        public DbSet<City> Cities{ get; set; }
        public DbSet<County> Counties{ get; set; }
        public DbSet<Country> Countries{ get; set; }
        public DbSet<Review> Reviews{ get; set; }
        public DbSet<Offer> Offers { get; set; }

        public DbSet<ChatRoom> ChatRooms{ get; set; }
        public DbSet<Message> Messages{ get; set; }
    }
}
