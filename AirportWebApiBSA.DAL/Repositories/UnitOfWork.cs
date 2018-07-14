using System;
using System.Collections.Generic;
using System.Text;
using AirportWebApiBSA.DAL.EF;
using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;

namespace AirportWebApiBSA.DAL.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private AirportContext db;
        private PilotsRepository pilotsRepository;
        private StewardessesRepository stewardessesRepository;
        private CrewsRepository crewsRepository;
        private AirCraftRepository airCraftRepository;
        private AirCraftTypeRepository airCraftTypesRepository;
        private DepartureRepository departuresRepository;
        private TicketRepository ticketsRepository;
        private FlightRepository flightsRepository;

        public UnitOfWork(AirportContext db)
        {
            this.db = db;
        }

        public IRepository<Pilot> Pilots
        {
            get
            {
                if (pilotsRepository == null)
                    pilotsRepository = new PilotsRepository(db);
                return pilotsRepository;
            } 
        }
 
        public IRepository<Stewardess> Stewardesses
        {
            get
            {
                if (stewardessesRepository == null)
                    stewardessesRepository = new StewardessesRepository(db);
                return stewardessesRepository;
            }
        }

        public IRepository<Crew> Crews
        {
            get
            {
                if (crewsRepository == null)
                    crewsRepository = new CrewsRepository(db);
                return crewsRepository;
            }
        }
        
        public IRepository<AirCraft> AirCrafts
        {
            get
            {
                if (airCraftRepository == null)
                    airCraftRepository = new AirCraftRepository(db);
                return airCraftRepository;
            }
        }

        public IRepository<AirCraftType> AirCraftTypes
        {
            get
            {
                if (airCraftTypesRepository == null)
                    airCraftTypesRepository = new AirCraftTypeRepository(db);
                return airCraftTypesRepository;
            }
        }

        public IRepository<Departure> Departures
        {
            get
            {
                if (departuresRepository == null)
                    departuresRepository = new DepartureRepository(db);
                return departuresRepository;
            }
        }

        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketsRepository == null)
                    ticketsRepository = new TicketRepository(db);
                return ticketsRepository;
            }
        }

        public IRepository<Flight> Flights
        {
            get
            {
                if (flightsRepository == null)
                    flightsRepository = new FlightRepository(db);
                return flightsRepository;
            }
        }



        public void Save()
        {
            db.SaveChanges();
        }
 

    }
}
