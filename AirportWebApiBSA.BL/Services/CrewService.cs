using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CsvHelper;

namespace AirportWebApiBSA.BLL.Services
{
    public class CrewService : Interfaces.ICrewService
    {
        private IUnitOfWork UnitOfWork;
        

        public CrewService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task Create(CrewDTO item)
        {
            await UnitOfWork.Crews.Create(await MapCrew(item));
            await UnitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.Crews.Delete(id);
            await UnitOfWork.Save();
        }

        public async Task<CrewDTO> Get(int id)
        {
            return MapCrewDTO(await UnitOfWork.Crews.Get(id));
        }

        public async Task<IEnumerable<CrewDTO>> GetAll()
        {
            var temp = await UnitOfWork.Crews.GetAll();
            return temp.Select(p => MapCrewDTO(p));
        }

        public async Task ReadFromRemoterAPI(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            client.Dispose();
            var Items = JsonConvert.DeserializeObject<IEnumerable<CrewRemoteDTO>>(responseBody).Take(10);
            await Task.WhenAll(RemoteCrewToCSV(Items), RemoteCrewToDB(Items));
            
        }

        public async Task RemoteCrewToCSV(IEnumerable<CrewRemoteDTO> Items)
        {
            using (TextWriter writer = File.CreateText($"{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.csv"))
            {
                foreach(var i in Items)
                {
                    await writer.WriteAsync($"{i.Id},{i.Pilot.ElementAt(0).FirstName},{i.Pilot.ElementAt(0).LastName},{i.Stewardess.Count()}\n");
                }
            }
        }

        public async Task RemoteCrewToDB(IEnumerable<CrewRemoteDTO> Items)
        {
            var Pilots = Items.SelectMany(i => i.Pilot);
            var Stewardesses = Items.SelectMany(i => i.Stewardess);
            foreach (var i in Pilots)
            {
                i.Id = 0;
                await UnitOfWork.Pilots.Create(MapPilotRemote(i));
            }
            foreach (var i in Stewardesses)
            {
                i.Id = 0;
                await UnitOfWork.Stewardesses.Create(MapStewardessRemote(i));
            }
            foreach (var i in Items)
            {
                i.Id = 0;
                await UnitOfWork.Crews.Create(MapCrewRemote(i));
            }
            await UnitOfWork.Save();
        }

        public async void Update(int id, CrewDTO item)
        {
            item.Id = id;
            UnitOfWork.Crews.Update(await MapCrew(item));
            await UnitOfWork.Save();
        }

        private CrewDTO MapCrewDTO(Crew item)
        {
            return new CrewDTO
            {
                Id = item.Id,
                PilotId = item.PilotId,
                StewardessesId = item.Stewardesses.Select(s => s.Id)
            };
        }
        private async Task<Crew> MapCrew(CrewDTO item)
        {
            var AllStew = new List<Stewardess>();
            AllStew.AddRange(await UnitOfWork.Stewardesses.GetAll());
            return new Crew
            {
                Id = item.Id,
                Pilot = await UnitOfWork.Pilots.Get(item.PilotId),
                Stewardesses = item.StewardessesId.Select(s => AllStew.Find(e => e.Id == s))
            };
        }
        private Crew MapCrewRemote(CrewRemoteDTO item)
        {
            var Stewardess = new List<Stewardess>();
            foreach(var s in item.Stewardess)
            {
                Stewardess.Add(MapStewardessRemote(s));
            }
            return new Crew
            {
                Id = item.Id,
                Pilot = MapPilotRemote(item.Pilot.ElementAt(0)),
                Stewardesses = Stewardess
            };
        }
        private Stewardess MapStewardessRemote(StewardessRemoteDTO item)
        {
            return new Stewardess
            {
                Id = item.Id,
                Birthday = item.BirthDate,
                CrewId = item.CrewId,
                FirstName = item.FirstName,
                LastName = item.LastName
            };
        }
        private Pilot MapPilotRemote(PilotRemoteDTO item)
        {
            return new Pilot
            {
                Id = item.Id,
                Birthday = item.BirthDate,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Expirience = item.Exp
            };
        }
    }
}
