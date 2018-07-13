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
    public class CrewService : Interfaces.IService<CrewDTO>
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public CrewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Create(CrewDTO item)
        {
            UnitOfWork.Crews.Create(Mapper.Map<CrewDTO, Crew>(item));
        }

        public void Delete(int id)
        {
            UnitOfWork.Crews.Delete(id);
        }

        public CrewDTO Get(int id)
        {
            return Mapper.Map<Crew, CrewDTO>(UnitOfWork.Crews.Get(id));
        }

        public IEnumerable<CrewDTO> GetAll()
        {
            return UnitOfWork.Crews.GetAll().Select(p => Mapper.Map<Crew, CrewDTO>(p));
        }

        public void Update(int id, CrewDTO item)
        {
            item.Id = id;
            UnitOfWork.Crews.Update(Mapper.Map<CrewDTO, Crew>(item));
        }
    }
}
