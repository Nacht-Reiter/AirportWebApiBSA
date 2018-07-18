using AirportWebApiBSA.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AirportWebApiBSA.Shared.DTOs
{
    public class CrewRemoteDTO : IDTO
    {
        public int Id { get; set; }
        public int PilotId { get; set; }
        public virtual IEnumerable<PilotRemoteDTO> Pilot { get; set; }
        public virtual IEnumerable<StewardessRemoteDTO> Stewardess { get; set; }

    }
}