using AppDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppInfrastructure.Data
{
    public class CostDBContext : DbContext
    {
        public DbSet<MaterialCost> MaterialCosts { get; set; }
        public DbSet<MaterialItem> MaterialItems { get; set; }
        public DbSet<OrderSummary> OrderSummaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CostDB;Trusted_Connection=True;");
        }
    }
}
