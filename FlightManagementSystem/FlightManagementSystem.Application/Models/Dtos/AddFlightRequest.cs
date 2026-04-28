using System.ComponentModel.DataAnnotations;

namespace FlightManagementSystem.Application.Models.Dtos
{
    public class AddFlightRequest
    {
        [Required]
        public int FlightNumber { get; set; }

        [Required]
        public string Destination { get; set; }
    }
}
