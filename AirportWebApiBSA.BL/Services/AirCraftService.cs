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
    public class AirCraftService : Interfaces.IService<AirCraftDTO>
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public AirCraftService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task Create(AirCraftDTO item)
        {
            await UnitOfWork.AirCrafts.Create(Mapper.Map<AirCraftDTO, AirCraft>(item));
            await UnitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.AirCrafts.Delete(id);
            await UnitOfWork.Save();
        }

        public async Task<AirCraftDTO> Get(int id)
        {
            return Mapper.Map<AirCraft, AirCraftDTO>(await UnitOfWork.AirCrafts.Get(id));
        }

        public async Task<IEnumerable<AirCraftDTO>> GetAll()
        {
            var temp = await UnitOfWork.AirCrafts.GetAll();
            return temp.Select(p => Mapper.Map<AirCraft, AirCraftDTO>(p));
        }

        public void Update(int id, AirCraftDTO item)
        {
            item.Id = id;
            UnitOfWork.AirCrafts.Update(Mapper.Map<AirCraftDTO, AirCraft>(item));
            UnitOfWork.Save();
        }
    }
}
