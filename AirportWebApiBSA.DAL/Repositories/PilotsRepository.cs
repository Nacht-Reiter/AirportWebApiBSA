using AirportWebApiBSA.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AirportWebApiBSA.DAL.Repositories
{
    public class PilotsRepository : BaseRepository<Pilot>
    {
        public PilotsRepository()
        {
            ItemsList = new List<Pilot>
            {
                new Pilot
                {
                    Id = 1,
                    Name = "John",
                    Surname = "Galt",
                    Birthday = new DateTime(1985, 5, 15),
                    Expirience = DateTime.Now - new DateTime(2005, 5, 15),
                },
                new Pilot
                {
                    Id = 2,
                    Name = "Hank",
                    Surname = "Rearden",
                    Birthday = new DateTime(1975, 12, 7),
                    Expirience = DateTime.Now - new DateTime(1998, 12, 7)
                },
                new Pilot
                {
                    Id = 3,
                    Name = "Francisco",
                    Surname = "d'Anconia",
                    Birthday = new DateTime(1988, 9, 17),
                    Expirience = DateTime.Now - new DateTime(2010, 9, 17)
                }
            };
        }
    }
}