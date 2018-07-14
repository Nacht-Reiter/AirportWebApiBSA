using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.Shared.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace AirportWebApiBSA.BLL.Services
{
    public class PilotService : Interfaces.IService<PilotDTO>
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public PilotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Create(PilotDTO item)
        {
            UnitOfWork.Pilots.Create(Mapper.Map<PilotDTO, Pilot>(item));
            UnitOfWork.Save();
        }

        public void Delete(int id)
        {
            UnitOfWork.Pilots.Delete(id);
            UnitOfWork.Save();
        }

        public PilotDTO Get(int id)
        {
            return Mapper.Map<Pilot, PilotDTO>(UnitOfWork.Pilots.Get(id));
        }

        public IEnumerable<PilotDTO> GetAll()
        {
            return UnitOfWork.Pilots.GetAll().Select(p => Mapper.Map<Pilot, PilotDTO>(p));
        }

        public void Update(int id, PilotDTO item)
        {
            item.Id = id;
            UnitOfWork.Pilots.Update(Mapper.Map<PilotDTO, Pilot>(item));
            UnitOfWork.Save();
        }
    }
}