using AirportWebApiBSA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AirportWebApiBSA.DAL.Repositories
{
    public class CrewsRepository: BaseRepository<Crew>
    {
        public CrewsRepository()
        {
            ItemsList = new List<Crew>
            {
                new Crew
                {
                    Id = 1,
                    Pilot = new PilotsRepository().Get(1),
                    Stewardesses = new List<Stewardess>
                    {
                        new StewardessesRepository().Get(1),
                        new StewardessesRepository().Get(2)
                    }
                },
                new Crew
                {
                    Id = 2,
                    Pilot = new PilotsRepository().Get(2),
                    Stewardesses = new List<Stewardess>
                    {
                        new StewardessesRepository().Get(3),
                        new StewardessesRepository().Get(4)
                    }
                },
                new Crew
                {
                    Id = 3,
                    Pilot = new PilotsRepository().Get(3),
                    Stewardesses = new List<Stewardess>
                    {
                        new StewardessesRepository().Get(5)
                    }
                }
            };
        }
    }
}
