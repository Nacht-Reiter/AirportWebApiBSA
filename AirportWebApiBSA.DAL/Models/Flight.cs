﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
     public class Flight : Interfaces.IModel
    {
        public int Id { get; set; }
        public string EntryPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }

    }
}
