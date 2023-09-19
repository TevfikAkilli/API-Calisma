using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("data source=.\\SQLEXPRESS;initial catalog=HotelDB;integrated security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, City = "İstanbul", Name = "Hilton" },
                new Hotel { Id = 2, City = "Ankara", Name = "Pasha Hotel" }

                );
        }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
