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
    public class CrewsRepository : IRepository<Crew>
    {
        public CrewsRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public async Task<IEnumerable<Crew>> GetAll()
        {
            return await db.Crews.Include(s => s.Pilot).Include(s => s.Stewardesses).ToListAsync();
        }

        public async Task<Crew> Get(int id)
        {
            return await db.Crews.Include(s => s.Pilot).Include(s => s.Stewardesses).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Create(Crew item)
        {
            await db.Crews.AddAsync(item);
        }

        public void Update(Crew item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Crew item = await db.Crews.FindAsync(id);
            if (item != null)
                db.Crews.Remove(item);
        }
    }
}