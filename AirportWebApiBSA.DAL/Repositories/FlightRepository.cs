using AirportWebApiBSA.DAL.EF;
using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AirportWebApiBSA.DAL.Repositories
{
    public class FlightRepository : IRepository<Flight>
    {
        public FlightRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public IEnumerable<Flight> GetAll()
        {
            return db.Flights.Include(s => s.Tickets);
        }

        public Flight Get(int id)
        {
            return db.Flights.Include(s => s.Tickets).FirstOrDefault(f => f.Id == id);
        }

        public void Create(Flight item)
        {
            db.Flights.Add(item);
        }

        public void Update(Flight item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Flight> Find(Func<Flight, Boolean> predicate)
        {
            return db.Flights.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Flight item = db.Flights.Find(id);
            if (item != null)
                db.Flights.Remove(item);
        }
    }
}