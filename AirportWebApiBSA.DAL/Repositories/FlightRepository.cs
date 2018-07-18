using AirportWebApiBSA.DAL.EF;
using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportWebApiBSA.DAL.Repositories
{
    public class FlightRepository : IRepository<Flight>
    {
        public FlightRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public async Task<IEnumerable<Flight>> GetAll()
        {
            return await db.Flights.Include(s => s.Tickets).ToListAsync();
        }

        public async Task<Flight> Get(int id)
        {
            return await db.Flights.Include(s => s.Tickets).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task Create(Flight item)
        {
            await db.Flights.AddAsync(item);
        }

        public void Update(Flight item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Flight item = await db.Flights.FindAsync(id);
            if (item != null)
                db.Flights.Remove(item);
        }
    }
}