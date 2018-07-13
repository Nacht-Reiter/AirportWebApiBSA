using AirportWebApiBSA.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AirportWebApiBSA.DAL.Repositories
{
    public class DepartureRepository : BaseRepository<Departure>
    {
        private new IList<Departure> ItemsList = new List<Departure>
        {
            new Departure
            {
                Id = 1,
                FlightNumber = 1,
                DepartureDate = new DateTime(2018, 07, 24),
                Crew = new CrewsRepository().Get(1),
                AirCraft = new AirCraftRepository().Get(1)
            },
            new Departure
            {
                Id = 2,
                FlightNumber = 2,
                DepartureDate = new DateTime(2018, 07, 25),
                Crew = new CrewsRepository().Get(2),
                AirCraft = new AirCraftRepository().Get(2)
            },
            new Departure
            {
                Id = 3,
                FlightNumber = 3,
                DepartureDate = new DateTime(2018, 07, 24),
                Crew = new CrewsRepository().Get(3),
                AirCraft = new AirCraftRepository().Get(3)
            }
        };
    }
}