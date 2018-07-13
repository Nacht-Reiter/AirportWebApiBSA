using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    public class AirCraft : Interfaces.IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AirCraftType AirCraftType { get; set; }
        public DateTime Manufactured { get; set; }
        public TimeSpan Age { get; set; }
    }
}
