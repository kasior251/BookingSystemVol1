using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Route route { get; set; }
        public List<Ticket> tickets { get; set; }
        public int price { get; set; }
    }
}