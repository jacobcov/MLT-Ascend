using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MLTAscend.Domain.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.InMemory;
namespace MLTAscend.Data
{
    public class InMemoryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Prediction> Predictions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestingDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<Prediction>().HasKey(e => e.Id);
        }
    }
}
//optionsBuilder.UseInMemoryDatabase("server=dotnet2019mason.database.windows.net;database=MLTAscendDB;user id=sqladmin; password=Florida2019;");
