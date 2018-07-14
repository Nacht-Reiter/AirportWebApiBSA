using AutoMapper;
using AirportWebApiBSA.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AirportWebApiBSA.Shared.DTOs;
using AirportWebApiBSA.DAL.Interfaces;

namespace AirportWebApiBSA.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IUnitOfWork unitOfWork)
        {
            CreateMap<Pilot, PilotDTO>();
            CreateMap<PilotDTO, Pilot>();

            CreateMap<Stewardess, StewardessDTO>();
            CreateMap<StewardessDTO, Stewardess>();

            CreateMap<Ticket, TicketDTO>();
            CreateMap<TicketDTO, Ticket>();

            CreateMap<AirCraftType, AirCraftTypeDTO>();
            CreateMap<AirCraftTypeDTO, AirCraftType>();

            CreateMap<AirCraft, AirCraftDTO>()
                .ForMember("AirCraftTypeId", opt => opt.MapFrom(m => m.AirCraftType.Id));
            CreateMap<AirCraftDTO, AirCraft>()
                .ForMember("AirCraftType", opt => opt.MapFrom(m => unitOfWork.AirCraftTypes.Get(m.AirCraftTypeId)));

        }
    }
}