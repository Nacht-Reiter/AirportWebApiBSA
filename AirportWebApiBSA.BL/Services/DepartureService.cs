using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AirportWebApiBSA.BLL.Services
{
    public class DepartureService : Interfaces.IService<DepartureDTO>
    {
        private IUnitOfWork UnitOfWork;

        public DepartureService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task Create(DepartureDTO item)
        {
            await UnitOfWork.Departures.Create(await MapDeparture(item));
            await UnitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.Departures.Delete(id);
            await UnitOfWork.Save();
        }

        public async Task<DepartureDTO> Get(int id)
        {
            return MapDepartureDTO(await UnitOfWork.Departures.Get(id));
        }

        public async Task<IEnumerable<DepartureDTO>> GetAll()
        {
            var temp = await UnitOfWork.Departures.GetAll();
            return temp.Select(p => MapDepartureDTO(p));
        }

        public async void Update(int id, DepartureDTO item)
        {
            item.Id = id;
            UnitOfWork.Departures.Update(await MapDeparture(item));
            await UnitOfWork.Save();
        }

        private DepartureDTO MapDepartureDTO(Departure item)
        {
            return new DepartureDTO
            {
                Id = item.Id,
                AirCraftId = item.AirCraft.Id,
                CrewId = item.Crew.Id,
                DepartureDate = item.DepartureDate,
                FlightNumber = item.FlightNumber
            };
        }

        private async Task<Departure> MapDeparture(DepartureDTO item)
        {
            return new Departure
            {
                Id = item.Id,
                AirCraft = await UnitOfWork.AirCrafts.Get(item.AirCraftId),
                Crew = await UnitOfWork.Crews.Get(item.CrewId),
                DepartureDate = item.DepartureDate,
                FlightNumber = item.FlightNumber

            };
        }
    }
}
