using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    class Crew : Interfaces.IModel
    {
        public int Id { get; set; }
        public Pilot Pilot { get; set; }
        public Stewardess Stewardesses { get; set; }
    }
}
