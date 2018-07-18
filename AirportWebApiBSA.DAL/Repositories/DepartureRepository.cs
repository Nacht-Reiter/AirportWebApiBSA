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
    public class DepartureRepository : IRepository<Departure>
    {
        public DepartureRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public async Task<IEnumerable<Departure>> GetAll()
        {
            return await db.Departures.Include(d => d.AirCraft).Include(d => d.Crew).ToListAsync();
        }

        public async Task<Departure> Get(int id)
        {
            return await db.Departures.Include(d => d.AirCraft).Include(d => d.Crew).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task Create(Departure item)
        {
            await db.Departures.AddAsync(item);
        }

        public void Update(Departure item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public  async Task Delete(int id)
        {
            Departure item = await db.Departures.FindAsync(id);
            if (item != null)
                db.Departures.Remove(item);
        }
    }
}