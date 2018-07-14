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
    public class CrewsRepository : IRepository<Crew>
    {
        public CrewsRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public IEnumerable<Crew> GetAll()
        {
            return db.Crews;
        }

        public Crew Get(int id)
        {
            return db.Crews.Find(id);
        }

        public void Create(Crew item)
        {
            db.Crews.Add(item);
        }

        public void Update(Crew item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Crew> Find(Func<Crew, Boolean> predicate)
        {
            return db.Crews.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Crew item = db.Crews.Find(id);
            if (item != null)
                db.Crews.Remove(item);
        }
    }
}