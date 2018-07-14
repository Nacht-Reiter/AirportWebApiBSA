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
    public class StewardessService : Interfaces.IService<StewardessDTO>
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public StewardessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Create(StewardessDTO item)
        {
            UnitOfWork.Stewardesses.Create(Mapper.Map<StewardessDTO, Stewardess>(item));
            UnitOfWork.Save();
        }

        public void Delete(int id)
        {
            UnitOfWork.Stewardesses.Delete(id);
            UnitOfWork.Save();
        }

        public StewardessDTO Get(int id)
        {
            return Mapper.Map<Stewardess, StewardessDTO>(UnitOfWork.Stewardesses.Get(id));
        }

        public IEnumerable<StewardessDTO> GetAll()
        {
            return UnitOfWork.Stewardesses.GetAll().Select(p => Mapper.Map<Stewardess, StewardessDTO>(p));
        }

        public void Update(int id, StewardessDTO item)
        {
            item.Id = id;
            UnitOfWork.Stewardesses.Update(Mapper.Map<StewardessDTO, Stewardess>(item));
            UnitOfWork.Save();
        }
    }
}
