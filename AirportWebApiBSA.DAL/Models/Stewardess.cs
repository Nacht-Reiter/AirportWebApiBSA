using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    public class Stewardess : Interfaces.IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}
