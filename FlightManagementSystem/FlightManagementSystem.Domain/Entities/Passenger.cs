using FlightManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Domain.Entities
{
    public class Passenger
    {
        public string PassengerId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public FlightClass Class { get; set; }
        public decimal TicketPrice { get; set; }
        public int NumberOfBags { get; set; }
        public double TotalBaggageWeight { get; set; }
        public int SeatNumber { get; set; }
    }
}
