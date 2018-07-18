using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.Shared.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task Create(PilotDTO item)
        {
            await UnitOfWork.Pilots.Create(Mapper.Map<PilotDTO, Pilot>(item));
            await UnitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.Pilots.Delete(id);
            await UnitOfWork.Save();
        }

        public async Task<PilotDTO> Get(int id)
        {
            return Mapper.Map<Pilot, PilotDTO>(await UnitOfWork.Pilots.Get(id));
        }

        public async Task<IEnumerable<PilotDTO>> GetAll()
        {
            var temp = await UnitOfWork.Pilots.GetAll();
            return temp.Select(p => Mapper.Map<Pilot, PilotDTO>(p));
        }

        public void Update(int id, PilotDTO item)
        {
            item.Id = id;
            UnitOfWork.Pilots.Update(Mapper.Map<PilotDTO, Pilot>(item));
            UnitOfWork.Save();
        }
    }
}