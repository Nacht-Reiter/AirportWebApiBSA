using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.DAL.EF
{
    public class AirportContext  : DbContext
    {
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Stewardess> Stewardesses { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<AirCraft> AirCrafts { get; set; }
        public DbSet<AirCraftType> AirCraftTypes { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public AirportContext(DbContextOptions<AirportContext> options)
            : base(options)
        {
            
            
            Database.EnsureCreated();

        }
    }
}
