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

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("server=dotnet2019mason.database.windows.net;database=MLTAscendDB;user id=sqladmin; password=Florida2019;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(e => e.Id);
            builder.Entity<Prediction>().HasKey(e => e.Id);
        }
    }
}
