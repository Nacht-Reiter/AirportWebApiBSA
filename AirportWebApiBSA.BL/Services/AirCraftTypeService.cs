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
    public class AirCraftTypeService : Interfaces.IService<AirCraftTypeDTO>
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public AirCraftTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Create(AirCraftTypeDTO item)
        {
            UnitOfWork.AirCraftTypes.Create(Mapper.Map<AirCraftTypeDTO, AirCraftType>(item));
            UnitOfWork.Save();
        }

        public void Delete(int id)
        {
            UnitOfWork.AirCraftTypes.Delete(id);
            UnitOfWork.Save();
        }

        public AirCraftTypeDTO Get(int id)
        {
            return Mapper.Map<AirCraftType, AirCraftTypeDTO>(UnitOfWork.AirCraftTypes.Get(id));
        }

        public IEnumerable<AirCraftTypeDTO> GetAll()
        {
            return UnitOfWork.AirCraftTypes.GetAll().Select(p => Mapper.Map<AirCraftType, AirCraftTypeDTO>(p));
        }

        public void Update(int id, AirCraftTypeDTO item)
        {
            item.Id = id;
            UnitOfWork.AirCraftTypes.Update(Mapper.Map<AirCraftTypeDTO, AirCraftType>(item));
            UnitOfWork.Save();
        }
    }
}
