using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    class AirCraftType: Interfaces.IModel
    {
        public int Id { get; set; }
        public int Model { get; set; }
        public int PassengersCapacity { get; set; }
        public decimal CargoCapacity { get; set; }
    }
}
