using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSystem.Models
{
    public class Ticket
    {
        public int id { get; set; }

        public List<Passenger> passengers { get; set; }

        public Schedule schedule { get; set; }
    }
}