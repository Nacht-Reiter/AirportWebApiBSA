using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.Shared.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AirportWebApiBSA.BLL.Services
{
    public class FlightService : Interfaces.IService<FlightDTO>
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public FlightService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Create(FlightDTO item)
        {
            UnitOfWork.Flights.Create(Mapper.Map<FlightDTO, Flight>(item));
        }

        public void Delete(int id)
        {
            UnitOfWork.Flights.Delete(id);
        }

        public FlightDTO Get(int id)
        {
            return Mapper.Map<Flight, FlightDTO>(UnitOfWork.Flights.Get(id));
        }

        public IEnumerable<FlightDTO> GetAll()
        {
            return UnitOfWork.Flights.GetAll().Select(p => Mapper.Map<Flight, FlightDTO>(p));
        }

        public void Update(int id, FlightDTO item)
        {
            item.Id = id;
            UnitOfWork.Flights.Update(Mapper.Map<FlightDTO, Flight>(item));
        }
    }
}
