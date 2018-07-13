using AirportWebApiBSA.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AirportWebApiBSA.DAL.Repositories
{
    public class AirCraftRepository: BaseRepository<AirCraft>
    {
        private new IList<AirCraft> ItemsList = new List<AirCraft>
        {
            new AirCraft
            {
                Id = 1,
                Name = "DF-23",
                AirCraftType = new AirCraftTypeRepository().Get(1),
                Manufactured = new DateTime(1990, 12, 01),
                Age = DateTime.Now - new DateTime(1990, 12, 01)
            },
            new AirCraft
            {
                Id = 2,
                Name = "DN-48",
                AirCraftType = new AirCraftTypeRepository().Get(2),
                Manufactured = new DateTime(2012, 4, 18),
                Age = DateTime.Now - new DateTime(2012, 4, 18)
            },
            new AirCraft
            {
                Id = 3,
                Name = "KL-18",
                AirCraftType = new AirCraftTypeRepository().Get(2),
                Manufactured = new DateTime(2011, 9, 8),
                Age = DateTime.Now - new DateTime(2011, 9, 8)
            }
        };
    }
}