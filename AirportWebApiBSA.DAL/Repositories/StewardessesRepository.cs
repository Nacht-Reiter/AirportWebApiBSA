using AirportWebApiBSA.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AirportWebApiBSA.DAL.Repositories
{
    class StewardessesRepository<T> : BaseRepository<T> where T : Stewardess
    {
        private new IList<Stewardess> ItemsList = new List<Stewardess>
        {
            new Stewardess
            {
                Id = Guid.NewGuid().GetHashCode(),
                Name = "Maria",
                Surname = "Hernandez",
                Birthday = new DateTime(1996, 7, 11)

            },
            new Stewardess
            {
                Id = Guid.NewGuid().GetHashCode(),
                Name = "Sarah",
                Surname = "Williams",
                Birthday = new DateTime(1995, 12, 7)
            },
            new Stewardess
            {
                Id = Guid.NewGuid().GetHashCode(),
                Name = "Ann",
                Surname = "Jones",
                Birthday = new DateTime(1988, 9, 17)
            },
            new Stewardess
            {
                Id = Guid.NewGuid().GetHashCode(),
                Name = "Nancy",
                Surname = "Taylor",
                Birthday = new DateTime(1997, 3, 4)
            },
            new Stewardess
            {
                Id = Guid.NewGuid().GetHashCode(),
                Name = "Catherine",
                Surname = "Clark",
                Birthday = new DateTime(1992, 1, 28)
            }
        };
    }
}