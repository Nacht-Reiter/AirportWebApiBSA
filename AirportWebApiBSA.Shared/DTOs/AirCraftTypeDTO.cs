using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.Shared.DTOs
{
    public class AirCraftTypeDTO : IDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int PassengersCapacity { get; set; }
        public decimal CargoCapacity { get; set; }
    }
}
