using AirportWebApiBSA.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AirportWebApiBSA.DAL.Repositories
{
    public class FlightRepository : BaseRepository<Flight>
    {
        private new IList<Flight> ItemsList = new List<Flight>
        {
            new Flight
            {
                Id = 1,
                DepartureTime = new DateTime(2018, 07, 24, 16, 30, 00),
                ArrivalTime = new DateTime(2018, 07, 24, 23, 17, 00),
                EntryPoint = "London",
                Destination = "New-York",
                Tickets = new List<Ticket>
                {
                    new TicketRepository().Get(1),
                    new TicketRepository().Get(2)
                }
            },
            new Flight
            {
                Id = 2,
                DepartureTime = new DateTime(2018, 07, 25, 11, 15, 00),
                ArrivalTime = new DateTime(2018, 07, 25, 14, 05, 00),
                EntryPoint = "Kyiv",
                Destination = "Munich",
                Tickets = new List<Ticket>
                {
                    new TicketRepository().Get(3),
                    new TicketRepository().Get(4),
                    new TicketRepository().Get(5)
                }
            },
            new Flight
            {
                Id = 3,
                DepartureTime = new DateTime(2018, 07, 26, 13, 47, 00),
                ArrivalTime = new DateTime(2018, 07, 26, 15, 23, 00),
                EntryPoint = "Amsterdam",
                Destination = "Tanger",
                Tickets = new List<Ticket>
                {
                    new TicketRepository().Get(6),
                    new TicketRepository().Get(7),
                    new TicketRepository().Get(8)
                }
            }
        };
    }
}