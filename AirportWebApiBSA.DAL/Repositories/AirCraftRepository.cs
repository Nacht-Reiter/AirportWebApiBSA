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
    public class AirCraftRepository: IRepository<AirCraft>
    {
        public AirCraftRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public async Task<IEnumerable<AirCraft>> GetAll()
        {
            return await db.AirCrafts.Include(a => a.Id).ToListAsync();
        }

        public async Task<AirCraft> Get(int id)
        {
            return await db.AirCrafts.Include(a => a.AirCraftType).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Create(AirCraft item)
        {
            await db.AirCrafts.AddAsync(item);
        }

        public void Update(AirCraft item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            AirCraft item = await db.AirCrafts.FindAsync(id);
            if (item != null)
                db.AirCrafts.Remove(item);
        }
    }
}