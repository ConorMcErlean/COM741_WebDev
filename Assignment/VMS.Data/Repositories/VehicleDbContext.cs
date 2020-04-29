using System;
using VMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace VMS.Data.Repositories
{
    public class VehicleDbContext : DbContext
    {

        
        // Allow Querying of Vehicles Table
        public DbSet<Vehicle> Vehicles { get; set;}

        // Allow Querying of Services Table
        public DbSet<Service> Services { get; set;}

        
        // Database context using SQLite
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=data.db")
            /* Optional Logging (Comment in/out based on need) */
            // .UseLoggerFactory( new ServiceCollection ()
            //                     .AddLogging(builder => builder.AddConsole())
            //                     .BuildServiceProvider
            //                     .GetService<ILoggerFactory>())
            /* End of Optional Logging */
            ;
        }


        // Initialising Tables
        public void Initialise()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}