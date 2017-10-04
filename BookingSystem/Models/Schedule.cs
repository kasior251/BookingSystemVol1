using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookingSystem.Models
{
    public class Schedule
    {
        public int id { get; set; }
        public string departureDate { get; set; }
        public string arrivalDate { get; set; }
        public int seatsLeft { get; set; }
        public virtual Route route { get; set; }
        public double price { get; set; }
    }
}