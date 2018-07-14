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
    public class AirCraftTypeRepository : IRepository<AirCraftType>
    {
        public AirCraftTypeRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public IEnumerable<AirCraftType> GetAll()
        {
            return db.AirCraftTypes;
        }

        public AirCraftType Get(int id)
        {
            return db.AirCraftTypes.Find(id);
        }

        public void Create(AirCraftType item)
        {
            db.AirCraftTypes.Add(item);
        }

        public void Update(AirCraftType item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<AirCraftType> Find(Func<AirCraftType, Boolean> predicate)
        {
            return db.AirCraftTypes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            AirCraftType item = db.AirCraftTypes.Find(id);
            if (item != null)
                db.AirCraftTypes.Remove(item);
        }
    }
}