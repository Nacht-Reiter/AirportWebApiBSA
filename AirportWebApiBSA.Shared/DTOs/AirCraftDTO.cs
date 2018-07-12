using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    class AirCraftDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AirCraftTypeId { get; set; }
        public DateTime Manufactured { get; set; }
        public TimeSpan Age { get; set; }
    }
}
