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
    class StewardessesRepository : IRepository<Stewardess>
    {
        public StewardessesRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public IEnumerable<Stewardess> GetAll()
        {
            return db.Stewardesses;
        }

        public Stewardess Get(int id)
        {
            return db.Stewardesses.Find(id);
        }

        public void Create(Stewardess item)
        {
            db.Stewardesses.Add(item);
        }

        public void Update(Stewardess item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Stewardess> Find(Func<Stewardess, Boolean> predicate)
        {
            return db.Stewardesses.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Stewardess item = db.Stewardesses.Find(id);
            if (item != null)
                db.Stewardesses.Remove(item);
        }
    }
}