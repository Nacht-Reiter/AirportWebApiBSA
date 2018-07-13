using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AirportWebApiBSA.BLL.Services
{
    public class DepartureService : Interfaces.IService<DepartureDTO>
    {
        private IUnitOfWork UnitOfWork;

        public DepartureService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Create(DepartureDTO item)
        {
            UnitOfWork.Departures.Create(MapDeparture(item));
        }

        public void Delete(int id)
        {
            UnitOfWork.Departures.Delete(id);
        }

        public DepartureDTO Get(int id)
        {
            return MapDepartureDTO(UnitOfWork.Departures.Get(id));
        }

        public IEnumerable<DepartureDTO> GetAll()
        {
            return UnitOfWork.Departures.GetAll().Select(p => MapDepartureDTO(p));
        }

        public void Update(int id, DepartureDTO item)
        {
            item.Id = id;
            UnitOfWork.Departures.Update(MapDeparture(item));
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

        private Departure MapDeparture(DepartureDTO item)
        {
            return new Departure
            {
                Id = item.Id,
                AirCraft = UnitOfWork.AirCrafts.Get(item.AirCraftId),
                Crew = UnitOfWork.Crews.Get(item.CrewId),
                DepartureDate = item.DepartureDate,
                FlightNumber = item.FlightNumber

            };
        }
    }
}
