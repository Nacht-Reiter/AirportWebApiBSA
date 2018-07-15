using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    public class AirCraftType : Interfaces.IModel
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public int PassengersCapacity { get; set; }
        public decimal CargoCapacity { get; set; }
    }
}
