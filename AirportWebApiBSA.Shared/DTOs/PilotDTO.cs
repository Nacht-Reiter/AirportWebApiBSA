using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.Shared.DTOs
{
    public class PilotDTO : IDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Expirience { get; set; }
    }
}
