using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.Shared.DTOs
{
    public class AirCraftDTO : IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AirCraftTypeId { get; set; }
        public DateTime Manufactured { get; set; }
        public int Age { get; set; }
    }
}
