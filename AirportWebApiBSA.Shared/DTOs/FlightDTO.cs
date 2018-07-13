using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.Shared.DTOs
{
    public class FlightDTO : IDTO
    {
        public int Id { get; set; }
        public string EntryPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
        public IEnumerable<int> TicketsId { get; set; }

    }
}
