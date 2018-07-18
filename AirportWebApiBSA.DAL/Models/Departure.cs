using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    public class Departure : Interfaces.IModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        [ForeignKey("Crew")]
        public int CrewId { get; set; }
        public virtual Crew Crew { get; set; }
        [ForeignKey("AirCraft")]
        public int AirCraftId { get; set; }
        public virtual AirCraft AirCraft { get; set; }
    }
}
