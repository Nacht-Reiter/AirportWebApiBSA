﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    class StewardessDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}
