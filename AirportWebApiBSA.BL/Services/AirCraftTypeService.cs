using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.Shared.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task Create(AirCraftTypeDTO item)
        {
            await UnitOfWork.AirCraftTypes.Create(Mapper.Map<AirCraftTypeDTO, AirCraftType>(item));
            await UnitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.AirCraftTypes.Delete(id);
            await UnitOfWork.Save();
        }

        public async Task<AirCraftTypeDTO> Get(int id)
        {
            return Mapper.Map<AirCraftType, AirCraftTypeDTO>(await UnitOfWork.AirCraftTypes.Get(id));
        }

        public async Task<IEnumerable<AirCraftTypeDTO>> GetAll()
        {
            var temp = await UnitOfWork.AirCraftTypes.GetAll();
            return temp.Select(p => Mapper.Map<AirCraftType, AirCraftTypeDTO>(p));
        }

        public void Update(int id, AirCraftTypeDTO item)
        {
            item.Id = id;
            UnitOfWork.AirCraftTypes.Update(Mapper.Map<AirCraftTypeDTO, AirCraftType>(item));
            UnitOfWork.Save();
        }
    }
}
