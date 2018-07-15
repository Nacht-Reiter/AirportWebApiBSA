using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    public class Pilot : Interfaces.IModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public TimeSpan Expirience { get; set; }
    }
}
