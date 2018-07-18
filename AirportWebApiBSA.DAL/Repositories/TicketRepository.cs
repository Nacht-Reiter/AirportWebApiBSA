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
    public class TicketRepository : IRepository<Ticket>
    {
        public TicketRepository(AirportContext context)
        {
            this.db = context;
        }
        private AirportContext db;


        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await db.Tickets.ToListAsync();
        }

        public async Task<Ticket> Get(int id)
        {
            return await db.Tickets.FindAsync(id);
        }

        public async Task Create(Ticket item)
        {
            await db.Tickets.AddAsync(item);
        }

        public void Update(Ticket item)
        {
            db.Entry(item).State = EntityState.Modified;
        }


        public async Task Delete(int id)
        {
            Ticket item = await db.Tickets.FindAsync(id);
            if (item != null)
                db.Tickets.Remove(item);
        }
    }
}