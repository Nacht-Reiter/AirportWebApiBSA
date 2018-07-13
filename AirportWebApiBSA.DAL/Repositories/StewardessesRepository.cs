using AirportWebApiBSA.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AirportWebApiBSA.DAL.Repositories
{
    class StewardessesRepository : BaseRepository<Stewardess>
    {
        private new IList<Stewardess> ItemsList = new List<Stewardess>
        {
            new Stewardess
            {
                Id = 1,
                Name = "Maria",
                Surname = "Hernandez",
                Birthday = new DateTime(1996, 7, 11)

            },
            new Stewardess
            {
                Id = 2,
                Name = "Sarah",
                Surname = "Williams",
                Birthday = new DateTime(1995, 12, 7)
            },
            new Stewardess
            {
                Id = 3,
                Name = "Ann",
                Surname = "Jones",
                Birthday = new DateTime(1988, 9, 17)
            },
            new Stewardess
            {
                Id = 4,
                Name = "Nancy",
                Surname = "Taylor",
                Birthday = new DateTime(1997, 3, 4)
            },
            new Stewardess
            {
                Id = 5,
                Name = "Catherine",
                Surname = "Clark",
                Birthday = new DateTime(1992, 1, 28)
            }
        };
    }
}