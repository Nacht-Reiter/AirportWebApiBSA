using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    public class Ticket : Interfaces.IModel
    {
        [Key]
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public int Price { get; set; }
    }
}
