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
    public class TicketRepository : IRepository<Ticket>
    {
        public TicketRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public IEnumerable<Ticket> GetAll()
        {
            return db.Tickets;
        }

        public Ticket Get(int id)
        {
            return db.Tickets.Find(id);
        }

        public void Create(Ticket item)
        {
            db.Tickets.Add(item);
        }

        public void Update(Ticket item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Ticket> Find(Func<Ticket, Boolean> predicate)
        {
            return db.Tickets.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Ticket item = db.Tickets.Find(id);
            if (item != null)
                db.Tickets.Remove(item);
        }
    }
}