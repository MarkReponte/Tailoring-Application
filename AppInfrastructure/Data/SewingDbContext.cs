using AppDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppInfrastructure.Data
{
    public class SewingDbContext : DbContext
    {
        public DbSet<Measurements> Measurements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SewingDB;Trusted_Connection=True;");
        }
    }
}
