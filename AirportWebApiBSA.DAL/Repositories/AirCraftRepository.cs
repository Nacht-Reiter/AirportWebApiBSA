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
    public class AirCraftRepository: IRepository<AirCraft>
    {
        public AirCraftRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public IEnumerable<AirCraft> GetAll()
        {
            return db.AirCrafts;
        }

        public AirCraft Get(int id)
        {
            return db.AirCrafts.Find(id);
        }

        public void Create(AirCraft item)
        {
            db.AirCrafts.Add(item);
        }

        public void Update(AirCraft item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<AirCraft> Find(Func<AirCraft, Boolean> predicate)
        {
            return db.AirCrafts.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            AirCraft item = db.AirCrafts.Find(id);
            if (item != null)
                db.AirCrafts.Remove(item);
        }
    }
}