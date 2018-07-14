using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AirportWebApiBSA.BLL.Services
{
    public class CrewService : Interfaces.IService<CrewDTO>
    {
        private IUnitOfWork UnitOfWork;

        public CrewService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Create(CrewDTO item)
        {
            UnitOfWork.Crews.Create(MapCrew(item));
            UnitOfWork.Save();
        }

        public void Delete(int id)
        {
            UnitOfWork.Crews.Delete(id);
            UnitOfWork.Save();
        }

        public CrewDTO Get(int id)
        {
            return MapCrewDTO(UnitOfWork.Crews.Get(id));
        }

        public IEnumerable<CrewDTO> GetAll()
        {
            return UnitOfWork.Crews.GetAll().Select(p => MapCrewDTO(p));
        }

        public void Update(int id, CrewDTO item)
        {
            item.Id = id;
            UnitOfWork.Crews.Update(MapCrew(item));
            UnitOfWork.Save();
        }

        private CrewDTO MapCrewDTO(Crew item)
        {
            return new CrewDTO
            {
                Id = item.Id,
                PilotId = item.Pilot.Id,
                StewardessesId = item.Stewardesses.Select(s => s.Id)
            };
        }
        private Crew MapCrew(CrewDTO item)
        {
            return new Crew
            {
                Id = item.Id,
                Pilot = UnitOfWork.Pilots.Get(item.PilotId),
                Stewardesses = item.StewardessesId.Select(s => UnitOfWork.Stewardesses.Get(s))
            };
        }
    }
}
