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
    public class AirCraftService : Interfaces.IService<AirCraftDTO>
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public AirCraftService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Create(AirCraftDTO item)
        {
            UnitOfWork.AirCrafts.Create(Mapper.Map<AirCraftDTO, AirCraft>(item));
            UnitOfWork.Save();
        }

        public void Delete(int id)
        {
            UnitOfWork.AirCrafts.Delete(id);
            UnitOfWork.Save();
        }

        public AirCraftDTO Get(int id)
        {
            return Mapper.Map<AirCraft, AirCraftDTO>(UnitOfWork.AirCrafts.Get(id));
        }

        public IEnumerable<AirCraftDTO> GetAll()
        {
            return UnitOfWork.AirCrafts.GetAll().Select(p => Mapper.Map<AirCraft, AirCraftDTO>(p));
        }

        public void Update(int id, AirCraftDTO item)
        {
            item.Id = id;
            UnitOfWork.AirCrafts.Update(Mapper.Map<AirCraftDTO, AirCraft>(item));
            UnitOfWork.Save();
        }
    }
}
