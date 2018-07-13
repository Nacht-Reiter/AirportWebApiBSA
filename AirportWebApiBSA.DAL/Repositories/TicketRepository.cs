using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AirportWebApiBSA.DAL.Models;

namespace AirportWebApiBSA.DAL.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>
    {
        private new IList<Ticket> ItemsList = new List<Ticket>
        {
            new Ticket
            {
                Id = 1,
                FlightNumber = 1,
                Price = 10000
            },
            new Ticket
            {
                Id = 2,
                FlightNumber = 1,
                Price = 12000
            },
            new Ticket
            {
                Id = 3,
                FlightNumber = 2,
                Price = 5000
            },
            new Ticket
            {
                Id = 4,
                FlightNumber = 2,
                Price = 4500
            },
            new Ticket
            {
                Id = 5,
                FlightNumber = 2,
                Price = 6000
            },
            new Ticket
            {
                Id = 6,
                FlightNumber = 3,
                Price = 8000
            },
            new Ticket
            {
                Id = 7,
                FlightNumber = 3,
                Price = 8000
            },
            new Ticket
            {
                Id = 8,
                FlightNumber = 3,
                Price = 7500
            }
        };
    }
}