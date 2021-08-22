using LifeCityAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Data
{
    public class EmotieregulatieContext : IdentityDbContext
    {
        public EmotieregulatieContext(DbContextOptions<EmotieregulatieContext> options) 
            : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Emotieregulatie>();
            builder.Entity<Emotieregulatie>().Property(e => e.Beschrijving).IsRequired().HasMaxLength(5000);
            builder.Entity<Emotieregulatie>().Property(e => e.Emoties).IsRequired();

            builder.Entity<Customer>().Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(c => c.Email).IsRequired().HasMaxLength(100);
           

           // builder.Entity<Emotieregulatie>().HasData(
            //new Emotieregulatie { Id = 1, Beschrijving = "ik ben blij", DateAdded = DateTime.Now, Emoties = "blij" },
            //new Emotieregulatie { Id = 2, Beschrijving = "ik ben boos", DateAdded = DateTime.Now, Emoties = "boos" }
            //);
        }

        public DbSet<Emotieregulatie> Emotieregulaties { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Talenten> Talenten { get; set; }
        public DbSet<Hulpbron> Hulpbronnen { get; set; }
        public DbSet<LevenslijnItem> LevenslijnItems { get; set; }
        public DbSet<Doel> Doelen { get; set; }
    }
}
