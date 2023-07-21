using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelekomCore.Map;
using TelekomModel.Entities;
using TelekomModel.Maps;

namespace TelekomModel.Context
{
    public class TelekomContext : DbContext
    {
        public TelekomContext(DbContextOptions<TelekomContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new PackageMap());
            modelBuilder.ApplyConfiguration(new AllTableMap());

            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<AllTable> AllTables { get; set; }

    }
}
