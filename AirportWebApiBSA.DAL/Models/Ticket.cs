using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    class Ticket : Interfaces.IModel
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public int Price { get; set; }
    }
}
