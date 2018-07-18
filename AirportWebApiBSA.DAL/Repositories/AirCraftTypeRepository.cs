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
    public class AirCraftTypeRepository : IRepository<AirCraftType>
    {
        public AirCraftTypeRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public async Task<IEnumerable<AirCraftType>> GetAll()
        {
            return await db.AirCraftTypes.ToListAsync();
        }

        public async Task<AirCraftType> Get(int id)
        {
            return await db.AirCraftTypes.FindAsync(id);
        }

        public async Task Create(AirCraftType item)
        {
            await db.AirCraftTypes.AddAsync(item);
        }

        public void Update(AirCraftType item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            AirCraftType item = await db.AirCraftTypes.FindAsync(id);
            if (item != null)
                db.AirCraftTypes.Remove(item);
        }
    }
}