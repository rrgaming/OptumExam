using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Domain.Entities
{
    public class Flight
    {
        public int FlightNumber { get; set; }
        public string Destination { get; set; } = string.Empty;
        public List<Passenger> Passengers { get; set; } = new();
    }
}
