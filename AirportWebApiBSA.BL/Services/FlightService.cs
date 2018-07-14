using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AirportWebApiBSA.BLL.Services
{
    public class FlightService : Interfaces.IService<FlightDTO>
    {
        private IUnitOfWork UnitOfWork;

        public FlightService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Create(FlightDTO item)
        {
            UnitOfWork.Flights.Create(MapFlight(item));
        }

        public void Delete(int id)
        {
            UnitOfWork.Flights.Delete(id);
        }

        public FlightDTO Get(int id)
        {
            return MapFlightDTO(UnitOfWork.Flights.Get(id));
        }

        public IEnumerable<FlightDTO> GetAll()
        {
            return UnitOfWork.Flights.GetAll().Select(p => MapFlightDTO(p));
        }

        public void Update(int id, FlightDTO item)
        {
            item.Id = id;
            UnitOfWork.Flights.Update(MapFlight(item));
        }

        private FlightDTO MapFlightDTO(Flight item)
        {
            return new FlightDTO
            {
                Id = item.Id,
                ArrivalTime = item.ArrivalTime,
                DepartureTime = item.DepartureTime,
                Destination = item.Destination,
                EntryPoint = item.EntryPoint,
                TicketsId = item.Tickets.Select(t => t.Id)
            };
        }
        private Flight MapFlight(FlightDTO item)
        {
            return new Flight
            {
                Id = item.Id,
                ArrivalTime = item.ArrivalTime,
                DepartureTime = item.DepartureTime,
                Destination = item.Destination,
                EntryPoint = item.EntryPoint,
                Tickets = item.TicketsId.Select(t => UnitOfWork.Tickets.Get(t))
            };
        }
    }
}
