using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.Shared.DTOs
{
    public class CrewDTO : IDTO
    {
        public int Id { get; set; }
        public int PilotId { get; set; }
        public IEnumerable<int> StewardessesId { get; set; }
    }
}
