using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.Shared.DTOs
{
    public class DepartureDTO : IDTO
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public int CrewId { get; set; }
        public int AirCraftId { get; set; }
    }
}
