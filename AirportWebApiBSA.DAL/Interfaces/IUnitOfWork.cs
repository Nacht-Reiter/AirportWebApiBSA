using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirportWebApiBSA.DAL.Models;

namespace AirportWebApiBSA.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Pilot> Pilots { get; }
        IRepository<Stewardess> Stewardesses { get; }
        IRepository<Crew> Crews { get; }

        IRepository<AirCraft> AirCrafts { get; }

        IRepository<AirCraftType> AirCraftTypes { get; }

        IRepository<Departure> Departures { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<Flight> Flights { get; }

        Task Save();
    }
}
