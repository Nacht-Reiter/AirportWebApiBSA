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
    public class PilotsRepository : IRepository<Pilot>
    {
        public PilotsRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public IEnumerable<Pilot> GetAll()
        {
            return db.Pilots;
        }

        public Pilot Get(int id)
        {
            return db.Pilots.Find(id);
        }

        public void Create(Pilot item)
        {
            db.Pilots.Add(item);
        }

        public void Update(Pilot item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Pilot> Find(Func<Pilot, Boolean> predicate)
        {
            return db.Pilots.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Pilot item = db.Pilots.Find(id);
            if (item != null)
                db.Pilots.Remove(item);
        }
    }
}