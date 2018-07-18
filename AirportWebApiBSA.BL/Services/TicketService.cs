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
    public class TicketService : Interfaces.IService<TicketDTO>
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task Create(TicketDTO item)
        {
            await UnitOfWork.Tickets.Create(Mapper.Map<TicketDTO, Ticket>(item));
            await UnitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.Tickets.Delete(id);
            await UnitOfWork.Save();
        }

        public async Task<TicketDTO> Get(int id)
        {
            return Mapper.Map<Ticket, TicketDTO>(await UnitOfWork.Tickets.Get(id));
        }

        public async Task<IEnumerable<TicketDTO>> GetAll()
        {
            var temp = await UnitOfWork.Tickets.GetAll();
            return temp.Select(p => Mapper.Map<Ticket, TicketDTO>(p));
        }

        public void Update(int id, TicketDTO item)
        {
            item.Id = id;
            UnitOfWork.Tickets.Update(Mapper.Map<TicketDTO, Ticket>(item));
            UnitOfWork.Save();
        }
    }
}
