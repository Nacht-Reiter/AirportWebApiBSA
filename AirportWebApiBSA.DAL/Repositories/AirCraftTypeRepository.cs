using AirportWebApiBSA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.DAL.Repositories
{
    public class AirCraftTypeRepository : BaseRepository<AirCraftType>
    {
        private new IList<AirCraftType> ItemsList = new List<AirCraftType>
        {
            new AirCraftType
            {
                Id = 1,
                Model = "Concord",
                PassengersCapacity = 75,
                CargoCapacity = 300
            },
            new AirCraftType
            {
                Id = 2,
                Model = "Airbus A-380",
                PassengersCapacity = 500,
                CargoCapacity = 2000
            }
        };
    }
}
