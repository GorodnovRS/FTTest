using FTTest.Models;
using Microsoft.EntityFrameworkCore;

namespace FTTest.Data
{
    class IzdelDbContext : DbContext
    {
        public IzdelDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<IzdelModel> Izdel { get; set; }

        public DbSet<LinksModel> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinksModel>()
                .HasOne(l => l.Izdel)
                .WithMany(i => i.Links);
            modelBuilder.Entity<LinksModel>()
                .HasOne(l => l.IzdelUp)
                .WithMany(i => i.Components)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<LinksModel>()
                .HasKey(l => new { l.IzdelId, l.IzdelUpId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IzdelDb;Trusted_Connection=True;");
        }
    }
}
