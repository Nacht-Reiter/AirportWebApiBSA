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
    public class StewardessService : Interfaces.IService<StewardessDTO>
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public StewardessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task Create(StewardessDTO item)
        {
            await UnitOfWork.Stewardesses.Create(Mapper.Map<StewardessDTO, Stewardess>(item));
            await UnitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.Stewardesses.Delete(id);
            await UnitOfWork.Save();
        }

        public async Task<StewardessDTO> Get(int id)
        {
            return Mapper.Map<Stewardess, StewardessDTO>(await UnitOfWork.Stewardesses.Get(id));
        }

        public async Task<IEnumerable<StewardessDTO>> GetAll()
        {
            var temp = await UnitOfWork.Stewardesses.GetAll();
            return temp.Select(p => Mapper.Map<Stewardess, StewardessDTO>(p));
        }

        public void Update(int id, StewardessDTO item)
        {
            item.Id = id;
            UnitOfWork.Stewardesses.Update(Mapper.Map<StewardessDTO, Stewardess>(item));
            UnitOfWork.Save();
        }
    }
}
