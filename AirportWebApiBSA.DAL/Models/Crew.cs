using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    public class Crew : Interfaces.IModel
    {
        public int Id { get; set; }
        public Pilot Pilot { get; set; }
        public IEnumerable<Stewardess> Stewardesses { get; set; }
    }
}
