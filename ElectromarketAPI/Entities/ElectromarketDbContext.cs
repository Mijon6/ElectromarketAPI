using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectromarketAPI.Entities
{
    public class ElectromarketDbContext : DbContext
    {
        private string _connectionString = "Server=localhost\\SQLEXPRESS;Database=ElectromarketDb;Trusted_Connection=True;";
        public DbSet<Electromarket> Electromarkets { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Stuff> Stuffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Electromarket>()
                 .Property(r => r.Name)
                 .IsRequired()
                 .HasMaxLength(25);

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Address>()
                .Property(b => b.Street)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Stuff>()
                .Property(d => d.Name)
                .IsRequired();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
