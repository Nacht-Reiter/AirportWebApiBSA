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

            CreateMap<Crew, CrewDTO>()
                .ForMember("PilotId", opt => opt.MapFrom(m => m.Pilot.Id))
                .ForMember("StewardessesId", opt => opt.MapFrom(m => m.Stewardesses.Select(s => s.Id)));
            CreateMap<CrewDTO, Crew>()
                .ForMember("Pilot", opt => opt.MapFrom(m => unitOfWork.Pilots.Get(m.PilotId)))
                .ForMember("Stewardesses", opt => opt.MapFrom(m => unitOfWork.Stewardesses.GetAll().Where(s => m.StewardessesId.Contains(s.Id))));

            CreateMap<Departure, DepartureDTO>()
                .ForMember("AirCraftId", opt => opt.MapFrom(m => m.AirCraft.Id))
                .ForMember("CrewId", opt => opt.MapFrom(m => m.Crew.Id));
            CreateMap<DepartureDTO, Departure>()
                .ForMember("AirCraft", opt => opt.MapFrom(m => unitOfWork.AirCrafts.Get(m.AirCraftId)))
                .ForMember("Crew", opt => opt.MapFrom(m => unitOfWork.Crews.Get(m.CrewId)));

            CreateMap<Flight, FlightDTO>()
                .ForMember("TicketsId", opt => opt.MapFrom(m => m.Tickets.Select(s => s.Id)));
            CreateMap<FlightDTO, Flight>()
                .ForMember("Tickets", opt => opt.MapFrom(m => unitOfWork.Tickets.GetAll().Where(s => m.TicketsId.Contains(s.Id))));

        }
    }
}