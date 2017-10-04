using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSystem.Models
{
    public class Passenger
    {
        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public Sex sex { get; set; }

        public DateTime birthDate { get; set; }

        public enum Sex { male, female };
    }
}