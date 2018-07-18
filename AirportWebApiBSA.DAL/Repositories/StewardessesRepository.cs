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
    class StewardessesRepository : IRepository<Stewardess>
    {
        public StewardessesRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public async Task<IEnumerable<Stewardess>> GetAll()
        {
            return await db.Stewardesses.ToListAsync();
        }

        public async Task<Stewardess> Get(int id)
        {
            return await db.Stewardesses.FindAsync(id);
        }

        public async Task Create(Stewardess item)
        {
            await db.Stewardesses.AddAsync(item);
        }

        public void Update(Stewardess item)
        {
            db.Entry(item).State = EntityState.Modified;
        }


        public async Task Delete(int id)
        {
            Stewardess item = await db.Stewardesses.FindAsync(id);
            if (item != null)
                db.Stewardesses.Remove(item);
        }
    }
}