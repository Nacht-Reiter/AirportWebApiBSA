using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.Shared.DTOs
{
    public class TicketDTO : IDTO
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public int Price { get; set; }
    }
}
