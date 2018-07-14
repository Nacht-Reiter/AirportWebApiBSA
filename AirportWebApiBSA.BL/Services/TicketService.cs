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
    public class TicketService : Interfaces.IService<TicketDTO>
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Create(TicketDTO item)
        {
            UnitOfWork.Tickets.Create(Mapper.Map<TicketDTO, Ticket>(item));
            UnitOfWork.Save();
        }

        public void Delete(int id)
        {
            UnitOfWork.Tickets.Delete(id);
            UnitOfWork.Save();
        }

        public TicketDTO Get(int id)
        {
            return Mapper.Map<Ticket, TicketDTO>(UnitOfWork.Tickets.Get(id));
        }

        public IEnumerable<TicketDTO> GetAll()
        {
            return UnitOfWork.Tickets.GetAll().Select(p => Mapper.Map<Ticket, TicketDTO>(p));
        }

        public void Update(int id, TicketDTO item)
        {
            item.Id = id;
            UnitOfWork.Tickets.Update(Mapper.Map<TicketDTO, Ticket>(item));
            UnitOfWork.Save();
        }
    }
}
