using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MLTAscend.Domain.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace MLTAscend.Data
{
    class MLTAscendDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Prediction> Predictions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=dotnet2019mason.database.windows.net;database=MLTAscendDB;user id=sqladmin; password=Florida2019;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<Prediction>().HasKey(e => e.Id);
        }
    }
}
