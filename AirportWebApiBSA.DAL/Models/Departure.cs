using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    public class Departure : Interfaces.IModel
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public Crew Crew { get; set; }
        public AirCraft AirCraft { get; set; }
    }
}
