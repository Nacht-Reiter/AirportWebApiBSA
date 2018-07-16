using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
     public class Flight : Interfaces.IModel
    {
        [Key]
        public int Id { get; set; }
        public string EntryPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
        public virtual IEnumerable<Ticket> Tickets { get; set; }

        public Flight()
        {
            Tickets = new List<Ticket>();
        }
    }
}
