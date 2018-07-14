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
    public class DepartureRepository : IRepository<Departure>
    {
        public DepartureRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public IEnumerable<Departure> GetAll()
        {
            return db.Departures;
        }

        public Departure Get(int id)
        {
            return db.Departures.Find(id);
        }

        public void Create(Departure item)
        {
            db.Departures.Add(item);
        }

        public void Update(Departure item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Departure> Find(Func<Departure, Boolean> predicate)
        {
            return db.Departures.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Departure item = db.Departures.Find(id);
            if (item != null)
                db.Departures.Remove(item);
        }
    }
}