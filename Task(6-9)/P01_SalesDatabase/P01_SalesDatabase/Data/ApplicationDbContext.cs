using Microsoft.EntityFrameworkCore;
using P01_SalesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_SalesDatabase.Data
{
    internal class ApplicationDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=LENOVO;Initial Catalog=Sales;Integrated Security=True;TrustServerCertificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().Property(p=>p.Name).HasColumnType("varchar(50)").IsUnicode(true);
            modelBuilder.Entity<Customer>().Property(c => c.Name).HasColumnType("varchar(100)").IsUnicode(true);
            modelBuilder.Entity<Customer>().Property(c => c.Email).HasColumnType("varchar(80)").IsUnicode(false);
            modelBuilder.Entity<Store>().Property(s => s.Name).HasColumnType("varchar(80)").IsUnicode(true);

            

        }
    }
}
