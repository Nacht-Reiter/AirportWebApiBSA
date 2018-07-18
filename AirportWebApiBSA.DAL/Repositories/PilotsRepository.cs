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
    public class PilotsRepository : IRepository<Pilot>
    {
        public PilotsRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public async Task<IEnumerable<Pilot>> GetAll()
        {
            return await db.Pilots.ToListAsync();
        }

        public async Task<Pilot> Get(int id)
        {
            return await db.Pilots.FindAsync(id);
        }

        public async Task Create(Pilot item)
        {
            await db.Pilots.AddAsync(item);
        }

        public void Update(Pilot item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Pilot item = await db.Pilots.FindAsync(id);
            if (item != null)
                db.Pilots.Remove(item);
        }
    }
}