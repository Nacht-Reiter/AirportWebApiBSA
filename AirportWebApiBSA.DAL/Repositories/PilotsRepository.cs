using AirportWebApiBSA.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AirportWebApiBSA.DAL.Repositories
{
    class PilotsRepository<T> : BaseRepository<T> where T : Pilot
    {
        private new IList<Pilot> ItemsList = new List<Pilot>
        {
            new Pilot
            {
                Id = Guid.NewGuid().GetHashCode(),
                Name = "John",
                Surname = "Galt",
                Birthday = new DateTime(1985, 5, 15),
                Expirience = DateTime.Now - new DateTime(1985, 5, 15),
            },
            new Pilot
            {
                Id = Guid.NewGuid().GetHashCode(),
                Name = "Hank",
                Surname = "Rearden",
                Birthday = new DateTime(1975, 12, 7),
                Expirience = DateTime.Now - new DateTime(1975, 12, 7)
            },
            new Pilot
            {
                Id = Guid.NewGuid().GetHashCode(),
                Name = "Francisco",
                Surname = "d'Anconia",
                Birthday = new DateTime(1988, 9, 17),
                Expirience = DateTime.Now - new DateTime(1988, 9, 17)
            }
        };
    }
}