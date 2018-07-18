using AirportWebApiBSA.BLL.Interfaces;
using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace AirportWebApiBSA.BLL.Services
{
    public class FlightService : IFlightService
    {
        private IUnitOfWork UnitOfWork;

        public FlightService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task  Create(FlightDTO item)
        {
            await UnitOfWork.Flights.Create(await MapFlight(item));
            await UnitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.Flights.Delete(id);
            await UnitOfWork.Save();
        }

        public async Task<FlightDTO> Get(int id)
        {
            return MapFlightDTO(await UnitOfWork.Flights.Get(id));
        }

        public Task<FlightDTO> GetWithDelay(int id, int delay)
        {
            var tcs = new TaskCompletionSource<FlightDTO>();
            Timer timer = new Timer(delay);
            timer.AutoReset = false;
            timer.Elapsed += new ElapsedEventHandler(async (object sender, ElapsedEventArgs e) => tcs.SetResult(MapFlightDTO(await UnitOfWork.Flights.Get(id))));
            timer.Start();
            return tcs.Task;
        }

        public async Task<IEnumerable<FlightDTO>> GetAll()
        {
            var temp = await UnitOfWork.Flights.GetAll();
            return temp.Select(p => MapFlightDTO(p));
        }

        public async void Update(int id, FlightDTO item)
        {
            item.Id = id;
            UnitOfWork.Flights.Update(await MapFlight(item));
            await UnitOfWork.Save();
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
        private async Task<Flight> MapFlight(FlightDTO item)
        {
            var AllTick = new List<Ticket>();
            AllTick.AddRange(await UnitOfWork.Tickets.GetAll());
            return new Flight
            {
                Id = item.Id,
                ArrivalTime = item.ArrivalTime,
                DepartureTime = item.DepartureTime,
                Destination = item.Destination,
                EntryPoint = item.EntryPoint,
                Tickets = item.TicketsId.Select(t => AllTick.Find(e => e.Id == t))
            };
        }
    }
}
