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
    public class DepartureService : Interfaces.IService<DepartureDTO>
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public DepartureService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Create(DepartureDTO item)
        {
            UnitOfWork.Departures.Create(Mapper.Map<DepartureDTO, Departure>(item));
        }

        public void Delete(int id)
        {
            UnitOfWork.Departures.Delete(id);
        }

        public DepartureDTO Get(int id)
        {
            return Mapper.Map<Departure, DepartureDTO>(UnitOfWork.Departures.Get(id));
        }

        public IEnumerable<DepartureDTO> GetAll()
        {
            return UnitOfWork.Departures.GetAll().Select(p => Mapper.Map<Departure, DepartureDTO>(p));
        }

        public void Update(int id, DepartureDTO item)
        {
            item.Id = id;
            UnitOfWork.Departures.Update(Mapper.Map<DepartureDTO, Departure>(item));
        }
    }
}
